using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SymmetricDS.Admin.Master;
using SymmetricDS.Admin.Master.Service;
using System;
using System.IO;
using System.Threading;

namespace SymmetricDS.Admin.ConsoleApp
{
    class Program
    {
        private static void Run(AppSettings appSettings, IInitializationService initialization, INodeSecurityService nodeSecurityService)
        {
            var node = initialization.GetNode(appSettings.NodeId);
            if (node == null)
                Console.WriteLine("伺服器未登錄本節點資訊");
            else
            {
                node.StopService(appSettings.SymmetricServerPath);
                Thread.Sleep(100);
                node.UninstallService(appSettings.SymmetricServerPath);
                Thread.Sleep(100);

                if (node.Version == appSettings.Version)
                    Console.WriteLine("本節點不須更新");
                else
                {
                    bool success = node.CopyTo(appSettings.SymmetricServerPath) && node.Write(appSettings.SymmetricServerPath);

                    if (string.IsNullOrEmpty(node.RegistrationUrl) && success)
                    {
                        int check = 0;

                        initialization.CreateTables(appSettings.SymmetricServerPath, node);
                        do
                        {
                            check += 1;
                            success = initialization.CheckTables();
                            Thread.Sleep(1000);
                        } while (!success && check < 3);
                        if (!success)
                            throw new Exception("資料表處理失敗，有可能是資料庫 pg_hba.conf 設定錯誤");

                        success = initialization.NodeGroups(node) && initialization.SynchronizationMethod(node) &&
                            initialization.Node(node) && initialization.Channel() && initialization.Triggers() &&
                            initialization.Router() && initialization.Relationship();

                        if (success)
                        {
                            check = 0;
                            var nodeIds = node.MasterNode.Register(appSettings.SymmetricServerPath, node);
                            do
                            {
                                check += 1;
                                success = nodeSecurityService.CheckRegister(nodeIds);
                                Thread.Sleep(1000);
                            } while (!success && check < 3);
                            if (!success)
                                throw new Exception("註冊 client node 失敗");
                        }
                        else
                            Console.WriteLine("初始化失敗");
                    }

                    if (success)
                    {
                        node.InstallService(appSettings.SymmetricServerPath);
                        Thread.Sleep(100);
                        node.StartService(appSettings.SymmetricServerPath);
                        Thread.Sleep(100);

                        appSettings.Version = node.Version;
                        string contents = JsonConvert.SerializeObject(appSettings);
                        string path = Directory.GetCurrentDirectory();
                        path = Path.GetFullPath(path + "appsettings.json");
                        File.WriteAllText(path, contents);
                    }
                    else
                        Console.WriteLine("設定配置失敗");
                }
            }
        }

        static ILoggerFactory LoggerFactory { get; set; }
        static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            var builder = new ConfigurationBuilder().SetBasePath(Path.Combine(AppContext.BaseDirectory)).AddJsonFile("appsettings.json", true, true);
            Configuration = builder.Build();

            LoggerFactory = new LoggerFactory().AddConsole(Configuration.GetSection("Logging")).AddDebug();

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddEntityFrameworkNpgsql().AddDbContext<Master.MasterDbContext>(o => o.UseNpgsql(connectionString), ServiceLifetime.Transient);
            services.AddEntityFrameworkNpgsql().AddDbContext<Server.ServerDbContext>(o => o.UseNpgsql(connectionString), ServiceLifetime.Transient);
            services.AddOptions().Configure<AppSettings>(Configuration);
            services.AddScoped<IInitializationService, InitializationService>();
            services.AddScoped<INodeSecurityService, NodeSecurityService>();

            // build
            var serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            logger.LogInformation("Starting application");

            var appSettings = serviceProvider.GetService<IOptions<AppSettings>>().Value;
            if (appSettings.SymmetricServerPath.Contains(' '))
                throw new Exception("應用程式目錄不可有空白");
            var initialization = serviceProvider.GetService<IInitializationService>();
            var nodeSecurityService = serviceProvider.GetService<INodeSecurityService>();
            Run(appSettings, initialization, nodeSecurityService);

            logger.LogInformation("All done!");
        }
    }
}

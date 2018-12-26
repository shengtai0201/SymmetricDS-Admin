using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;
using SymmetricDS.Admin.ConsoleApp.Service;
using SymmetricDS.Admin.Master.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.ConsoleApp
{
    internal class Program
    {
        private static bool Run(AppSettings appSettings, IInitializationService initialization, Master.INodeSecurityService nodeSecurityService)
        {
            bool allSuccessful = appSettings.Nodes.Count > 0;
            if (allSuccessful)
            {
                var nodes = new List<Node>();
                foreach (var n in appSettings.Nodes)
                {
                    var node = initialization.GetNode(n.Id);
                    if (node == null)
                    {
                        allSuccessful = false;
                        Console.WriteLine($"伺服器未登錄 NodeId:{n.Id} 資訊");
                    }
                    else
                    {
                        nodes.Add(node);

                        if (node.Version == n.Version)
                            Console.WriteLine($"NodeId:{n.Id} 不須更新");
                        else
                        {
                            allSuccessful = node.CopyTo(appSettings.SymmetricServerPath) && node.Write(appSettings.SymmetricServerPath);

                            if (string.IsNullOrEmpty(node.RegistrationUrl) && allSuccessful)
                            {
                                int check = 0;

                                initialization.CreateTables(appSettings.SymmetricServerPath, node);
                                do
                                {
                                    check += 1;
                                    allSuccessful = initialization.CheckTables();
                                    Thread.Sleep(1000);
                                } while (!allSuccessful && check < 3);
                                if (!allSuccessful)
                                    throw new Exception($"NodeId:{n.Id} 資料表處理失敗，有可能是資料庫 pg_hba.conf 設定錯誤");

                                allSuccessful = initialization.NodeGroups(node) && initialization.SynchronizationMethod(node) &&
                                    initialization.Node(node) && initialization.Channel() && initialization.Triggers() &&
                                    initialization.Router() && initialization.Relationship();

                                if (allSuccessful)
                                {
                                    check = 0;
                                    var nodeIds = node.MasterNode.Register(appSettings.SymmetricServerPath, node);
                                    do
                                    {
                                        check += 1;
                                        allSuccessful = nodeSecurityService.CheckRegister(nodeIds);
                                        Thread.Sleep(1000);
                                    } while (!allSuccessful && check < 3);
                                    if (!allSuccessful)
                                        throw new Exception($"NodeId:{n.Id} 註冊 client node 失敗");
                                }
                                else
                                    Console.WriteLine($"NodeId:{n.Id} 初始化失敗");
                            }

                            if (allSuccessful)
                                n.Version = node.Version;
                            else
                                Console.WriteLine($"NodeId:{n.Id} 設定配置失敗");
                        }
                    }
                }

                if (allSuccessful)
                {
                    string contents = JsonConvert.SerializeObject(appSettings);
                    string path = Directory.GetCurrentDirectory();
                    path = Path.GetFullPath(path + "\\appsettings.json");

                    try
                    {
                        File.WriteAllText(path, contents);
                    }
                    catch
                    {
                        allSuccessful = false;
                    }

                    if (allSuccessful)
                        Parallel.ForEach(nodes, n => n.RunOnlyOnce(appSettings.SymmetricServerPath, initialization));
                }
            }

            return allSuccessful;
        }

        private static IConfigurationRoot Configuration { get; set; }

        private static void Main(string[] args)
        {
            var services = new ServiceCollection();

            var builder = new ConfigurationBuilder().SetBasePath(Path.Combine(AppContext.BaseDirectory)).AddJsonFile("appsettings.json", true, true);
            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\SymmetricDS.Admin.ConsoleApp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            services.AddOptions().Configure<AppSettings>(Configuration);

            // build
            var serviceProvider = services.BuildServiceProvider();
            Log.Information("Starting application");

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            var appSettings = serviceProvider.GetService<IOptions<AppSettings>>().Value;
            // add service(by databse type) here
            switch (appSettings.Database)
            {
                case Databases.PostgreSQL:
                    services.AddEntityFrameworkNpgsql().AddDbContext<Master.MasterDbContext>(o => o.UseNpgsql(connectionString), ServiceLifetime.Scoped);
                    services.AddEntityFrameworkNpgsql().AddDbContext<Server.ServerDbContext>(o => o.UseNpgsql(connectionString), ServiceLifetime.Scoped);
                    services.AddScoped<IInitializationService, NpgsqlInitializationService>();
                    break;

                case Databases.SQLServer:
                    services.AddEntityFrameworkSqlServer().AddDbContext<Master.MasterDbContext>(o => o.UseSqlServer(connectionString), ServiceLifetime.Scoped);
                    services.AddEntityFrameworkSqlServer().AddDbContext<Server.ServerDbContext>(o => o.UseSqlServer(connectionString), ServiceLifetime.Scoped);
                    services.AddScoped<IInitializationService, SqlInitializationService>();
                    break;
            }
            services.AddScoped<Master.INodeSecurityService, NodeSecurityService>();
            serviceProvider = services.BuildServiceProvider();

            if (appSettings.SymmetricServerPath.Contains(' '))
                throw new Exception("應用程式目錄不可有空白");
            var initialization = serviceProvider.GetService<IInitializationService>();
            var nodeSecurityService = serviceProvider.GetService<Master.INodeSecurityService>();
            Run(appSettings, initialization, nodeSecurityService);

            Log.Information("All done!");
        }
    }
}
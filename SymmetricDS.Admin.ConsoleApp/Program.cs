﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;
using SymmetricDS.Admin.Master.Service;
using System;
using System.IO;
using System.Threading;

namespace SymmetricDS.Admin.ConsoleApp
{
    class Program
    {
        private static bool Run(AppSettings appSettings, IInitializationService initialization, Master.INodeSecurityService nodeSecurityService)
        {
            bool success = appSettings.Nodes.Count > 0;
            if (success)
            {
                initialization.StopService(appSettings.SymmetricServerPath);
                Thread.Sleep(100);
                initialization.UninstallService(appSettings.SymmetricServerPath);
                Thread.Sleep(100);

                foreach (var n in appSettings.Nodes)
                {
                    var node = initialization.GetNode(n.Id);
                    if (node == null)
                        Console.WriteLine($"伺服器未登錄 NodeId:{n.Id} 資訊");
                    else
                    {
                        if (node.Version == n.Version)
                            Console.WriteLine($"NodeId:{n.Id} 不須更新");
                        else
                        {
                            success = node.CopyTo(appSettings.SymmetricServerPath) && node.Write(appSettings.SymmetricServerPath);

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
                                    throw new Exception($"NodeId:{n.Id} 資料表處理失敗，有可能是資料庫 pg_hba.conf 設定錯誤");

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
                                        throw new Exception($"NodeId:{n.Id} 註冊 client node 失敗");
                                }
                                else
                                    Console.WriteLine($"NodeId:{n.Id} 初始化失敗");
                            }

                            if (success)
                            {
                                n.Version = node.Version;
                                string contents = JsonConvert.SerializeObject(appSettings);
                                string path = Directory.GetCurrentDirectory();
                                path = Path.GetFullPath(path + "appsettings.json");

                                try
                                {
                                    File.WriteAllText(path, contents);
                                }
                                catch
                                {
                                    success = false;
                                }
                            }
                            else
                                Console.WriteLine($"NodeId:{n.Id} 設定配置失敗");
                        }
                    }
                }
            }

            if (success)
            {
                initialization.InstallService(appSettings.SymmetricServerPath);
                Thread.Sleep(100);
                initialization.StartService(appSettings.SymmetricServerPath);
                Thread.Sleep(100);
            }

            return success;
        }

        //static ILoggerFactory LoggerFactory { get; set; }
        static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            var builder = new ConfigurationBuilder().SetBasePath(Path.Combine(AppContext.BaseDirectory)).AddJsonFile("appsettings.json", true, true);
            Configuration = builder.Build();

            //LoggerFactory = new LoggerFactory().AddConsole(Configuration.GetSection("Logging")).AddDebug();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\SymmetricDS.Admin.ConsoleApp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            services.AddOptions().Configure<AppSettings>(Configuration);

            // build
            var serviceProvider = services.BuildServiceProvider();
            //var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            Log.Information("Starting application");

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            var appSettings = serviceProvider.GetService<IOptions<AppSettings>>().Value;
            // add service(by databse type) here
            switch (appSettings.Database)
            {
                case Databases.PostgreSQL:
                    services.AddEntityFrameworkNpgsql().AddDbContext<Master.MasterDbContext>(o => o.UseNpgsql(connectionString), ServiceLifetime.Transient);
                    services.AddEntityFrameworkNpgsql().AddDbContext<Server.ServerDbContext>(o => o.UseNpgsql(connectionString), ServiceLifetime.Transient);
                    services.AddScoped<IInitializationService, NpgsqlInitializationService>();
                    services.AddScoped<Master.INodeSecurityService, NpgsqlNodeSecurityService>();
                    break;
                case Databases.SQLServer:
                    services.AddEntityFrameworkSqlServer().AddDbContext<Master.MasterDbContext>(o => o.UseSqlServer(connectionString), ServiceLifetime.Transient);
                    services.AddEntityFrameworkSqlServer().AddDbContext<Server.ServerDbContext>(o => o.UseSqlServer(connectionString), ServiceLifetime.Transient);
                    services.AddScoped<IInitializationService, SqlInitializationService>();
                    services.AddScoped<Master.INodeSecurityService, SqlNodeSecurityService>();
                    break;
            }
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

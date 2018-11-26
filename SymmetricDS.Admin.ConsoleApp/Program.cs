using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;

namespace SymmetricDS.Admin.ConsoleApp
{
    class Program
    {
        private static void Run(int nodeId, int version, IInitialization initialization, AppSettings appSettings)
        {
            var node = initialization.GetNode(nodeId);
            if (node == null)
                Console.WriteLine("伺服器未登錄本節點資訊");
            else
            {
                if (node.Version == version)
                    Console.WriteLine("本節點不須更新");
                else
                {
                    string path = @"C:\Program Files\symmetric-server-3.9.15\";
                    bool success = node.CopyTo(path) && node.Write(path);

                    if (string.IsNullOrEmpty(node.RegistrationUrl) && success)
                    {
                        initialization.CreateTables(path, node);
                        Thread.Sleep(1000);

                        success = initialization.NodeGroups(node) && initialization.SynchronizationMethod(node) &&
                            initialization.Node(node) && initialization.Channel() && initialization.Triggers() &&
                            initialization.Router() && initialization.Relationship();

                        if (success)
                        {
                            node.MasterNode.Register(path, node);
                            Thread.Sleep(3000);

                            node.MasterNode.Start(path);
                            Thread.Sleep(1000);

                            appSettings.Version = node.Version.ToString();
                            string contents = JsonConvert.SerializeObject(appSettings);
                            File.WriteAllText(path, contents);
                        }
                        else
                            Console.WriteLine("初始化失敗");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            path = Path.GetFullPath(path + "appsettings.json");
            string value = File.ReadAllText(path);
            var appSettings = JsonConvert.DeserializeObject<AppSettings>(value);

            if (Enum.TryParse(appSettings.Database, out Databases database))
            {
                int nodeId = Convert.ToInt32(appSettings.NodeId);
                int version = Convert.ToInt32(appSettings.Version);
                var initialization = new Initialization(database, appSettings.ConnectionString);

                Run(nodeId, version, initialization, appSettings);
            }
        }
    }
}

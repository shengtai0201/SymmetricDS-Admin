using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;

namespace SymmetricDS.Admin.Tests
{
    [TestFixture]
    public class InitializationTests
    {
        private IConfigurationRoot configuration;
        //private IInitializationService initialization;

        public InitializationTests()
        {
            //this.masterNode = new Node(Databases.SQLServer,
            //    "localhost", "Test", "sa", "p@$$w0rd",
            //    "8080", "sunserver", "000");
            //this.client1Node = new Node(this.masterNode, Databases.SQLServer,
            //    "10.40.9.20", "sun1", "sa", "1qaz2wsx",
            //    "7070", "sunclient", "001");
            //this.client2Node = new Node(this.masterNode, Databases.SQLServer,
            //    "10.40.9.20", "sun2", "sa", "1qaz2wsx",
            //    "9090", "sunclient", "002");
            //this.client3Node = new Node(this.masterNode, Databases.Oracle,
            //    "10.40.9.2", "XE", "apps", "apps",
            //    "8888", "sunclient", "003");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            this.configuration = builder.Build();

            //if (Enum.TryParse(configuration["Database"], out Databases database))
            //    this.initialization = new Initialization(database, configuration["ConnectionString"]);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //this.masterNode = null;
            //this.client1Node = null;
            //this.client2Node = null;
            //this.client3Node = null;
            //this.initialization = null;
        }

        //[Test]
        //public void CheckVersion()
        //{
        //    int nodeId = Convert.ToInt32(this.configuration["NodeId"]);
        //    int version = Convert.ToInt32(this.configuration["Version"]);

        //    var node = this.initialization.GetNode(nodeId);
        //    if (node == null)
        //        Console.WriteLine("伺服器未登錄本節點資訊");
        //    else
        //    {
        //        if (node.Version == version)
        //            Console.WriteLine("本節點不須更新");
        //        else
        //        {
        //            string path = @"C:\Program Files\symmetric-server-3.9.15\";
        //            bool success = node.CopyTo(path) && node.Write(path);

        //            if (string.IsNullOrEmpty(node.RegistrationUrl) && success)
        //            {
        //                this.initialization.CreateTables(path, node);
        //                Thread.Sleep(1000);

        //                success = this.initialization.NodeGroups(node) && this.initialization.SynchronizationMethod(node) &&
        //                    this.initialization.Node(node) && this.initialization.Channel() && this.initialization.Triggers() &&
        //                    this.initialization.Router() && this.initialization.Relationship();

        //                if (success)
        //                {
        //                    node.MasterNode.Register(path, node);
        //                    Thread.Sleep(3000);

        //                    node.MasterNode.RunOnlyOnce(path);
        //                }
        //            }
        //        }
        //    }
        //}

        private string ReadStartsWith(string path, string value)
        {
            foreach (var line in File.ReadAllLines(path))
                if (line.StartsWith(value))
                    return line;

            return null;
        }

        //[Test]
        //public void AAA()
        //{
        //    Console.WriteLine(this.configuration["Version"]);

        //    string path = @"C:\Users\User\Documents\Visual Studio 2017\Projects\SymmetricDS\SymmetricDS.Admin.Tests\bin\Debug\netcoreapp2.1\";
        //    path = Path.GetFullPath(path + "appsettings.json");

        //    string value = File.ReadAllText(path);
        //    var appSettings = JsonConvert.DeserializeObject<AppSettings>(value);
        //    Console.WriteLine(appSettings.Version);

        //    appSettings.Version = 123;
        //    value = JsonConvert.SerializeObject(appSettings);
        //    File.WriteAllText(path, value);

        //    this.configuration.Reload();
        //    Console.WriteLine(this.configuration["Version"]);
        //}
    }
}
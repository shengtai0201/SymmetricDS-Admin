using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.Tests
{
    [TestFixture]
    public class InitializationTests
    {
        private Node masterNode;
        private Node client1Node;
        private Node client2Node;
        private Node client3Node;
        private IInitialization initialization;

        public InitializationTests()
        {
            this.masterNode = new Node(Databases.SQLServer,
                "localhost", "Test", "sa", "p@$$w0rd",
                "8080", "sunserver", "000");
            this.client1Node = new Node(this.masterNode, Databases.SQLServer,
                "10.40.9.20", "sun1", "sa", "1qaz2wsx",
                "7070", "sunclient", "001");
            this.client2Node = new Node(this.masterNode, Databases.SQLServer,
                "10.40.9.20", "sun2", "sa", "1qaz2wsx",
                "9090", "sunclient", "002");
            this.client3Node = new Node(this.masterNode, Databases.Oracle,
                "10.40.9.2", "XE", "apps", "apps",
                "8888", "sunclient", "003");

            this.initialization = new Initialization(masterNode);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.masterNode = null;
            this.client1Node = null;
            this.client2Node = null;
            this.client3Node = null;
            this.initialization = null;
        }

        [Test]
        public void CreateTables()
        {
            string path = @"C:\Program Files\symmetric-server-3.9.15\";

            this.initialization.CreateTables(path, this.masterNode);
        }

        [Test]
        public void NodeGroup()
        {

            //this.initialization.NodeGroup(new KeyValuePair<string, string>("", ""), )
        }
    }
}

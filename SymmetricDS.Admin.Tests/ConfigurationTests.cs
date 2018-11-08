using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.Tests
{
    [TestFixture]
    public class ConfigurationTests
    {
        private Node masterNode;
        private Node client1Node;
        private Node client2Node;
        private Node client3Node;

        public ConfigurationTests()
        {
            var clientGroup = new NodeGroup
            {
                GroupId = "sunclient",
                Description = "次要資料中心",
                Parent = new NodeGroup { GroupId = "sunserver", Description = "主要資料中心" }
            };

            this.masterNode = new MasterNode(Databases.SQLServer,
                "localhost", "Test", "sa", "p@$$w0rd",
                "8080", clientGroup.Parent, "000");
            this.client1Node = new ClientNode(this.masterNode, Databases.SQLServer, 
                "10.40.9.20", "sun1", "sa", "1qaz2wsx", 
                "7070", clientGroup, "001");
            this.client2Node = new ClientNode(this.masterNode, Databases.SQLServer,
                "10.40.9.20", "sun2", "sa", "1qaz2wsx",
                "9090", clientGroup, "002");
            this.client3Node = new ClientNode(this.masterNode, Databases.Oracle,
                "10.40.9.2", "XE", "apps", "apps",
                "8888", clientGroup, "003");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.masterNode = null;
            this.client1Node = null;
            this.client2Node = null;
            this.client3Node = null;
        }

        [Test]
        public void MasterNodeCopyTo()
        {
            string path = @"C:\Program Files\symmetric-server-3.9.15\";

            bool condition = this.masterNode.CopyTo(path);

            Assert.IsTrue(condition);
        }

        [Test]
        public void MasterNodeWrite()
        {
            string path = @"C:\Program Files\symmetric-server-3.9.15\";

            bool condition = this.masterNode.Write(path);

            Assert.IsTrue(condition);
        }

        [Test]
        public void Client1NodeCopyTo()
        {
            string path = @"C:\Program Files\symmetric-server-3.9.15\";

            bool condition = this.client1Node.CopyTo(path);

            Assert.IsTrue(condition);
        }

        [Test]
        public void Client1NodeWrite()
        {
            string path = @"C:\Program Files\symmetric-server-3.9.15\";

            bool condition = this.client1Node.Write(path);

            Assert.IsTrue(condition);
        }
    }
}

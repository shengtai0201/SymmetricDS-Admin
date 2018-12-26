using Shengtai;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SymmetricDS.Admin.ConsoleApp
{
    public class MasterNode : Node, IMaster
    {
        private readonly Server.Node node;

        public MasterNode(Databases database, Server.Node node) : base(database, node)
        {
            this.node = node;
            this.MasterNode = this;
        }

        public ICollection<string> Register(string path, IConfiguration configuration)
        {
            ICollection<string> result = new List<string>();

            var router = this.node.Router.SingleOrDefault(x => x.ProjectId == this.node.NodeGroup.ProjectId);
            foreach (Server.Node n in router.SourceNodeGroup.Node)
            {
                string groupId = n.NodeGroup.NodeGroupId;
                string externalId = n.ExternalId;
                result.Add(externalId);

                this.Register(path, configuration, groupId, externalId);
            }

            return result;
        }

        private void Register(string path, IConfiguration configuration, string groupId, string externalId)
        {
            string fileName = Path.GetFullPath(path + @"bin\symadmin.bat");

            Extensions.ProcessStart(fileName, $"--engine {configuration.EngineName} open-registration {groupId} {externalId}");
        }
    }
}
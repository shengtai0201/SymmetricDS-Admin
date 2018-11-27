using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Shengtai;
using SymmetricDS.Admin.Server;

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

        public void Register(string path, IConfiguration configuration)
        {
            var router = this.node.Router.SingleOrDefault(x => x.ProjectId == this.node.NodeGroup.ProjectId);
            foreach (Server.Node n in router.SourceNodeGroup.Node)
            {
                string groupId = n.NodeGroup.NodeGroupId;
                string externalId = n.ExternalId;

                this.Register(path, configuration, groupId, externalId);
            }
        }

        private void Register(string path, IConfiguration configuration, string groupId, string externalId)
        {
            string fileName = Path.GetFullPath(path + @"bin\symadmin.bat");
            var engine = Path.GetFullPath(path + @"engines\" + configuration.EngineName + ".properties");

            DefaultExtensions.ProcessStart(fileName, $"--engine {engine} open-registration {groupId} {externalId}");
        }
    }
}

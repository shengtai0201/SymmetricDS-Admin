using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using SymmetricDS.Admin.Server;

namespace SymmetricDS.Admin.ConsoleApp
{
    public class MasterNode : Node, IStart
    {
        private readonly Server.Node node;
        private readonly string syncUrlPort;
        public MasterNode(Databases database, Server.Node node) : base(database, node)
        {
            this.node = node;
            this.MasterNode = this;
            this.syncUrlPort = node.SyncUrlPort;
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

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                Arguments = $"--engine {engine} open-registration {groupId} {externalId}"
            };

            Process process = Process.Start(startInfo);

            StreamReader reader = process.StandardOutput;
            string line = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                if (!string.IsNullOrEmpty(line))
                    Console.WriteLine(line);

                line = reader.ReadLine();
            }
            reader.Close();
            reader.Dispose();

            process.WaitForExit();
            process.Close();
            process.Dispose();
        }

        void IStart.Start(string path)
        {
            string fileName = Path.GetFullPath(path + @"bin\sym.bat");

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                Arguments = $"-port {this.syncUrlPort}"
            };

            Process process = Process.Start(startInfo);

            StreamReader reader = process.StandardOutput;
            string line = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                if (!string.IsNullOrEmpty(line))
                    Console.WriteLine(line);

                line = reader.ReadLine();
            }
            reader.Close();
            reader.Dispose();

            process.WaitForExit();
            process.Close();
            process.Dispose();
        }
    }
}

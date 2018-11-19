using Microsoft.EntityFrameworkCore;
using SymmetricDS.Admin.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.ConsoleApp
{
    public class Initialization : IInitialization
    {
        private readonly Databases database;
        private readonly ServerDbContext serverDbContext;

        public Initialization(Databases database, string connectionString)
        {
            this.database = database;
            this.serverDbContext = new ServerDbContext(database, connectionString);
        }

        //private readonly SymDbContext dbContext;
        //public Initialization(INode configuration)
        //{
        //    this.dbContext = new SymDbContext(configuration.ConnectionString);
        //}

        //public void Channel()
        //{
        //    throw new NotImplementedException();
        //}

        public void CreateTables(string path, IConfiguration configuration)
        {
            string fileName = Path.GetFullPath(path + @"bin\symadmin.bat");

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = $"--engine {configuration.EngineName} create-sym-tables"
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

        //public void Node()
        //{
        //    throw new NotImplementedException();
        //}

        public bool NodeGroups(INode node)
        {
            //var newNodeGroups = this.serverDbContext.NodeGroup.Where(ng => ng.ProjectId == node.ProjectId).ToList();
            return false;
        }

        //public void Relationship()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Router()
        //{
        //    throw new NotImplementedException();
        //}

        //public void SynchronizationMethod()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Trigger()
        //{
        //    throw new NotImplementedException();
        //}

        public Node GetNode(int nodeId)
        {
            Node result = null;

            var node = this.serverDbContext.Node
                .Include("NodeGroup")
                .Include("NodeGroup.Router").Include("NodeGroup.Router.TargetNode").Include("NodeGroup.Router.TargetNode.NodeGroup")
                .SingleOrDefault(n => n.Id == nodeId);
            if (node != null)
                result = new Node(this.database, node);

            return result;
        }
    }
}

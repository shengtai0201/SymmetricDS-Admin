using SymmetricDS.Admin.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin
{
    public class Initialization : IInitialization
    {
        private readonly SymDbContext dbContext;
        public Initialization(IConfiguration configuration)
        {
            this.dbContext = new SymDbContext(configuration.ConnectionString);
        }

        public void Channel()
        {
            throw new NotImplementedException();
        }

        public void CreateTables(string path, IConfigurationProperty configuration)
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

        public void Node()
        {
            throw new NotImplementedException();
        }

        public bool NodeGroup(KeyValuePair<string, string> master, IDictionary<string, string> clients)
        {
            var masterNodeGroup = new sym_node_group
            {
                node_group_id = master.Key,
                description = master.Value
            };
            this.dbContext.sym_node_group.Add(masterNodeGroup);

            foreach(var client in clients)
            {
                var clientNodeGroup = new sym_node_group
                {
                    node_group_id = client.Key,
                    description = client.Value
                };
                this.dbContext.sym_node_group.Add(clientNodeGroup);
            }

            bool result = false;
            try
            {
                this.dbContext.SaveChanges();
                result = true;
            }
            catch { }

            return result;
        }

        public void Relationship()
        {
            throw new NotImplementedException();
        }

        public void Router()
        {
            throw new NotImplementedException();
        }

        public void SynchronizationMethod()
        {
            throw new NotImplementedException();
        }

        public void Trigger()
        {
            throw new NotImplementedException();
        }
    }
}

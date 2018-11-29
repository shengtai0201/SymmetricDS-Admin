using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shengtai;
using SymmetricDS.Admin.Master;
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
    public class NpgsqlInitializationService : NpgsqlRepository<MasterDbContext, ConnectionStrings>, IInitializationService
    {
        private readonly Databases database;
        private readonly MasterDbContext masterDbContext;
        private readonly ServerDbContext serverDbContext;

        public NpgsqlInitializationService(MasterDbContext masterDbContext, ServerDbContext serverDbContext, IOptions<AppSettings> options) : base(options.Value, masterDbContext)
        {
            this.database = options.Value.Database;
            this.masterDbContext = masterDbContext;
            this.serverDbContext = serverDbContext;
        }

        public bool Channel()
        {
            return InitializationService.Channel(this.masterDbContext, this.serverDbContext);
        }

        public void CreateTables(string path, IConfiguration configuration)
        {
            InitializationService.CreateTables(path, configuration);
        }

        public bool Node(INode node)
        {
            return InitializationService.Node(node, this.masterDbContext);
        }

        public bool NodeGroups(INode node)
        {
            return InitializationService.NodeGroups(node, this.masterDbContext, this.serverDbContext);
        }

        public bool Relationship()
        {
            return InitializationService.Relationship(this.masterDbContext, this.serverDbContext);
        }

        public bool Router()
        {
            return InitializationService.Router(this.masterDbContext, this.serverDbContext);
        }

        public bool SynchronizationMethod(INode node)
        {
            return InitializationService.SynchronizationMethod(node, this.masterDbContext, this.serverDbContext);
        }

        public bool Triggers()
        {
            return InitializationService.Triggers(this.masterDbContext, this.serverDbContext);
        }

        public Node GetNode(int nodeId)
        {
            return InitializationService.GetNode(nodeId, this.serverDbContext, this.database);
        }

        public bool CheckTables()
        {
            string cmdText = @"SELECT COUNT(*) 
                FROM
	                information_schema.tables 
                WHERE
	                table_schema = 'public' 
	                AND table_type = 'BASE TABLE' 
	                AND TABLE_NAME LIKE'sym_%'";
            var result = this.ExecuteScalar<int>(cmdText);

            return result == 47;
        }

        public void StartService(string path)
        {
            InitializationService.StartService(path);
        }

        public void InstallService(string path)
        {
            InitializationService.InstallService(path);
        }

        public void StopService(string path)
        {
            InitializationService.StopService(path);
        }

        public void UninstallService(string path)
        {
            InitializationService.UninstallService(path);
        }

        public void RunOnlyOnce(string path, string syncUrlPort)
        {
            InitializationService.RunOnlyOnce(path, syncUrlPort);
        }
    }
}

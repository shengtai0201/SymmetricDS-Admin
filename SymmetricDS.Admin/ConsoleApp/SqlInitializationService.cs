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
    public class SqlInitializationService : SqlRepository<MasterDbContext, ConnectionStrings>, IInitializationService
    {
        private readonly Databases database;
        private readonly DbContextOptions<MasterDbContext> masterDbContextOptions;
        private readonly DbContextOptions<ServerDbContext> serverDbContextOptions;
        private readonly IOptions<AppSettings> options;

        public SqlInitializationService(DbContextOptions<MasterDbContext> masterDbContextOptions, DbContextOptions<ServerDbContext> serverDbContextOptions, IOptions<AppSettings> options) : base(options.Value, new MasterDbContext(masterDbContextOptions, options))
        {
            this.database = options.Value.Database;
            this.masterDbContextOptions = masterDbContextOptions;
            this.serverDbContextOptions = serverDbContextOptions;
            this.options = options;
        }

        public bool Channel()
        {
            return InitializationService.Channel(new MasterDbContext(this.masterDbContextOptions, this.options), new ServerDbContext(this.serverDbContextOptions));
        }

        public void CreateTables(string path, IConfiguration configuration)
        {
            InitializationService.CreateTables(path, configuration);
        }

        public bool Node(INode node)
        {
            return InitializationService.Node(node, new MasterDbContext(this.masterDbContextOptions, this.options));
        }

        public bool NodeGroups(INode node)
        {
            return InitializationService.NodeGroups(node, new MasterDbContext(this.masterDbContextOptions, this.options), new ServerDbContext(this.serverDbContextOptions));
        }

        public bool Relationship()
        {
            return InitializationService.Relationship(new MasterDbContext(this.masterDbContextOptions, this.options), new ServerDbContext(this.serverDbContextOptions));
        }

        public bool Router()
        {
            return InitializationService.Router(new MasterDbContext(this.masterDbContextOptions, this.options), new ServerDbContext(this.serverDbContextOptions));
        }

        public bool SynchronizationMethod(INode node)
        {
            return InitializationService.SynchronizationMethod(node, new MasterDbContext(this.masterDbContextOptions, this.options), new ServerDbContext(this.serverDbContextOptions));
        }

        public bool Triggers()
        {
            return InitializationService.Triggers(new MasterDbContext(this.masterDbContextOptions, this.options), new ServerDbContext(this.serverDbContextOptions));
        }

        public Node GetNode(int nodeId)
        {
            return InitializationService.GetNode(nodeId, new ServerDbContext(this.serverDbContextOptions), this.database);
        }

        public bool CheckTables()
        {
            string cmdText = @"SELECT COUNT(*) 
                FROM
	                information_schema.tables 
                WHERE
	                table_schema = 'dbo' 
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

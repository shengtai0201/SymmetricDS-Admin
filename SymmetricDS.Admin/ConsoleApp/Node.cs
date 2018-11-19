using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.ConsoleApp
{
    public class Node : INode, IConfiguration
    {
        public string EngineName { get; set; }
        public string DbDriver { get; set; }
        public string DbUrl { get; set; }
        public string DbUser { get; set; }
        public string DbPassword { get; set; }
        public string RegistrationUrl { get; set; }
        public string SyncUrl { get; set; }
        public string GroupId { get; set; }
        public string ExternalId { get; set; }
        public int JobPurgePeriodTimeMs { get; set; }
        public int JobRoutingPeriodTimeMs { get; set; }
        public int JobPushPeriodTimeMs { get; set; }
        public int JobPullPeriodTimeMs { get; set; }
        public bool InitialLoadCreateFirst { get; set; }

        public string ConnectionString { get; set; }
        public int Version { get; set; }
        public int ProjectId { get; set; }
        public string Password { get; set; }

        public Node(Databases database, Server.Node node)
        {
            this.Version = node.Version;
            this.Password = node.NodePassword;

            this.GroupId = node.NodeGroup.NodeGroupId;
            this.EngineName = this.GroupId + "-" + node.ExternalId;
            this.DbDriver = this.GetDbDriver(database);
            this.DbUrl = this.GetDbUrl(database, node.DatabaseHost, node.DatabaseName);
            this.DbUser = node.DatabaseUser;
            this.DbPassword = node.DatabasePassword;
            this.SyncUrl = string.Format("http://{0}:{1}/sync/{2}", node.DatabaseHost, node.SyncUrlPort, this.EngineName);
            this.ExternalId = node.ExternalId;
            this.JobPurgePeriodTimeMs = node.JobPurgePeriodTimeMs ?? 7200000;
            this.JobRoutingPeriodTimeMs = node.JobRoutingPeriodTimeMs ?? 5000;
            this.JobPushPeriodTimeMs = node.JobPushPeriodTimeMs ?? 10000;
            this.JobPullPeriodTimeMs = node.JobPullPeriodTimeMs ?? 10000;
            this.InitialLoadCreateFirst = node.InitialLoadCreateFirst;

            // Router 的 Source 是 NodeGroup 集合陣列，Target 是單一個 Node
            this.ProjectId = node.NodeGroup.ProjectId;
            var router = node.NodeGroup.Router.SingleOrDefault(x => x.ProjectId == this.ProjectId);
            if (router != null)
            {
                var targetEngineName = router.TargetNode.NodeGroup.NodeGroupId + "-" + router.TargetNode.ExternalId;
                this.RegistrationUrl = string.Format("http://{0}:{1}/sync/{2}", router.TargetNode.DatabaseHost, router.TargetNode.SyncUrlPort, targetEngineName);
            }
        }

        //public Node(Databases database, string dbHost, string db, string dbUser, string dbPassword,
        //    string syncUrlPort, NodeGroup group, string externalId,
        //    int jobPurgePeriodTimeMs = 7200000, int jobRoutingPeriodTimeMs = 5000, int jobPushPeriodTimeMs = 10000,
        //    int jobPullPeriodTimeMs = 10000, bool initialLoadCreateFirst = true)
        //{
        //    this.EngineName = group.GroupId + "-" + externalId;
        //    this.DbDriver = this.GetDbDriver(database);
        //    this.DbUrl = this.GetDbUrl(database, dbHost, db);
        //    this.DbUser = dbUser;
        //    this.DbPassword = dbPassword;
        //    this.SyncUrl = string.Format("http://{0}:{1}/sync/{2}", dbHost, syncUrlPort, this.EngineName);
        //    this.Group = group;
        //    this.ExternalId = externalId;
        //    this.JobPurgePeriodTimeMs = jobPurgePeriodTimeMs;
        //    this.JobRoutingPeriodTimeMs = jobRoutingPeriodTimeMs;
        //    this.JobPushPeriodTimeMs = jobPushPeriodTimeMs;
        //    this.JobPullPeriodTimeMs = jobPullPeriodTimeMs;
        //    this.InitialLoadCreateFirst = initialLoadCreateFirst;

        //    this.ConnectionString = this.GetConnectionString(database, dbHost, db);
        //}

        //public Node(IConfiguration masterNode,
        //    Databases database, string dbHost, string db, string dbUser, string dbPassword,
        //    string syncUrlPort, NodeGroup group, string externalId,
        //    int jobPurgePeriodTimeMs = 7200000, int jobRoutingPeriodTimeMs = 5000, int jobPushPeriodTimeMs = 10000,
        //    int jobPullPeriodTimeMs = 10000, bool initialLoadCreateFirst = true) : this(database, dbHost, db, dbUser, dbPassword,
        //        syncUrlPort, group, externalId,
        //        jobPurgePeriodTimeMs, jobRoutingPeriodTimeMs, jobPushPeriodTimeMs,
        //        jobPullPeriodTimeMs, initialLoadCreateFirst)
        //{
        //    this.RegistrationUrl = masterNode.SyncUrl;
        //}

        private string GetConnectionString(Databases database, string dbHost, string db)
        {
            switch (database)
            {
                case Databases.SQLServer:
                    return string.Format("Server={0};Database={1};User Id={2};Password={3};", dbHost, db, this.DbUser, this.DbPassword);
                default:
                    return null;
            }
        }

        private string GetDbUrl(Databases database, string dbHost, string db)
        {
            switch (database)
            {
                case Databases.SQLServer:
                    return string.Format("jdbc:jtds:sqlserver://{0}:1433/{1}", dbHost, db);
                case Databases.Oracle:
                    return string.Format("jdbc:oracle:thin:@{0}:1521:{1}", dbHost, db);
                case Databases.PostgreSQL:
                    return string.Format("jdbc:postgresql://{0}:5432/{1}", dbHost, db);
                default:
                    return null;
            }
        }

        private string GetDbDriver(Databases database)
        {
            switch (database)
            {
                case Databases.SQLServer:
                    return "net.sourceforge.jtds.jdbc.Driver";
                case Databases.Oracle:
                    return "oracle.jdbc.driver.OracleDriver";
                case Databases.PostgreSQL:
                    return "org.postgresql.Driver";
                default:
                    return null;
            }
        }

        public bool CopyTo(string path)
        {
            string sourceFileName = Path.GetFullPath(path + @"samples\corp-000.properties");

            string destFileName = Path.GetFullPath(path + string.Format(@"engines\{0}.properties", this.EngineName));
            if (File.Exists(destFileName))
                File.Delete(destFileName);

            File.Copy(sourceFileName, destFileName);

            return File.Exists(destFileName);
        }

        public bool Write(string path)
        {
            bool result = false;
            try
            {
                path = Path.GetFullPath(path + string.Format(@"engines\{0}.properties", this.EngineName));

                string contents = File.ReadAllText(path);
                this.ReadStartsWithReplace(ref contents, path, "engine.name=", this.EngineName);
                this.ReadStartsWithReplace(ref contents, path, "db.driver=", this.DbDriver);
                this.ReadStartsWithReplace(ref contents, path, "db.url=", this.DbUrl);
                this.ReadStartsWithReplace(ref contents, path, "db.user=", this.DbUser);
                this.ReadStartsWithReplace(ref contents, path, "db.password=", this.DbPassword);
                this.ReadStartsWithReplace(ref contents, path, "registration.url=", this.RegistrationUrl);
                this.ReadStartsWithReplace(ref contents, path, "sync.url=", this.SyncUrl);
                this.ReadStartsWithReplace(ref contents, path, "group.id=", this.GroupId);
                this.ReadStartsWithReplace(ref contents, path, "external.id=", this.ExternalId);
                this.ReadStartsWithReplace(ref contents, path, "job.purge.period.time.ms=", this.JobPurgePeriodTimeMs);
                this.ReadStartsWithReplace(ref contents, path, "job.routing.period.time.ms=", this.JobRoutingPeriodTimeMs);
                this.ReadStartsWithReplace(ref contents, path, "job.push.period.time.ms=", this.JobPushPeriodTimeMs);
                this.ReadStartsWithReplace(ref contents, path, "job.pull.period.time.ms=", this.JobPullPeriodTimeMs);
                this.ReadStartsWithReplace(ref contents, path, "initial.load.create.first=", this.InitialLoadCreateFirst);

                File.WriteAllText(path, contents);
                result = true;
            }
            catch { }

            return result;
        }

        private void ReadStartsWithReplace(ref string contents, string path, string oldValue, bool newValue)
        {
            this.ReadStartsWithReplace(ref contents, path, oldValue, newValue.ToString().ToLower());
        }

        private void ReadStartsWithReplace(ref string contents, string path, string oldValue, int newValue)
        {
            this.ReadStartsWithReplace(ref contents, path, oldValue, newValue.ToString());
        }

        private void ReadStartsWithReplace(ref string contents, string path, string oldValue, string newValue)
        {
            if (!string.IsNullOrEmpty(newValue))
            {
                var line = this.ReadStartsWith(path, oldValue);
                if (!string.IsNullOrEmpty(line))
                    contents = contents.Replace(line, oldValue + newValue);
            }
        }

        private string ReadStartsWith(string path, string value)
        {
            foreach (var line in File.ReadAllLines(path))
                if (line.StartsWith(value))
                    return line;

            return null;
        }
    }
}

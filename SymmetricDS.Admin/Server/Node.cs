using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Server
{
    public partial class Node
    {
        public int Id { get; set; }
        public int NodeGroupId { get; set; }
        public int? DatabaseType { get; set; }
        public string DatabaseHost { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseUser { get; set; }
        public string DatabasePassword { get; set; }
        public string SyncUrlPort { get; set; }
        public string ExternalId { get; set; }
        public int? JobPurgePeriodTimeMs { get; set; }
        public int? JobRoutingPeriodTimeMs { get; set; }
        public int? JobPushPeriodTimeMs { get; set; }
        public int? JobPullPeriodTimeMs { get; set; }
        public bool? InitialLoadCreateFirst { get; set; }
        public string NodePassword { get; set; }
        public int Version { get; set; }

        public NodeGroup NodeGroup { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymNode
    {
        public string NodeId { get; set; }
        public string NodeGroupId { get; set; }
        public string ExternalId { get; set; }
        public DateTime? HeartbeatTime { get; set; }
        public string TimezoneOffset { get; set; }
        public short? SyncEnabled { get; set; }
        public string SyncUrl { get; set; }
        public string SchemaVersion { get; set; }
        public string SymmetricVersion { get; set; }
        public string ConfigVersion { get; set; }
        public string DatabaseType { get; set; }
        public string DatabaseVersion { get; set; }
        public int? BatchToSendCount { get; set; }
        public int? BatchInErrorCount { get; set; }
        public string CreatedAtNodeId { get; set; }
        public string DeploymentType { get; set; }
        public string DeploymentSubType { get; set; }

        public SymNodeIdentity SymNodeIdentity { get; set; }
        public SymNodeSecurity SymNodeSecurity { get; set; }
    }
}

namespace SymmetricDS.Admin.Server
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Node")]
    public partial class Node
    {
        public int Id { get; set; }

        public int NodeGroupId { get; set; }

        public int? DatabaseType { get; set; }

        [StringLength(16)]
        public string DatabaseHost { get; set; }

        [StringLength(16)]
        public string DatabaseName { get; set; }

        [StringLength(16)]
        public string DatabaseUser { get; set; }

        [StringLength(16)]
        public string DatabasePassword { get; set; }

        [StringLength(4)]
        public string SyncUrlPort { get; set; }

        [Required]
        [StringLength(8)]
        public string ExternalId { get; set; }

        public int? JobPurgePeriodTimeMs { get; set; }

        public int? JobRoutingPeriodTimeMs { get; set; }

        public int? JobPushPeriodTimeMs { get; set; }

        public int? JobPullPeriodTimeMs { get; set; }

        public bool InitialLoadCreateFirst { get; set; }

        [StringLength(50)]
        public string NodePassword { get; set; }

        public int Version { get; set; }

        public virtual NodeGroup NodeGroup { get; set; }
    }
}

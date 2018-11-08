namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_node
    {
        [Key]
        [StringLength(50)]
        public string node_id { get; set; }

        [Required]
        [StringLength(50)]
        public string node_group_id { get; set; }

        [Required]
        [StringLength(255)]
        public string external_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? heartbeat_time { get; set; }

        [StringLength(6)]
        public string timezone_offset { get; set; }

        public short? sync_enabled { get; set; }

        [StringLength(255)]
        public string sync_url { get; set; }

        [StringLength(50)]
        public string schema_version { get; set; }

        [StringLength(50)]
        public string symmetric_version { get; set; }

        [StringLength(50)]
        public string config_version { get; set; }

        [StringLength(50)]
        public string database_type { get; set; }

        [StringLength(50)]
        public string database_version { get; set; }

        public int? batch_to_send_count { get; set; }

        public int? batch_in_error_count { get; set; }

        [StringLength(50)]
        public string created_at_node_id { get; set; }

        [StringLength(50)]
        public string deployment_type { get; set; }

        [StringLength(50)]
        public string deployment_sub_type { get; set; }

        public virtual sym_node_identity sym_node_identity { get; set; }

        public virtual sym_node_security sym_node_security { get; set; }
    }
}

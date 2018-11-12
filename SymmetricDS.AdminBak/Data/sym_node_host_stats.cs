namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_node_host_stats
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string node_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(60)]
        public string host_name { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "datetime2")]
        public DateTime start_time { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "datetime2")]
        public DateTime end_time { get; set; }

        public long restarted { get; set; }

        public long? nodes_pulled { get; set; }

        public long? total_nodes_pull_time { get; set; }

        public long? nodes_pushed { get; set; }

        public long? total_nodes_push_time { get; set; }

        public long? nodes_rejected { get; set; }

        public long? nodes_registered { get; set; }

        public long? nodes_loaded { get; set; }

        public long? nodes_disabled { get; set; }

        public long? purged_data_rows { get; set; }

        public long? purged_data_event_rows { get; set; }

        public long? purged_batch_outgoing_rows { get; set; }

        public long? purged_batch_incoming_rows { get; set; }

        public long? triggers_created_count { get; set; }

        public long? triggers_rebuilt_count { get; set; }

        public long? triggers_removed_count { get; set; }
    }
}

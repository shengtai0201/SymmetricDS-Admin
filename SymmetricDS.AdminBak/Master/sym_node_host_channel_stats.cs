namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_node_host_channel_stats
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
        [Column(Order = 2)]
        public string channel_id { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "datetime2")]
        public DateTime start_time { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "datetime2")]
        public DateTime end_time { get; set; }

        public long? data_routed { get; set; }

        public long? data_unrouted { get; set; }

        public long? data_event_inserted { get; set; }

        public long? data_extracted { get; set; }

        public long? data_bytes_extracted { get; set; }

        public long? data_extracted_errors { get; set; }

        public long? data_bytes_sent { get; set; }

        public long? data_sent { get; set; }

        public long? data_sent_errors { get; set; }

        public long? data_loaded { get; set; }

        public long? data_bytes_loaded { get; set; }

        public long? data_loaded_errors { get; set; }
    }
}

namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_node_host_job_stats
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
        [StringLength(50)]
        public string job_name { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "datetime2")]
        public DateTime start_time { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "datetime2")]
        public DateTime end_time { get; set; }

        public long? processed_count { get; set; }

        [StringLength(50)]
        public string target_node_id { get; set; }

        public int? target_node_count { get; set; }
    }
}

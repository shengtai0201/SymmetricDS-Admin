namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_node_host
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string node_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(60)]
        public string host_name { get; set; }

        [StringLength(60)]
        public string instance_id { get; set; }

        [StringLength(50)]
        public string ip_address { get; set; }

        [StringLength(50)]
        public string os_user { get; set; }

        [StringLength(50)]
        public string os_name { get; set; }

        [StringLength(50)]
        public string os_arch { get; set; }

        [StringLength(50)]
        public string os_version { get; set; }

        public int? available_processors { get; set; }

        public long? free_memory_bytes { get; set; }

        public long? total_memory_bytes { get; set; }

        public long? max_memory_bytes { get; set; }

        [StringLength(50)]
        public string java_version { get; set; }

        [StringLength(255)]
        public string java_vendor { get; set; }

        [StringLength(255)]
        public string jdbc_version { get; set; }

        [StringLength(50)]
        public string symmetric_version { get; set; }

        [StringLength(6)]
        public string timezone_offset { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? heartbeat_time { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_restart_time { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime create_time { get; set; }
    }
}

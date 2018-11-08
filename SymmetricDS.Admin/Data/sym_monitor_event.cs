namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_monitor_event
    {
        [Key]
        [Column(Order = 0)]
        public string monitor_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string node_id { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "datetime2")]
        public DateTime event_time { get; set; }

        [StringLength(60)]
        public string host_name { get; set; }

        [Required]
        [StringLength(50)]
        public string type { get; set; }

        public long threshold { get; set; }

        public long event_value { get; set; }

        public int event_count { get; set; }

        public int severity_level { get; set; }

        public short is_resolved { get; set; }

        public short is_notified { get; set; }

        [Column(TypeName = "text")]
        public string details { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_update_time { get; set; }
    }
}

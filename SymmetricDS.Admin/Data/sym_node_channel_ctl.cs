namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_node_channel_ctl
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string node_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string channel_id { get; set; }

        public short? suspend_enabled { get; set; }

        public short? ignore_enabled { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_extract_time { get; set; }
    }
}

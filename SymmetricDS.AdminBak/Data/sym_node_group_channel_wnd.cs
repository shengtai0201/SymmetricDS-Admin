namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_node_group_channel_wnd
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string node_group_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string channel_id { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "datetime2")]
        public DateTime start_time { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "datetime2")]
        public DateTime end_time { get; set; }

        public short enabled { get; set; }
    }
}

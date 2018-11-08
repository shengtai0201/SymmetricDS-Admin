namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_table_reload_request
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string target_node_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string source_node_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public string trigger_id { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string router_id { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "datetime2")]
        public DateTime create_time { get; set; }

        public short create_table { get; set; }

        public short delete_first { get; set; }

        [Column(TypeName = "text")]
        public string reload_select { get; set; }

        [Column(TypeName = "text")]
        public string before_custom_sql { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? reload_time { get; set; }

        public long? load_id { get; set; }

        public short processed { get; set; }

        [StringLength(128)]
        public string channel_id { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_update_time { get; set; }
    }
}

namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_data
    {
        [Key]
        public long data_id { get; set; }

        [Required]
        [StringLength(255)]
        public string table_name { get; set; }

        [Required]
        [StringLength(1)]
        public string event_type { get; set; }

        [Column(TypeName = "text")]
        public string row_data { get; set; }

        [Column(TypeName = "text")]
        public string pk_data { get; set; }

        [Column(TypeName = "text")]
        public string old_data { get; set; }

        public int trigger_hist_id { get; set; }

        [StringLength(128)]
        public string channel_id { get; set; }

        [StringLength(255)]
        public string transaction_id { get; set; }

        [StringLength(50)]
        public string source_node_id { get; set; }

        [StringLength(50)]
        public string external_data { get; set; }

        [StringLength(255)]
        public string node_list { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }
    }
}

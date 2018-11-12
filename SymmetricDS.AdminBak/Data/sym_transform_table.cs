namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_transform_table
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string transform_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string source_node_group_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string target_node_group_id { get; set; }

        [Required]
        [StringLength(10)]
        public string transform_point { get; set; }

        [StringLength(255)]
        public string source_catalog_name { get; set; }

        [StringLength(255)]
        public string source_schema_name { get; set; }

        [Required]
        [StringLength(255)]
        public string source_table_name { get; set; }

        [StringLength(255)]
        public string target_catalog_name { get; set; }

        [StringLength(255)]
        public string target_schema_name { get; set; }

        [StringLength(255)]
        public string target_table_name { get; set; }

        public short? update_first { get; set; }

        [Required]
        [StringLength(255)]
        public string update_action { get; set; }

        [Required]
        [StringLength(10)]
        public string delete_action { get; set; }

        public int transform_order { get; set; }

        [Required]
        [StringLength(10)]
        public string column_policy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_update_time { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public virtual sym_node_group_link sym_node_group_link { get; set; }
    }
}

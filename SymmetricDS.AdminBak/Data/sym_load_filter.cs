namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_load_filter
    {
        [Key]
        [StringLength(50)]
        public string load_filter_id { get; set; }

        [Required]
        [StringLength(10)]
        public string load_filter_type { get; set; }

        [Required]
        [StringLength(50)]
        public string source_node_group_id { get; set; }

        [Required]
        [StringLength(50)]
        public string target_node_group_id { get; set; }

        [StringLength(255)]
        public string target_catalog_name { get; set; }

        [StringLength(255)]
        public string target_schema_name { get; set; }

        [StringLength(255)]
        public string target_table_name { get; set; }

        public short filter_on_update { get; set; }

        public short filter_on_insert { get; set; }

        public short filter_on_delete { get; set; }

        [Column(TypeName = "text")]
        public string before_write_script { get; set; }

        [Column(TypeName = "text")]
        public string after_write_script { get; set; }

        [Column(TypeName = "text")]
        public string batch_complete_script { get; set; }

        [Column(TypeName = "text")]
        public string batch_commit_script { get; set; }

        [Column(TypeName = "text")]
        public string batch_rollback_script { get; set; }

        [Column(TypeName = "text")]
        public string handle_error_script { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_update_time { get; set; }

        public int load_filter_order { get; set; }

        public short fail_on_error { get; set; }
    }
}

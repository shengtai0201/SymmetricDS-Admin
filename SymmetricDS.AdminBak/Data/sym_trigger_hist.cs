namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_trigger_hist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int trigger_hist_id { get; set; }

        [Required]
        [StringLength(128)]
        public string trigger_id { get; set; }

        [Required]
        [StringLength(255)]
        public string source_table_name { get; set; }

        [StringLength(255)]
        public string source_catalog_name { get; set; }

        [StringLength(255)]
        public string source_schema_name { get; set; }

        [StringLength(255)]
        public string name_for_update_trigger { get; set; }

        [StringLength(255)]
        public string name_for_insert_trigger { get; set; }

        [StringLength(255)]
        public string name_for_delete_trigger { get; set; }

        public long table_hash { get; set; }

        public long trigger_row_hash { get; set; }

        public long trigger_template_hash { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string column_names { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string pk_column_names { get; set; }

        [Required]
        [StringLength(1)]
        public string last_trigger_build_reason { get; set; }

        [Column(TypeName = "text")]
        public string error_message { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime create_time { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? inactive_time { get; set; }
    }
}

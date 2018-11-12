namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_incoming_error
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long batch_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string node_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long failed_row_number { get; set; }

        public long failed_line_number { get; set; }

        [StringLength(255)]
        public string target_catalog_name { get; set; }

        [StringLength(255)]
        public string target_schema_name { get; set; }

        [Required]
        [StringLength(255)]
        public string target_table_name { get; set; }

        [Required]
        [StringLength(1)]
        public string event_type { get; set; }

        [Required]
        [StringLength(10)]
        public string binary_encoding { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string column_names { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string pk_column_names { get; set; }

        [Column(TypeName = "text")]
        public string row_data { get; set; }

        [Column(TypeName = "text")]
        public string old_data { get; set; }

        [Column(TypeName = "text")]
        public string cur_data { get; set; }

        [Column(TypeName = "text")]
        public string resolve_data { get; set; }

        public short? resolve_ignore { get; set; }

        [StringLength(50)]
        public string conflict_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_update_time { get; set; }
    }
}

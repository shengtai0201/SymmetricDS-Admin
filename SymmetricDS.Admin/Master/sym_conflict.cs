namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_conflict
    {
        [Key]
        [StringLength(50)]
        public string conflict_id { get; set; }

        [Required]
        [StringLength(50)]
        public string source_node_group_id { get; set; }

        [Required]
        [StringLength(50)]
        public string target_node_group_id { get; set; }

        [StringLength(128)]
        public string target_channel_id { get; set; }

        [StringLength(255)]
        public string target_catalog_name { get; set; }

        [StringLength(255)]
        public string target_schema_name { get; set; }

        [StringLength(255)]
        public string target_table_name { get; set; }

        [Required]
        [StringLength(128)]
        public string detect_type { get; set; }

        [Column(TypeName = "text")]
        public string detect_expression { get; set; }

        [Required]
        [StringLength(128)]
        public string resolve_type { get; set; }

        [Required]
        [StringLength(128)]
        public string ping_back { get; set; }

        public short? resolve_changes_only { get; set; }

        public short? resolve_row_only { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_update_time { get; set; }

        public virtual sym_node_group_link sym_node_group_link { get; set; }
    }
}

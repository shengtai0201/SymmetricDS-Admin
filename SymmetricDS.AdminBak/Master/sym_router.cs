namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_router
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sym_router()
        {
            sym_file_trigger_router = new HashSet<sym_file_trigger_router>();
            sym_trigger_router = new HashSet<sym_trigger_router>();
        }

        [Key]
        [StringLength(50)]
        public string router_id { get; set; }

        [StringLength(255)]
        public string target_catalog_name { get; set; }

        [StringLength(255)]
        public string target_schema_name { get; set; }

        [StringLength(255)]
        public string target_table_name { get; set; }

        [Required]
        [StringLength(50)]
        public string source_node_group_id { get; set; }

        [Required]
        [StringLength(50)]
        public string target_node_group_id { get; set; }

        [StringLength(50)]
        public string router_type { get; set; }

        [Column(TypeName = "text")]
        public string router_expression { get; set; }

        public short sync_on_update { get; set; }

        public short sync_on_insert { get; set; }

        public short sync_on_delete { get; set; }

        public short use_source_catalog_schema { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_update_time { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sym_file_trigger_router> sym_file_trigger_router { get; set; }

        public virtual sym_node_group_link sym_node_group_link { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sym_trigger_router> sym_trigger_router { get; set; }
    }
}

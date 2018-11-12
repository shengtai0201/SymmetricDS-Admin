namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_node_group_link
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sym_node_group_link()
        {
            sym_conflict = new HashSet<sym_conflict>();
            sym_router = new HashSet<sym_router>();
            sym_transform_table = new HashSet<sym_transform_table>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string source_node_group_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string target_node_group_id { get; set; }

        [Required]
        [StringLength(1)]
        public string data_event_action { get; set; }

        public short sync_config_enabled { get; set; }

        public short is_reversible { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_update_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sym_conflict> sym_conflict { get; set; }

        public virtual sym_node_group sym_node_group { get; set; }

        public virtual sym_node_group sym_node_group1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sym_router> sym_router { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sym_transform_table> sym_transform_table { get; set; }
    }
}

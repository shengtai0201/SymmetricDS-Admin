namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_node_group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sym_node_group()
        {
            sym_node_group_link = new HashSet<sym_node_group_link>();
            sym_node_group_link1 = new HashSet<sym_node_group_link>();
        }

        [Key]
        [StringLength(50)]
        public string node_group_id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_update_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sym_node_group_link> sym_node_group_link { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sym_node_group_link> sym_node_group_link1 { get; set; }
    }
}

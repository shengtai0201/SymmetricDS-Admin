namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_grouplet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sym_grouplet()
        {
            sym_grouplet_link = new HashSet<sym_grouplet_link>();
            sym_trigger_router_grouplet = new HashSet<sym_trigger_router_grouplet>();
        }

        [Key]
        [StringLength(50)]
        public string grouplet_id { get; set; }

        [Required]
        [StringLength(1)]
        public string grouplet_link_policy { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_update_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sym_grouplet_link> sym_grouplet_link { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sym_trigger_router_grouplet> sym_trigger_router_grouplet { get; set; }
    }
}

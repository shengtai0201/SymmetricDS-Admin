namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_trigger_router
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sym_trigger_router()
        {
            sym_trigger_router_grouplet = new HashSet<sym_trigger_router_grouplet>();
        }

        [Key]
        [Column(Order = 0)]
        public string trigger_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string router_id { get; set; }

        public short enabled { get; set; }

        public int initial_load_order { get; set; }

        [Column(TypeName = "text")]
        public string initial_load_select { get; set; }

        [Column(TypeName = "text")]
        public string initial_load_delete_stmt { get; set; }

        public short ping_back_enabled { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_update_time { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public virtual sym_router sym_router { get; set; }

        public virtual sym_trigger sym_trigger { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sym_trigger_router_grouplet> sym_trigger_router_grouplet { get; set; }
    }
}

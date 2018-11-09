namespace SymmetricDS.Admin.Server
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Router")]
    public partial class Router
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Router()
        {
            Triggers = new HashSet<Trigger>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RouterId { get; set; }

        public int? SourceNodeGroupId { get; set; }

        public int? TargetNodeGroupId { get; set; }

        public virtual NodeGroup NodeGroup { get; set; }

        public virtual NodeGroup NodeGroup1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trigger> Triggers { get; set; }
    }
}

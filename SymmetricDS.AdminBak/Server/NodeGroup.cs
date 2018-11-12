namespace SymmetricDS.Admin.Server
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NodeGroup")]
    public partial class NodeGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NodeGroup()
        {
            Nodes = new HashSet<Node>();
            Routers = new HashSet<Router>();
            Routers1 = new HashSet<Router>();
        }

        public int Id { get; set; }

        public int ProjectId { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string NodeGroupId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Node> Nodes { get; set; }

        public virtual Project Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Router> Routers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Router> Routers1 { get; set; }
    }
}

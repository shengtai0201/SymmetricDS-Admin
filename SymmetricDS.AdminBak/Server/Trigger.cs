namespace SymmetricDS.Admin.Server
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trigger")]
    public partial class Trigger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trigger()
        {
            Routers = new HashSet<Router>();
        }

        public int Id { get; set; }

        public int ChannelId { get; set; }

        [Required]
        [StringLength(128)]
        public string TriggerId { get; set; }

        [StringLength(255)]
        public string SourceTableName { get; set; }

        public virtual Channel Channel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Router> Routers { get; set; }
    }
}

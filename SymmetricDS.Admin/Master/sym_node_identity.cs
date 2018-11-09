namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_node_identity
    {
        [Key]
        [StringLength(50)]
        public string node_id { get; set; }

        public virtual sym_node sym_node { get; set; }
    }
}

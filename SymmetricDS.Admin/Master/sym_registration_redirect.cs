namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_registration_redirect
    {
        [Key]
        [StringLength(255)]
        public string registrant_external_id { get; set; }

        [Required]
        [StringLength(50)]
        public string registration_node_id { get; set; }
    }
}

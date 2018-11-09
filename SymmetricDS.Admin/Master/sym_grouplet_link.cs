namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_grouplet_link
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string grouplet_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string external_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_update_time { get; set; }

        public virtual sym_grouplet sym_grouplet { get; set; }
    }
}
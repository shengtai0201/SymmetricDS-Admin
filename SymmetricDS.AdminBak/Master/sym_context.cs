namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_context
    {
        [Key]
        [StringLength(80)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        public string context_value { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_update_time { get; set; }
    }
}

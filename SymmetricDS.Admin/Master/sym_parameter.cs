namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_parameter
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string external_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string node_group_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(80)]
        public string param_key { get; set; }

        [Column(TypeName = "text")]
        public string param_value { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_update_time { get; set; }
    }
}

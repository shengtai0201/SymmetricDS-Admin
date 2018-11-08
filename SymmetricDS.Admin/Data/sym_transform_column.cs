namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_transform_column
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string transform_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1)]
        public string include_on { get; set; }

        [Key]
        [Column(Order = 2)]
        public string target_column_name { get; set; }

        [StringLength(128)]
        public string source_column_name { get; set; }

        public short? pk { get; set; }

        [StringLength(50)]
        public string transform_type { get; set; }

        [Column(TypeName = "text")]
        public string transform_expression { get; set; }

        public int transform_order { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_update_time { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }
    }
}

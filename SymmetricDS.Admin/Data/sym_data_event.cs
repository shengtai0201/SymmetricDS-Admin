namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_data_event
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long data_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long batch_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string router_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }
    }
}

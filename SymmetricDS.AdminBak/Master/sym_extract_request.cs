namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_extract_request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long request_id { get; set; }

        [Required]
        [StringLength(50)]
        public string node_id { get; set; }

        [StringLength(128)]
        public string queue { get; set; }

        [StringLength(2)]
        public string status { get; set; }

        public long start_batch_id { get; set; }

        public long end_batch_id { get; set; }

        [Required]
        [StringLength(128)]
        public string trigger_id { get; set; }

        [Required]
        [StringLength(50)]
        public string router_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_update_time { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }
    }
}

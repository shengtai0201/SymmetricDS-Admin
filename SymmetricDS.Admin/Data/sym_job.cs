namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_job
    {
        [Key]
        [StringLength(50)]
        public string job_name { get; set; }

        [Required]
        [StringLength(10)]
        public string job_type { get; set; }

        public short requires_registration { get; set; }

        [Column(TypeName = "text")]
        public string job_expression { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(50)]
        public string default_schedule { get; set; }

        public short default_auto_start { get; set; }

        [Required]
        [StringLength(50)]
        public string node_group_id { get; set; }

        [StringLength(50)]
        public string create_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_update_time { get; set; }
    }
}

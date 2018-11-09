namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_notification
    {
        [Key]
        public string notification_id { get; set; }

        [Required]
        [StringLength(50)]
        public string node_group_id { get; set; }

        [Required]
        [StringLength(255)]
        public string external_id { get; set; }

        public int severity_level { get; set; }

        [Required]
        [StringLength(50)]
        public string type { get; set; }

        [Column(TypeName = "text")]
        public string expression { get; set; }

        public short enabled { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_update_time { get; set; }
    }
}

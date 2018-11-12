namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_registration_request
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string node_group_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string external_id { get; set; }

        [Required]
        [StringLength(2)]
        public string status { get; set; }

        [Required]
        [StringLength(60)]
        public string host_name { get; set; }

        [Required]
        [StringLength(50)]
        public string ip_address { get; set; }

        public int? attempt_count { get; set; }

        [StringLength(50)]
        public string registered_node_id { get; set; }

        [Column(TypeName = "text")]
        public string error_message { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "datetime2")]
        public DateTime create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_update_time { get; set; }
    }
}

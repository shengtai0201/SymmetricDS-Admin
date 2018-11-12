namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_extension
    {
        [Key]
        [StringLength(50)]
        public string extension_id { get; set; }

        [Required]
        [StringLength(10)]
        public string extension_type { get; set; }

        [StringLength(255)]
        public string interface_name { get; set; }

        [Required]
        [StringLength(50)]
        public string node_group_id { get; set; }

        public short enabled { get; set; }

        public int extension_order { get; set; }

        [Column(TypeName = "text")]
        public string extension_text { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_update_time { get; set; }
    }
}

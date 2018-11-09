namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_file_snapshot
    {
        [Key]
        [Column(Order = 0)]
        public string trigger_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string router_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string relative_dir { get; set; }

        [Key]
        [Column(Order = 3)]
        public string file_name { get; set; }

        [Required]
        [StringLength(128)]
        public string channel_id { get; set; }

        [Required]
        [StringLength(128)]
        public string reload_channel_id { get; set; }

        [Required]
        [StringLength(1)]
        public string last_event_type { get; set; }

        public long? crc32_checksum { get; set; }

        public long? file_size { get; set; }

        public long? file_modified_time { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_update_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime create_time { get; set; }
    }
}

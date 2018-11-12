namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_file_incoming
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string relative_dir { get; set; }

        [Key]
        [Column(Order = 1)]
        public string file_name { get; set; }

        [Required]
        [StringLength(1)]
        public string last_event_type { get; set; }

        [Required]
        [StringLength(50)]
        public string node_id { get; set; }

        public long? file_modified_time { get; set; }
    }
}

namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_lock
    {
        [Key]
        [StringLength(50)]
        public string lock_action { get; set; }

        [Required]
        [StringLength(50)]
        public string lock_type { get; set; }

        [StringLength(255)]
        public string locking_server_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? lock_time { get; set; }

        public int shared_count { get; set; }

        public int shared_enable { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_lock_time { get; set; }

        [StringLength(255)]
        public string last_locking_server_id { get; set; }
    }
}

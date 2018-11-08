namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_node_communication
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string node_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string queue { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string communication_type { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? lock_time { get; set; }

        [StringLength(255)]
        public string locking_server_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_lock_time { get; set; }

        public long? last_lock_millis { get; set; }

        public long? success_count { get; set; }

        public long? fail_count { get; set; }

        public long? skip_count { get; set; }

        public long? total_success_count { get; set; }

        public long? total_fail_count { get; set; }

        public long? total_success_millis { get; set; }

        public long? total_fail_millis { get; set; }

        public long? batch_to_send_count { get; set; }

        public int? node_priority { get; set; }
    }
}

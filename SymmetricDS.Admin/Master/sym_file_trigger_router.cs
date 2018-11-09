namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_file_trigger_router
    {
        [Key]
        [Column(Order = 0)]
        public string trigger_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string router_id { get; set; }

        public short enabled { get; set; }

        public short initial_load_enabled { get; set; }

        [StringLength(255)]
        public string target_base_dir { get; set; }

        [Required]
        [StringLength(128)]
        public string conflict_strategy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_update_time { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public virtual sym_file_trigger sym_file_trigger { get; set; }

        public virtual sym_router sym_router { get; set; }
    }
}

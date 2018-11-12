namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_sequence
    {
        [Key]
        [StringLength(50)]
        public string sequence_name { get; set; }

        public long current_value { get; set; }

        public int increment_by { get; set; }

        public long min_value { get; set; }

        public long max_value { get; set; }

        public short? cycle_flag { get; set; }

        public int cache_size { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_update_time { get; set; }
    }
}

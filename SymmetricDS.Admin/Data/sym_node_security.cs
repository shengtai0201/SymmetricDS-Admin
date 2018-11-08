namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_node_security
    {
        [Key]
        [StringLength(50)]
        public string node_id { get; set; }

        [Required]
        [StringLength(50)]
        public string node_password { get; set; }

        public short? registration_enabled { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? registration_time { get; set; }

        public short? initial_load_enabled { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? initial_load_time { get; set; }

        public long? initial_load_id { get; set; }

        [StringLength(255)]
        public string initial_load_create_by { get; set; }

        public short? rev_initial_load_enabled { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? rev_initial_load_time { get; set; }

        public long? rev_initial_load_id { get; set; }

        [StringLength(255)]
        public string rev_initial_load_create_by { get; set; }

        [StringLength(50)]
        public string created_at_node_id { get; set; }

        public virtual sym_node sym_node { get; set; }
    }
}

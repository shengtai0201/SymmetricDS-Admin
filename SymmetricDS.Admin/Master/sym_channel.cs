namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_channel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sym_channel()
        {
            sym_trigger = new HashSet<sym_trigger>();
            sym_trigger1 = new HashSet<sym_trigger>();
        }

        [Key]
        public string channel_id { get; set; }

        public int processing_order { get; set; }

        public int max_batch_size { get; set; }

        public int max_batch_to_send { get; set; }

        public int max_data_to_route { get; set; }

        public int extract_period_millis { get; set; }

        public short enabled { get; set; }

        public short use_old_data_to_route { get; set; }

        public short use_row_data_to_route { get; set; }

        public short use_pk_data_to_route { get; set; }

        public short reload_flag { get; set; }

        public short file_sync_flag { get; set; }

        public short contains_big_lob { get; set; }

        [Required]
        [StringLength(50)]
        public string batch_algorithm { get; set; }

        [Required]
        [StringLength(50)]
        public string data_loader_type { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [Required]
        [StringLength(25)]
        public string queue { get; set; }

        public decimal max_network_kbps { get; set; }

        [StringLength(1)]
        public string data_event_action { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_update_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sym_trigger> sym_trigger { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sym_trigger> sym_trigger1 { get; set; }
    }
}

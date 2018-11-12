namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_file_trigger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sym_file_trigger()
        {
            sym_file_trigger_router = new HashSet<sym_file_trigger_router>();
        }

        [Key]
        public string trigger_id { get; set; }

        [Required]
        [StringLength(128)]
        public string channel_id { get; set; }

        [Required]
        [StringLength(128)]
        public string reload_channel_id { get; set; }

        [Required]
        [StringLength(255)]
        public string base_dir { get; set; }

        public short recurse { get; set; }

        [StringLength(255)]
        public string includes_files { get; set; }

        [StringLength(255)]
        public string excludes_files { get; set; }

        public short sync_on_create { get; set; }

        public short sync_on_modified { get; set; }

        public short sync_on_delete { get; set; }

        public short sync_on_ctl_file { get; set; }

        public short delete_after_sync { get; set; }

        [Column(TypeName = "text")]
        public string before_copy_script { get; set; }

        [Column(TypeName = "text")]
        public string after_copy_script { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_update_time { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sym_file_trigger_router> sym_file_trigger_router { get; set; }
    }
}

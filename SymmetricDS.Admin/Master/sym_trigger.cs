namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_trigger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sym_trigger()
        {
            sym_trigger_router = new HashSet<sym_trigger_router>();
        }

        [Key]
        public string trigger_id { get; set; }

        [StringLength(255)]
        public string source_catalog_name { get; set; }

        [StringLength(255)]
        public string source_schema_name { get; set; }

        [Required]
        [StringLength(255)]
        public string source_table_name { get; set; }

        [Required]
        [StringLength(128)]
        public string channel_id { get; set; }

        [Required]
        [StringLength(128)]
        public string reload_channel_id { get; set; }

        public short sync_on_update { get; set; }

        public short sync_on_insert { get; set; }

        public short sync_on_delete { get; set; }

        public short sync_on_incoming_batch { get; set; }

        [StringLength(255)]
        public string name_for_update_trigger { get; set; }

        [StringLength(255)]
        public string name_for_insert_trigger { get; set; }

        [StringLength(255)]
        public string name_for_delete_trigger { get; set; }

        [Column(TypeName = "text")]
        public string sync_on_update_condition { get; set; }

        [Column(TypeName = "text")]
        public string sync_on_insert_condition { get; set; }

        [Column(TypeName = "text")]
        public string sync_on_delete_condition { get; set; }

        [Column(TypeName = "text")]
        public string custom_before_update_text { get; set; }

        [Column(TypeName = "text")]
        public string custom_before_insert_text { get; set; }

        [Column(TypeName = "text")]
        public string custom_before_delete_text { get; set; }

        [Column(TypeName = "text")]
        public string custom_on_update_text { get; set; }

        [Column(TypeName = "text")]
        public string custom_on_insert_text { get; set; }

        [Column(TypeName = "text")]
        public string custom_on_delete_text { get; set; }

        [Column(TypeName = "text")]
        public string external_select { get; set; }

        [Column(TypeName = "text")]
        public string tx_id_expression { get; set; }

        [Column(TypeName = "text")]
        public string channel_expression { get; set; }

        [Column(TypeName = "text")]
        public string excluded_column_names { get; set; }

        [Column(TypeName = "text")]
        public string included_column_names { get; set; }

        [Column(TypeName = "text")]
        public string sync_key_names { get; set; }

        public short use_stream_lobs { get; set; }

        public short use_capture_lobs { get; set; }

        public short use_capture_old_data { get; set; }

        public short use_handle_key_updates { get; set; }

        public short stream_row { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime create_time { get; set; }

        [StringLength(50)]
        public string last_update_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime last_update_time { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public virtual sym_channel sym_channel { get; set; }

        public virtual sym_channel sym_channel1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sym_trigger_router> sym_trigger_router { get; set; }
    }
}

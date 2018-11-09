namespace SymmetricDS.Admin.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sym_incoming_batch
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long batch_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string node_id { get; set; }

        [StringLength(128)]
        public string channel_id { get; set; }

        [StringLength(2)]
        public string status { get; set; }

        public short? error_flag { get; set; }

        [StringLength(10)]
        public string sql_state { get; set; }

        public int sql_code { get; set; }

        [Column(TypeName = "text")]
        public string sql_message { get; set; }

        [StringLength(255)]
        public string last_update_hostname { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_update_time { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }

        [StringLength(255)]
        public string summary { get; set; }

        public int ignore_count { get; set; }

        public long byte_count { get; set; }

        public short? load_flag { get; set; }

        public int extract_count { get; set; }

        public int sent_count { get; set; }

        public int load_count { get; set; }

        public int reload_row_count { get; set; }

        public int other_row_count { get; set; }

        public int data_row_count { get; set; }

        public int extract_row_count { get; set; }

        public int load_row_count { get; set; }

        public int data_insert_row_count { get; set; }

        public int data_update_row_count { get; set; }

        public int data_delete_row_count { get; set; }

        public int extract_insert_row_count { get; set; }

        public int extract_update_row_count { get; set; }

        public int extract_delete_row_count { get; set; }

        public int load_insert_row_count { get; set; }

        public int load_update_row_count { get; set; }

        public int load_delete_row_count { get; set; }

        public int network_millis { get; set; }

        public int filter_millis { get; set; }

        public int load_millis { get; set; }

        public int router_millis { get; set; }

        public int extract_millis { get; set; }

        public int transform_extract_millis { get; set; }

        public int transform_load_millis { get; set; }

        public long? load_id { get; set; }

        public short? common_flag { get; set; }

        public int fallback_insert_count { get; set; }

        public int fallback_update_count { get; set; }

        public int ignore_row_count { get; set; }

        public int missing_delete_count { get; set; }

        public int skip_count { get; set; }

        public int failed_row_number { get; set; }

        public int failed_line_number { get; set; }

        public long failed_data_id { get; set; }
    }
}

namespace SymmetricDS.Admin.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SymDbContext : DbContext
    {
        public virtual DbSet<sym_channel> sym_channel { get; set; }
        public virtual DbSet<sym_conflict> sym_conflict { get; set; }
        public virtual DbSet<sym_context> sym_context { get; set; }
        public virtual DbSet<sym_data> sym_data { get; set; }
        public virtual DbSet<sym_data_event> sym_data_event { get; set; }
        public virtual DbSet<sym_data_gap> sym_data_gap { get; set; }
        public virtual DbSet<sym_extension> sym_extension { get; set; }
        public virtual DbSet<sym_extract_request> sym_extract_request { get; set; }
        public virtual DbSet<sym_file_incoming> sym_file_incoming { get; set; }
        public virtual DbSet<sym_file_snapshot> sym_file_snapshot { get; set; }
        public virtual DbSet<sym_file_trigger> sym_file_trigger { get; set; }
        public virtual DbSet<sym_file_trigger_router> sym_file_trigger_router { get; set; }
        public virtual DbSet<sym_grouplet> sym_grouplet { get; set; }
        public virtual DbSet<sym_grouplet_link> sym_grouplet_link { get; set; }
        public virtual DbSet<sym_incoming_batch> sym_incoming_batch { get; set; }
        public virtual DbSet<sym_incoming_error> sym_incoming_error { get; set; }
        public virtual DbSet<sym_job> sym_job { get; set; }
        public virtual DbSet<sym_load_filter> sym_load_filter { get; set; }
        public virtual DbSet<sym_lock> sym_lock { get; set; }
        public virtual DbSet<sym_monitor> sym_monitor { get; set; }
        public virtual DbSet<sym_monitor_event> sym_monitor_event { get; set; }
        public virtual DbSet<sym_node> sym_node { get; set; }
        public virtual DbSet<sym_node_channel_ctl> sym_node_channel_ctl { get; set; }
        public virtual DbSet<sym_node_communication> sym_node_communication { get; set; }
        public virtual DbSet<sym_node_group> sym_node_group { get; set; }
        public virtual DbSet<sym_node_group_channel_wnd> sym_node_group_channel_wnd { get; set; }
        public virtual DbSet<sym_node_group_link> sym_node_group_link { get; set; }
        public virtual DbSet<sym_node_host> sym_node_host { get; set; }
        public virtual DbSet<sym_node_host_channel_stats> sym_node_host_channel_stats { get; set; }
        public virtual DbSet<sym_node_host_job_stats> sym_node_host_job_stats { get; set; }
        public virtual DbSet<sym_node_host_stats> sym_node_host_stats { get; set; }
        public virtual DbSet<sym_node_identity> sym_node_identity { get; set; }
        public virtual DbSet<sym_node_security> sym_node_security { get; set; }
        public virtual DbSet<sym_notification> sym_notification { get; set; }
        public virtual DbSet<sym_outgoing_batch> sym_outgoing_batch { get; set; }
        public virtual DbSet<sym_parameter> sym_parameter { get; set; }
        public virtual DbSet<sym_registration_redirect> sym_registration_redirect { get; set; }
        public virtual DbSet<sym_registration_request> sym_registration_request { get; set; }
        public virtual DbSet<sym_router> sym_router { get; set; }
        public virtual DbSet<sym_sequence> sym_sequence { get; set; }
        public virtual DbSet<sym_table_reload_request> sym_table_reload_request { get; set; }
        public virtual DbSet<sym_transform_column> sym_transform_column { get; set; }
        public virtual DbSet<sym_transform_table> sym_transform_table { get; set; }
        public virtual DbSet<sym_trigger> sym_trigger { get; set; }
        public virtual DbSet<sym_trigger_hist> sym_trigger_hist { get; set; }
        public virtual DbSet<sym_trigger_router> sym_trigger_router { get; set; }
        public virtual DbSet<sym_trigger_router_grouplet> sym_trigger_router_grouplet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<sym_channel>()
                .Property(e => e.channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_channel>()
                .Property(e => e.batch_algorithm)
                .IsUnicode(false);

            modelBuilder.Entity<sym_channel>()
                .Property(e => e.data_loader_type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_channel>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sym_channel>()
                .Property(e => e.queue)
                .IsUnicode(false);

            modelBuilder.Entity<sym_channel>()
                .Property(e => e.max_network_kbps)
                .HasPrecision(10, 3);

            modelBuilder.Entity<sym_channel>()
                .Property(e => e.data_event_action)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_channel>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_channel>()
                .HasMany(e => e.sym_trigger)
                .WithRequired(e => e.sym_channel)
                .HasForeignKey(e => e.channel_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sym_channel>()
                .HasMany(e => e.sym_trigger1)
                .WithRequired(e => e.sym_channel1)
                .HasForeignKey(e => e.reload_channel_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sym_conflict>()
                .Property(e => e.conflict_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_conflict>()
                .Property(e => e.source_node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_conflict>()
                .Property(e => e.target_node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_conflict>()
                .Property(e => e.target_channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_conflict>()
                .Property(e => e.target_catalog_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_conflict>()
                .Property(e => e.target_schema_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_conflict>()
                .Property(e => e.target_table_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_conflict>()
                .Property(e => e.detect_type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_conflict>()
                .Property(e => e.detect_expression)
                .IsUnicode(false);

            modelBuilder.Entity<sym_conflict>()
                .Property(e => e.resolve_type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_conflict>()
                .Property(e => e.ping_back)
                .IsUnicode(false);

            modelBuilder.Entity<sym_conflict>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_context>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_context>()
                .Property(e => e.context_value)
                .IsUnicode(false);

            modelBuilder.Entity<sym_data>()
                .Property(e => e.table_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_data>()
                .Property(e => e.event_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_data>()
                .Property(e => e.row_data)
                .IsUnicode(false);

            modelBuilder.Entity<sym_data>()
                .Property(e => e.pk_data)
                .IsUnicode(false);

            modelBuilder.Entity<sym_data>()
                .Property(e => e.old_data)
                .IsUnicode(false);

            modelBuilder.Entity<sym_data>()
                .Property(e => e.channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_data>()
                .Property(e => e.transaction_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_data>()
                .Property(e => e.source_node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_data>()
                .Property(e => e.external_data)
                .IsUnicode(false);

            modelBuilder.Entity<sym_data>()
                .Property(e => e.node_list)
                .IsUnicode(false);

            modelBuilder.Entity<sym_data_event>()
                .Property(e => e.router_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_data_gap>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_data_gap>()
                .Property(e => e.last_update_hostname)
                .IsUnicode(false);

            modelBuilder.Entity<sym_extension>()
                .Property(e => e.extension_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_extension>()
                .Property(e => e.extension_type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_extension>()
                .Property(e => e.interface_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_extension>()
                .Property(e => e.node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_extension>()
                .Property(e => e.extension_text)
                .IsUnicode(false);

            modelBuilder.Entity<sym_extension>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_extract_request>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_extract_request>()
                .Property(e => e.queue)
                .IsUnicode(false);

            modelBuilder.Entity<sym_extract_request>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_extract_request>()
                .Property(e => e.trigger_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_extract_request>()
                .Property(e => e.router_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_incoming>()
                .Property(e => e.relative_dir)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_incoming>()
                .Property(e => e.file_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_incoming>()
                .Property(e => e.last_event_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_incoming>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_snapshot>()
                .Property(e => e.trigger_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_snapshot>()
                .Property(e => e.router_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_snapshot>()
                .Property(e => e.relative_dir)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_snapshot>()
                .Property(e => e.file_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_snapshot>()
                .Property(e => e.channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_snapshot>()
                .Property(e => e.reload_channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_snapshot>()
                .Property(e => e.last_event_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_snapshot>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger>()
                .Property(e => e.trigger_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger>()
                .Property(e => e.channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger>()
                .Property(e => e.reload_channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger>()
                .Property(e => e.base_dir)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger>()
                .Property(e => e.includes_files)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger>()
                .Property(e => e.excludes_files)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger>()
                .Property(e => e.before_copy_script)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger>()
                .Property(e => e.after_copy_script)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger>()
                .HasMany(e => e.sym_file_trigger_router)
                .WithRequired(e => e.sym_file_trigger)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sym_file_trigger_router>()
                .Property(e => e.trigger_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger_router>()
                .Property(e => e.router_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger_router>()
                .Property(e => e.target_base_dir)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger_router>()
                .Property(e => e.conflict_strategy)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger_router>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_file_trigger_router>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sym_grouplet>()
                .Property(e => e.grouplet_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_grouplet>()
                .Property(e => e.grouplet_link_policy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_grouplet>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sym_grouplet>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_grouplet>()
                .HasMany(e => e.sym_grouplet_link)
                .WithRequired(e => e.sym_grouplet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sym_grouplet>()
                .HasMany(e => e.sym_trigger_router_grouplet)
                .WithRequired(e => e.sym_grouplet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sym_grouplet_link>()
                .Property(e => e.grouplet_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_grouplet_link>()
                .Property(e => e.external_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_grouplet_link>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_batch>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_batch>()
                .Property(e => e.channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_batch>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_batch>()
                .Property(e => e.sql_state)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_batch>()
                .Property(e => e.sql_message)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_batch>()
                .Property(e => e.last_update_hostname)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_batch>()
                .Property(e => e.summary)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_error>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_error>()
                .Property(e => e.target_catalog_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_error>()
                .Property(e => e.target_schema_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_error>()
                .Property(e => e.target_table_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_error>()
                .Property(e => e.event_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_error>()
                .Property(e => e.binary_encoding)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_error>()
                .Property(e => e.column_names)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_error>()
                .Property(e => e.pk_column_names)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_error>()
                .Property(e => e.row_data)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_error>()
                .Property(e => e.old_data)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_error>()
                .Property(e => e.cur_data)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_error>()
                .Property(e => e.resolve_data)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_error>()
                .Property(e => e.conflict_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_incoming_error>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_job>()
                .Property(e => e.job_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_job>()
                .Property(e => e.job_type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_job>()
                .Property(e => e.job_expression)
                .IsUnicode(false);

            modelBuilder.Entity<sym_job>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sym_job>()
                .Property(e => e.default_schedule)
                .IsUnicode(false);

            modelBuilder.Entity<sym_job>()
                .Property(e => e.node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_job>()
                .Property(e => e.create_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_job>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_load_filter>()
                .Property(e => e.load_filter_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_load_filter>()
                .Property(e => e.load_filter_type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_load_filter>()
                .Property(e => e.source_node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_load_filter>()
                .Property(e => e.target_node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_load_filter>()
                .Property(e => e.target_catalog_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_load_filter>()
                .Property(e => e.target_schema_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_load_filter>()
                .Property(e => e.target_table_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_load_filter>()
                .Property(e => e.before_write_script)
                .IsUnicode(false);

            modelBuilder.Entity<sym_load_filter>()
                .Property(e => e.after_write_script)
                .IsUnicode(false);

            modelBuilder.Entity<sym_load_filter>()
                .Property(e => e.batch_complete_script)
                .IsUnicode(false);

            modelBuilder.Entity<sym_load_filter>()
                .Property(e => e.batch_commit_script)
                .IsUnicode(false);

            modelBuilder.Entity<sym_load_filter>()
                .Property(e => e.batch_rollback_script)
                .IsUnicode(false);

            modelBuilder.Entity<sym_load_filter>()
                .Property(e => e.handle_error_script)
                .IsUnicode(false);

            modelBuilder.Entity<sym_load_filter>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_lock>()
                .Property(e => e.lock_action)
                .IsUnicode(false);

            modelBuilder.Entity<sym_lock>()
                .Property(e => e.lock_type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_lock>()
                .Property(e => e.locking_server_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_lock>()
                .Property(e => e.last_locking_server_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_monitor>()
                .Property(e => e.monitor_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_monitor>()
                .Property(e => e.node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_monitor>()
                .Property(e => e.external_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_monitor>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_monitor>()
                .Property(e => e.expression)
                .IsUnicode(false);

            modelBuilder.Entity<sym_monitor>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_monitor_event>()
                .Property(e => e.monitor_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_monitor_event>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_monitor_event>()
                .Property(e => e.host_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_monitor_event>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_monitor_event>()
                .Property(e => e.details)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node>()
                .Property(e => e.node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node>()
                .Property(e => e.external_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node>()
                .Property(e => e.timezone_offset)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node>()
                .Property(e => e.sync_url)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node>()
                .Property(e => e.schema_version)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node>()
                .Property(e => e.symmetric_version)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node>()
                .Property(e => e.config_version)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node>()
                .Property(e => e.database_type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node>()
                .Property(e => e.database_version)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node>()
                .Property(e => e.created_at_node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node>()
                .Property(e => e.deployment_type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node>()
                .Property(e => e.deployment_sub_type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node>()
                .HasOptional(e => e.sym_node_identity)
                .WithRequired(e => e.sym_node);

            modelBuilder.Entity<sym_node>()
                .HasOptional(e => e.sym_node_security)
                .WithRequired(e => e.sym_node);

            modelBuilder.Entity<sym_node_channel_ctl>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_channel_ctl>()
                .Property(e => e.channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_communication>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_communication>()
                .Property(e => e.queue)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_communication>()
                .Property(e => e.communication_type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_communication>()
                .Property(e => e.locking_server_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_group>()
                .Property(e => e.node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_group>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_group>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_group>()
                .HasMany(e => e.sym_node_group_link)
                .WithRequired(e => e.sym_node_group)
                .HasForeignKey(e => e.source_node_group_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sym_node_group>()
                .HasMany(e => e.sym_node_group_link1)
                .WithRequired(e => e.sym_node_group1)
                .HasForeignKey(e => e.target_node_group_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sym_node_group_channel_wnd>()
                .Property(e => e.node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_group_channel_wnd>()
                .Property(e => e.channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_group_link>()
                .Property(e => e.source_node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_group_link>()
                .Property(e => e.target_node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_group_link>()
                .Property(e => e.data_event_action)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_group_link>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_group_link>()
                .HasMany(e => e.sym_conflict)
                .WithRequired(e => e.sym_node_group_link)
                .HasForeignKey(e => new { e.source_node_group_id, e.target_node_group_id })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sym_node_group_link>()
                .HasMany(e => e.sym_router)
                .WithRequired(e => e.sym_node_group_link)
                .HasForeignKey(e => new { e.source_node_group_id, e.target_node_group_id })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sym_node_group_link>()
                .HasMany(e => e.sym_transform_table)
                .WithRequired(e => e.sym_node_group_link)
                .HasForeignKey(e => new { e.source_node_group_id, e.target_node_group_id })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sym_node_host>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host>()
                .Property(e => e.host_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host>()
                .Property(e => e.instance_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host>()
                .Property(e => e.ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host>()
                .Property(e => e.os_user)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host>()
                .Property(e => e.os_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host>()
                .Property(e => e.os_arch)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host>()
                .Property(e => e.os_version)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host>()
                .Property(e => e.java_version)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host>()
                .Property(e => e.java_vendor)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host>()
                .Property(e => e.jdbc_version)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host>()
                .Property(e => e.symmetric_version)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host>()
                .Property(e => e.timezone_offset)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host_channel_stats>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host_channel_stats>()
                .Property(e => e.host_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host_channel_stats>()
                .Property(e => e.channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host_job_stats>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host_job_stats>()
                .Property(e => e.host_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host_job_stats>()
                .Property(e => e.job_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host_job_stats>()
                .Property(e => e.target_node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host_stats>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_host_stats>()
                .Property(e => e.host_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_identity>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_security>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_security>()
                .Property(e => e.node_password)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_security>()
                .Property(e => e.initial_load_create_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_security>()
                .Property(e => e.rev_initial_load_create_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_node_security>()
                .Property(e => e.created_at_node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_notification>()
                .Property(e => e.notification_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_notification>()
                .Property(e => e.node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_notification>()
                .Property(e => e.external_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_notification>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_notification>()
                .Property(e => e.expression)
                .IsUnicode(false);

            modelBuilder.Entity<sym_notification>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_outgoing_batch>()
                .Property(e => e.node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_outgoing_batch>()
                .Property(e => e.channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_outgoing_batch>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_outgoing_batch>()
                .Property(e => e.sql_state)
                .IsUnicode(false);

            modelBuilder.Entity<sym_outgoing_batch>()
                .Property(e => e.sql_message)
                .IsUnicode(false);

            modelBuilder.Entity<sym_outgoing_batch>()
                .Property(e => e.last_update_hostname)
                .IsUnicode(false);

            modelBuilder.Entity<sym_outgoing_batch>()
                .Property(e => e.summary)
                .IsUnicode(false);

            modelBuilder.Entity<sym_outgoing_batch>()
                .Property(e => e.create_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_parameter>()
                .Property(e => e.external_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_parameter>()
                .Property(e => e.node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_parameter>()
                .Property(e => e.param_key)
                .IsUnicode(false);

            modelBuilder.Entity<sym_parameter>()
                .Property(e => e.param_value)
                .IsUnicode(false);

            modelBuilder.Entity<sym_parameter>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_registration_redirect>()
                .Property(e => e.registrant_external_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_registration_redirect>()
                .Property(e => e.registration_node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_registration_request>()
                .Property(e => e.node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_registration_request>()
                .Property(e => e.external_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_registration_request>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_registration_request>()
                .Property(e => e.host_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_registration_request>()
                .Property(e => e.ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<sym_registration_request>()
                .Property(e => e.registered_node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_registration_request>()
                .Property(e => e.error_message)
                .IsUnicode(false);

            modelBuilder.Entity<sym_registration_request>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_router>()
                .Property(e => e.router_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_router>()
                .Property(e => e.target_catalog_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_router>()
                .Property(e => e.target_schema_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_router>()
                .Property(e => e.target_table_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_router>()
                .Property(e => e.source_node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_router>()
                .Property(e => e.target_node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_router>()
                .Property(e => e.router_type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_router>()
                .Property(e => e.router_expression)
                .IsUnicode(false);

            modelBuilder.Entity<sym_router>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_router>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sym_router>()
                .HasMany(e => e.sym_file_trigger_router)
                .WithRequired(e => e.sym_router)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sym_router>()
                .HasMany(e => e.sym_trigger_router)
                .WithRequired(e => e.sym_router)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sym_sequence>()
                .Property(e => e.sequence_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_sequence>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_table_reload_request>()
                .Property(e => e.target_node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_table_reload_request>()
                .Property(e => e.source_node_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_table_reload_request>()
                .Property(e => e.trigger_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_table_reload_request>()
                .Property(e => e.router_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_table_reload_request>()
                .Property(e => e.reload_select)
                .IsUnicode(false);

            modelBuilder.Entity<sym_table_reload_request>()
                .Property(e => e.before_custom_sql)
                .IsUnicode(false);

            modelBuilder.Entity<sym_table_reload_request>()
                .Property(e => e.channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_table_reload_request>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_column>()
                .Property(e => e.transform_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_column>()
                .Property(e => e.include_on)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_column>()
                .Property(e => e.target_column_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_column>()
                .Property(e => e.source_column_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_column>()
                .Property(e => e.transform_type)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_column>()
                .Property(e => e.transform_expression)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_column>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_column>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.transform_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.source_node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.target_node_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.transform_point)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.source_catalog_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.source_schema_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.source_table_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.target_catalog_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.target_schema_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.target_table_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.update_action)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.delete_action)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.column_policy)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_transform_table>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.trigger_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.source_catalog_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.source_schema_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.source_table_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.reload_channel_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.name_for_update_trigger)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.name_for_insert_trigger)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.name_for_delete_trigger)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.sync_on_update_condition)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.sync_on_insert_condition)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.sync_on_delete_condition)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.custom_before_update_text)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.custom_before_insert_text)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.custom_before_delete_text)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.custom_on_update_text)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.custom_on_insert_text)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.custom_on_delete_text)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.external_select)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.tx_id_expression)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.channel_expression)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.excluded_column_names)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.included_column_names)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.sync_key_names)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger>()
                .HasMany(e => e.sym_trigger_router)
                .WithRequired(e => e.sym_trigger)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sym_trigger_hist>()
                .Property(e => e.trigger_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_hist>()
                .Property(e => e.source_table_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_hist>()
                .Property(e => e.source_catalog_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_hist>()
                .Property(e => e.source_schema_name)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_hist>()
                .Property(e => e.name_for_update_trigger)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_hist>()
                .Property(e => e.name_for_insert_trigger)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_hist>()
                .Property(e => e.name_for_delete_trigger)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_hist>()
                .Property(e => e.column_names)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_hist>()
                .Property(e => e.pk_column_names)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_hist>()
                .Property(e => e.last_trigger_build_reason)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_hist>()
                .Property(e => e.error_message)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_router>()
                .Property(e => e.trigger_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_router>()
                .Property(e => e.router_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_router>()
                .Property(e => e.initial_load_select)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_router>()
                .Property(e => e.initial_load_delete_stmt)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_router>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_router>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_router>()
                .HasMany(e => e.sym_trigger_router_grouplet)
                .WithRequired(e => e.sym_trigger_router)
                .HasForeignKey(e => new { e.trigger_id, e.router_id })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sym_trigger_router_grouplet>()
                .Property(e => e.grouplet_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_router_grouplet>()
                .Property(e => e.trigger_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_router_grouplet>()
                .Property(e => e.router_id)
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_router_grouplet>()
                .Property(e => e.applies_when)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sym_trigger_router_grouplet>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);
        }
    }
}

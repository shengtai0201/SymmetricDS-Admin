using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricDS.Admin.Master
{
    public partial class MasterDbContext : DbContext
    {
        private readonly Databases database;
        public MasterDbContext(DbContextOptions<MasterDbContext> dbContextOptions, IOptions<AppSettings> appSettingsOptions) : base(dbContextOptions)
        {
            this.database = appSettingsOptions.Value.Database;
        }

        private void NpgsqlModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SymChannel>(entity =>
            {
                entity.HasKey(e => e.ChannelId);

                entity.ToTable("sym_channel");

                entity.Property(e => e.ChannelId)
                    .HasColumnName("channel_id")
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.BatchAlgorithm)
                    .IsRequired()
                    .HasColumnName("batch_algorithm")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'default'::character varying");

                entity.Property(e => e.ContainsBigLob).HasColumnName("contains_big_lob");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.DataEventAction).HasColumnName("data_event_action");

                entity.Property(e => e.DataLoaderType)
                    .IsRequired()
                    .HasColumnName("data_loader_type")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'default'::character varying");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ExtractPeriodMillis).HasColumnName("extract_period_millis");

                entity.Property(e => e.FileSyncFlag).HasColumnName("file_sync_flag");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.MaxBatchSize)
                    .HasColumnName("max_batch_size")
                    .HasDefaultValueSql("1000");

                entity.Property(e => e.MaxBatchToSend)
                    .HasColumnName("max_batch_to_send")
                    .HasDefaultValueSql("60");

                entity.Property(e => e.MaxDataToRoute)
                    .HasColumnName("max_data_to_route")
                    .HasDefaultValueSql("100000");

                entity.Property(e => e.MaxNetworkKbps)
                    .HasColumnName("max_network_kbps")
                    .HasColumnType("numeric(10,3)")
                    .HasDefaultValueSql("0.000");

                entity.Property(e => e.ProcessingOrder)
                    .HasColumnName("processing_order")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Queue)
                    .IsRequired()
                    .HasColumnName("queue")
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'default'::character varying");

                entity.Property(e => e.ReloadFlag).HasColumnName("reload_flag");

                entity.Property(e => e.UseOldDataToRoute)
                    .HasColumnName("use_old_data_to_route")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UsePkDataToRoute)
                    .HasColumnName("use_pk_data_to_route")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UseRowDataToRoute)
                    .HasColumnName("use_row_data_to_route")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<SymConflict>(entity =>
            {
                entity.HasKey(e => e.ConflictId);

                entity.ToTable("sym_conflict");

                entity.Property(e => e.ConflictId)
                    .HasColumnName("conflict_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.DetectExpression).HasColumnName("detect_expression");

                entity.Property(e => e.DetectType)
                    .IsRequired()
                    .HasColumnName("detect_type")
                    .HasMaxLength(128);

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.PingBack)
                    .IsRequired()
                    .HasColumnName("ping_back")
                    .HasMaxLength(128);

                entity.Property(e => e.ResolveChangesOnly)
                    .HasColumnName("resolve_changes_only")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ResolveRowOnly)
                    .HasColumnName("resolve_row_only")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ResolveType)
                    .IsRequired()
                    .HasColumnName("resolve_type")
                    .HasMaxLength(128);

                entity.Property(e => e.SourceNodeGroupId)
                    .IsRequired()
                    .HasColumnName("source_node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.TargetCatalogName)
                    .HasColumnName("target_catalog_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TargetChannelId)
                    .HasColumnName("target_channel_id")
                    .HasMaxLength(128);

                entity.Property(e => e.TargetNodeGroupId)
                    .IsRequired()
                    .HasColumnName("target_node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.TargetSchemaName)
                    .HasColumnName("target_schema_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TargetTableName)
                    .HasColumnName("target_table_name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.SymNodeGroupLink)
                    .WithMany(p => p.SymConflict)
                    .HasForeignKey(d => new { d.SourceNodeGroupId, d.TargetNodeGroupId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_cf_2_grp_lnk");
            });

            modelBuilder.Entity<SymContext>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("sym_context");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(80)
                    .ValueGeneratedNever();

                entity.Property(e => e.ContextValue).HasColumnName("context_value");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");
            });

            modelBuilder.Entity<SymData>(entity =>
            {
                entity.HasKey(e => e.DataId);

                entity.ToTable("sym_data");

                entity.HasIndex(e => new { e.DataId, e.ChannelId })
                    .HasName("sym_idx_d_channel_id");

                entity.Property(e => e.DataId).HasColumnName("data_id");

                entity.Property(e => e.ChannelId)
                    .HasColumnName("channel_id")
                    .HasMaxLength(128);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.EventType).HasColumnName("event_type");

                entity.Property(e => e.ExternalData)
                    .HasColumnName("external_data")
                    .HasMaxLength(50);

                entity.Property(e => e.NodeList)
                    .HasColumnName("node_list")
                    .HasMaxLength(255);

                entity.Property(e => e.OldData).HasColumnName("old_data");

                entity.Property(e => e.PkData).HasColumnName("pk_data");

                entity.Property(e => e.RowData).HasColumnName("row_data");

                entity.Property(e => e.SourceNodeId)
                    .HasColumnName("source_node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasColumnName("table_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("transaction_id")
                    .HasMaxLength(255);

                entity.Property(e => e.TriggerHistId).HasColumnName("trigger_hist_id");
            });

            modelBuilder.Entity<SymDataEvent>(entity =>
            {
                entity.HasKey(e => new { e.DataId, e.BatchId, e.RouterId });

                entity.ToTable("sym_data_event");

                entity.HasIndex(e => e.BatchId)
                    .HasName("sym_idx_de_batchid");

                entity.Property(e => e.DataId).HasColumnName("data_id");

                entity.Property(e => e.BatchId).HasColumnName("batch_id");

                entity.Property(e => e.RouterId)
                    .HasColumnName("router_id")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");
            });

            modelBuilder.Entity<SymDataGap>(entity =>
            {
                entity.HasKey(e => new { e.StartId, e.EndId });

                entity.ToTable("sym_data_gap");

                entity.HasIndex(e => e.Status)
                    .HasName("sym_idx_dg_status");

                entity.Property(e => e.StartId).HasColumnName("start_id");

                entity.Property(e => e.EndId).HasColumnName("end_id");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LastUpdateHostname)
                    .HasColumnName("last_update_hostname")
                    .HasMaxLength(255);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("character(2)");
            });

            modelBuilder.Entity<SymExtension>(entity =>
            {
                entity.HasKey(e => e.ExtensionId);

                entity.ToTable("sym_extension");

                entity.Property(e => e.ExtensionId)
                    .HasColumnName("extension_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ExtensionOrder)
                    .HasColumnName("extension_order")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ExtensionText).HasColumnName("extension_text");

                entity.Property(e => e.ExtensionType)
                    .IsRequired()
                    .HasColumnName("extension_type")
                    .HasMaxLength(10);

                entity.Property(e => e.InterfaceName)
                    .HasColumnName("interface_name")
                    .HasMaxLength(255);

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.NodeGroupId)
                    .IsRequired()
                    .HasColumnName("node_group_id")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SymExtractRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.ToTable("sym_extract_request");

                entity.Property(e => e.RequestId)
                    .HasColumnName("request_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.EndBatchId).HasColumnName("end_batch_id");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.NodeId)
                    .IsRequired()
                    .HasColumnName("node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Queue)
                    .HasColumnName("queue")
                    .HasMaxLength(128);

                entity.Property(e => e.RouterId)
                    .IsRequired()
                    .HasColumnName("router_id")
                    .HasMaxLength(50);

                entity.Property(e => e.StartBatchId).HasColumnName("start_batch_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("character(2)");

                entity.Property(e => e.TriggerId)
                    .IsRequired()
                    .HasColumnName("trigger_id")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<SymFileIncoming>(entity =>
            {
                entity.HasKey(e => new { e.RelativeDir, e.FileName });

                entity.ToTable("sym_file_incoming");

                entity.Property(e => e.RelativeDir)
                    .HasColumnName("relative_dir")
                    .HasMaxLength(255);

                entity.Property(e => e.FileName)
                    .HasColumnName("file_name")
                    .HasMaxLength(128);

                entity.Property(e => e.FileModifiedTime).HasColumnName("file_modified_time");

                entity.Property(e => e.LastEventType).HasColumnName("last_event_type");

                entity.Property(e => e.NodeId)
                    .IsRequired()
                    .HasColumnName("node_id")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SymFileSnapshot>(entity =>
            {
                entity.HasKey(e => new { e.TriggerId, e.RouterId, e.RelativeDir, e.FileName });

                entity.ToTable("sym_file_snapshot");

                entity.HasIndex(e => e.ReloadChannelId)
                    .HasName("sym_idx_f_snpsht_chid");

                entity.Property(e => e.TriggerId)
                    .HasColumnName("trigger_id")
                    .HasMaxLength(128);

                entity.Property(e => e.RouterId)
                    .HasColumnName("router_id")
                    .HasMaxLength(50);

                entity.Property(e => e.RelativeDir)
                    .HasColumnName("relative_dir")
                    .HasMaxLength(255);

                entity.Property(e => e.FileName)
                    .HasColumnName("file_name")
                    .HasMaxLength(128);

                entity.Property(e => e.ChannelId)
                    .IsRequired()
                    .HasColumnName("channel_id")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("'filesync'::character varying");

                entity.Property(e => e.Crc32Checksum).HasColumnName("crc32_checksum");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.FileModifiedTime).HasColumnName("file_modified_time");

                entity.Property(e => e.FileSize).HasColumnName("file_size");

                entity.Property(e => e.LastEventType).HasColumnName("last_event_type");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.ReloadChannelId)
                    .IsRequired()
                    .HasColumnName("reload_channel_id")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("'filesync_reload'::character varying");
            });

            modelBuilder.Entity<SymFileTrigger>(entity =>
            {
                entity.HasKey(e => e.TriggerId);

                entity.ToTable("sym_file_trigger");

                entity.Property(e => e.TriggerId)
                    .HasColumnName("trigger_id")
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.AfterCopyScript).HasColumnName("after_copy_script");

                entity.Property(e => e.BaseDir)
                    .IsRequired()
                    .HasColumnName("base_dir")
                    .HasMaxLength(255);

                entity.Property(e => e.BeforeCopyScript).HasColumnName("before_copy_script");

                entity.Property(e => e.ChannelId)
                    .IsRequired()
                    .HasColumnName("channel_id")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("'filesync'::character varying");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.DeleteAfterSync).HasColumnName("delete_after_sync");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ExcludesFiles)
                    .HasColumnName("excludes_files")
                    .HasMaxLength(255);

                entity.Property(e => e.IncludesFiles)
                    .HasColumnName("includes_files")
                    .HasMaxLength(255);

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Recurse)
                    .HasColumnName("recurse")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ReloadChannelId)
                    .IsRequired()
                    .HasColumnName("reload_channel_id")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("'filesync_reload'::character varying");

                entity.Property(e => e.SyncOnCreate)
                    .HasColumnName("sync_on_create")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SyncOnCtlFile).HasColumnName("sync_on_ctl_file");

                entity.Property(e => e.SyncOnDelete)
                    .HasColumnName("sync_on_delete")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SyncOnModified)
                    .HasColumnName("sync_on_modified")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<SymFileTriggerRouter>(entity =>
            {
                entity.HasKey(e => new { e.TriggerId, e.RouterId });

                entity.ToTable("sym_file_trigger_router");

                entity.Property(e => e.TriggerId)
                    .HasColumnName("trigger_id")
                    .HasMaxLength(128);

                entity.Property(e => e.RouterId)
                    .HasColumnName("router_id")
                    .HasMaxLength(50);

                entity.Property(e => e.ConflictStrategy)
                    .IsRequired()
                    .HasColumnName("conflict_strategy")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("'source_wins'::character varying");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.InitialLoadEnabled)
                    .HasColumnName("initial_load_enabled")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.TargetBaseDir)
                    .HasColumnName("target_base_dir")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Router)
                    .WithMany(p => p.SymFileTriggerRouter)
                    .HasForeignKey(d => d.RouterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_ftr_2_rtr");

                entity.HasOne(d => d.Trigger)
                    .WithMany(p => p.SymFileTriggerRouter)
                    .HasForeignKey(d => d.TriggerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_ftr_2_ftrg");
            });

            modelBuilder.Entity<SymGrouplet>(entity =>
            {
                entity.HasKey(e => e.GroupletId);

                entity.ToTable("sym_grouplet");

                entity.Property(e => e.GroupletId)
                    .HasColumnName("grouplet_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.GroupletLinkPolicy)
                    .HasColumnName("grouplet_link_policy")
                    .HasDefaultValueSql("'I'::bpchar");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");
            });

            modelBuilder.Entity<SymGroupletLink>(entity =>
            {
                entity.HasKey(e => new { e.GroupletId, e.ExternalId });

                entity.ToTable("sym_grouplet_link");

                entity.Property(e => e.GroupletId)
                    .HasColumnName("grouplet_id")
                    .HasMaxLength(50);

                entity.Property(e => e.ExternalId)
                    .HasColumnName("external_id")
                    .HasMaxLength(255);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.HasOne(d => d.Grouplet)
                    .WithMany(p => p.SymGroupletLink)
                    .HasForeignKey(d => d.GroupletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_gpltlnk_2_gplt");
            });

            modelBuilder.Entity<SymIncomingBatch>(entity =>
            {
                entity.HasKey(e => new { e.BatchId, e.NodeId });

                entity.ToTable("sym_incoming_batch");

                entity.HasIndex(e => e.ErrorFlag)
                    .HasName("sym_idx_ib_in_error");

                entity.HasIndex(e => new { e.CreateTime, e.Status })
                    .HasName("sym_idx_ib_time_status");

                entity.Property(e => e.BatchId).HasColumnName("batch_id");

                entity.Property(e => e.NodeId)
                    .HasColumnName("node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.ByteCount).HasColumnName("byte_count");

                entity.Property(e => e.ChannelId)
                    .HasColumnName("channel_id")
                    .HasMaxLength(128);

                entity.Property(e => e.CommonFlag)
                    .HasColumnName("common_flag")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.DataDeleteRowCount).HasColumnName("data_delete_row_count");

                entity.Property(e => e.DataInsertRowCount).HasColumnName("data_insert_row_count");

                entity.Property(e => e.DataRowCount).HasColumnName("data_row_count");

                entity.Property(e => e.DataUpdateRowCount).HasColumnName("data_update_row_count");

                entity.Property(e => e.ErrorFlag)
                    .HasColumnName("error_flag")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExtractCount).HasColumnName("extract_count");

                entity.Property(e => e.ExtractDeleteRowCount).HasColumnName("extract_delete_row_count");

                entity.Property(e => e.ExtractInsertRowCount).HasColumnName("extract_insert_row_count");

                entity.Property(e => e.ExtractMillis).HasColumnName("extract_millis");

                entity.Property(e => e.ExtractRowCount).HasColumnName("extract_row_count");

                entity.Property(e => e.ExtractUpdateRowCount).HasColumnName("extract_update_row_count");

                entity.Property(e => e.FailedDataId).HasColumnName("failed_data_id");

                entity.Property(e => e.FailedLineNumber).HasColumnName("failed_line_number");

                entity.Property(e => e.FailedRowNumber).HasColumnName("failed_row_number");

                entity.Property(e => e.FallbackInsertCount).HasColumnName("fallback_insert_count");

                entity.Property(e => e.FallbackUpdateCount).HasColumnName("fallback_update_count");

                entity.Property(e => e.FilterMillis).HasColumnName("filter_millis");

                entity.Property(e => e.IgnoreCount).HasColumnName("ignore_count");

                entity.Property(e => e.IgnoreRowCount).HasColumnName("ignore_row_count");

                entity.Property(e => e.LastUpdateHostname)
                    .HasColumnName("last_update_hostname")
                    .HasMaxLength(255);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LoadCount).HasColumnName("load_count");

                entity.Property(e => e.LoadDeleteRowCount).HasColumnName("load_delete_row_count");

                entity.Property(e => e.LoadFlag)
                    .HasColumnName("load_flag")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoadId).HasColumnName("load_id");

                entity.Property(e => e.LoadInsertRowCount).HasColumnName("load_insert_row_count");

                entity.Property(e => e.LoadMillis).HasColumnName("load_millis");

                entity.Property(e => e.LoadRowCount).HasColumnName("load_row_count");

                entity.Property(e => e.LoadUpdateRowCount).HasColumnName("load_update_row_count");

                entity.Property(e => e.MissingDeleteCount).HasColumnName("missing_delete_count");

                entity.Property(e => e.NetworkMillis).HasColumnName("network_millis");

                entity.Property(e => e.OtherRowCount).HasColumnName("other_row_count");

                entity.Property(e => e.ReloadRowCount).HasColumnName("reload_row_count");

                entity.Property(e => e.RouterMillis).HasColumnName("router_millis");

                entity.Property(e => e.SentCount).HasColumnName("sent_count");

                entity.Property(e => e.SkipCount).HasColumnName("skip_count");

                entity.Property(e => e.SqlCode).HasColumnName("sql_code");

                entity.Property(e => e.SqlMessage).HasColumnName("sql_message");

                entity.Property(e => e.SqlState)
                    .HasColumnName("sql_state")
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("character(2)");

                entity.Property(e => e.Summary)
                    .HasColumnName("summary")
                    .HasMaxLength(255);

                entity.Property(e => e.TransformExtractMillis).HasColumnName("transform_extract_millis");

                entity.Property(e => e.TransformLoadMillis).HasColumnName("transform_load_millis");
            });

            modelBuilder.Entity<SymIncomingError>(entity =>
            {
                entity.HasKey(e => new { e.BatchId, e.NodeId, e.FailedRowNumber });

                entity.ToTable("sym_incoming_error");

                entity.Property(e => e.BatchId).HasColumnName("batch_id");

                entity.Property(e => e.NodeId)
                    .HasColumnName("node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.FailedRowNumber).HasColumnName("failed_row_number");

                entity.Property(e => e.BinaryEncoding)
                    .IsRequired()
                    .HasColumnName("binary_encoding")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'HEX'::character varying");

                entity.Property(e => e.ColumnNames)
                    .IsRequired()
                    .HasColumnName("column_names");

                entity.Property(e => e.ConflictId)
                    .HasColumnName("conflict_id")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.CurData).HasColumnName("cur_data");

                entity.Property(e => e.EventType).HasColumnName("event_type");

                entity.Property(e => e.FailedLineNumber).HasColumnName("failed_line_number");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.OldData).HasColumnName("old_data");

                entity.Property(e => e.PkColumnNames)
                    .IsRequired()
                    .HasColumnName("pk_column_names");

                entity.Property(e => e.ResolveData).HasColumnName("resolve_data");

                entity.Property(e => e.ResolveIgnore)
                    .HasColumnName("resolve_ignore")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RowData).HasColumnName("row_data");

                entity.Property(e => e.TargetCatalogName)
                    .HasColumnName("target_catalog_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TargetSchemaName)
                    .HasColumnName("target_schema_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TargetTableName)
                    .IsRequired()
                    .HasColumnName("target_table_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SymJob>(entity =>
            {
                entity.HasKey(e => e.JobName);

                entity.ToTable("sym_job");

                entity.Property(e => e.JobName)
                    .HasColumnName("job_name")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.DefaultAutoStart)
                    .HasColumnName("default_auto_start")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DefaultSchedule)
                    .HasColumnName("default_schedule")
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.JobExpression).HasColumnName("job_expression");

                entity.Property(e => e.JobType)
                    .IsRequired()
                    .HasColumnName("job_type")
                    .HasMaxLength(10);

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.NodeGroupId)
                    .IsRequired()
                    .HasColumnName("node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.RequiresRegistration)
                    .HasColumnName("requires_registration")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<SymLoadFilter>(entity =>
            {
                entity.HasKey(e => e.LoadFilterId);

                entity.ToTable("sym_load_filter");

                entity.Property(e => e.LoadFilterId)
                    .HasColumnName("load_filter_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.AfterWriteScript).HasColumnName("after_write_script");

                entity.Property(e => e.BatchCommitScript).HasColumnName("batch_commit_script");

                entity.Property(e => e.BatchCompleteScript).HasColumnName("batch_complete_script");

                entity.Property(e => e.BatchRollbackScript).HasColumnName("batch_rollback_script");

                entity.Property(e => e.BeforeWriteScript).HasColumnName("before_write_script");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.FailOnError).HasColumnName("fail_on_error");

                entity.Property(e => e.FilterOnDelete)
                    .HasColumnName("filter_on_delete")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.FilterOnInsert)
                    .HasColumnName("filter_on_insert")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.FilterOnUpdate)
                    .HasColumnName("filter_on_update")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.HandleErrorScript).HasColumnName("handle_error_script");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LoadFilterOrder)
                    .HasColumnName("load_filter_order")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.LoadFilterType)
                    .IsRequired()
                    .HasColumnName("load_filter_type")
                    .HasMaxLength(10);

                entity.Property(e => e.SourceNodeGroupId)
                    .IsRequired()
                    .HasColumnName("source_node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.TargetCatalogName)
                    .HasColumnName("target_catalog_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TargetNodeGroupId)
                    .IsRequired()
                    .HasColumnName("target_node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.TargetSchemaName)
                    .HasColumnName("target_schema_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TargetTableName)
                    .HasColumnName("target_table_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SymLock>(entity =>
            {
                entity.HasKey(e => e.LockAction);

                entity.ToTable("sym_lock");

                entity.Property(e => e.LockAction)
                    .HasColumnName("lock_action")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.LastLockTime)
                    .HasColumnName("last_lock_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LastLockingServerId)
                    .HasColumnName("last_locking_server_id")
                    .HasMaxLength(255);

                entity.Property(e => e.LockTime)
                    .HasColumnName("lock_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LockType)
                    .IsRequired()
                    .HasColumnName("lock_type")
                    .HasMaxLength(50);

                entity.Property(e => e.LockingServerId)
                    .HasColumnName("locking_server_id")
                    .HasMaxLength(255);

                entity.Property(e => e.SharedCount).HasColumnName("shared_count");

                entity.Property(e => e.SharedEnable).HasColumnName("shared_enable");
            });

            modelBuilder.Entity<SymMonitor>(entity =>
            {
                entity.HasKey(e => e.MonitorId);

                entity.ToTable("sym_monitor");

                entity.Property(e => e.MonitorId)
                    .HasColumnName("monitor_id")
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Expression).HasColumnName("expression");

                entity.Property(e => e.ExternalId)
                    .IsRequired()
                    .HasColumnName("external_id")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'ALL'::character varying");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.NodeGroupId)
                    .IsRequired()
                    .HasColumnName("node_group_id")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'ALL'::character varying");

                entity.Property(e => e.RunCount).HasColumnName("run_count");

                entity.Property(e => e.RunPeriod).HasColumnName("run_period");

                entity.Property(e => e.SeverityLevel).HasColumnName("severity_level");

                entity.Property(e => e.Threshold).HasColumnName("threshold");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SymMonitorEvent>(entity =>
            {
                entity.HasKey(e => new { e.MonitorId, e.NodeId, e.EventTime });

                entity.ToTable("sym_monitor_event");

                entity.Property(e => e.MonitorId)
                    .HasColumnName("monitor_id")
                    .HasMaxLength(128);

                entity.Property(e => e.NodeId)
                    .HasColumnName("node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.EventTime)
                    .HasColumnName("event_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Details).HasColumnName("details");

                entity.Property(e => e.EventCount).HasColumnName("event_count");

                entity.Property(e => e.EventValue).HasColumnName("event_value");

                entity.Property(e => e.HostName)
                    .HasColumnName("host_name")
                    .HasMaxLength(60);

                entity.Property(e => e.IsNotified).HasColumnName("is_notified");

                entity.Property(e => e.IsResolved).HasColumnName("is_resolved");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.SeverityLevel).HasColumnName("severity_level");

                entity.Property(e => e.Threshold).HasColumnName("threshold");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SymNode>(entity =>
            {
                entity.HasKey(e => e.NodeId);

                entity.ToTable("sym_node");

                entity.Property(e => e.NodeId)
                    .HasColumnName("node_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.BatchInErrorCount)
                    .HasColumnName("batch_in_error_count")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BatchToSendCount)
                    .HasColumnName("batch_to_send_count")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ConfigVersion)
                    .HasColumnName("config_version")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedAtNodeId)
                    .HasColumnName("created_at_node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.DatabaseType)
                    .HasColumnName("database_type")
                    .HasMaxLength(50);

                entity.Property(e => e.DatabaseVersion)
                    .HasColumnName("database_version")
                    .HasMaxLength(50);

                entity.Property(e => e.DeploymentSubType)
                    .HasColumnName("deployment_sub_type")
                    .HasMaxLength(50);

                entity.Property(e => e.DeploymentType)
                    .HasColumnName("deployment_type")
                    .HasMaxLength(50);

                entity.Property(e => e.ExternalId)
                    .IsRequired()
                    .HasColumnName("external_id")
                    .HasMaxLength(255);

                entity.Property(e => e.HeartbeatTime)
                    .HasColumnName("heartbeat_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.NodeGroupId)
                    .IsRequired()
                    .HasColumnName("node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.SchemaVersion)
                    .HasColumnName("schema_version")
                    .HasMaxLength(50);

                entity.Property(e => e.SymmetricVersion)
                    .HasColumnName("symmetric_version")
                    .HasMaxLength(50);

                entity.Property(e => e.SyncEnabled)
                    .HasColumnName("sync_enabled")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SyncUrl)
                    .HasColumnName("sync_url")
                    .HasMaxLength(255);

                entity.Property(e => e.TimezoneOffset)
                    .HasColumnName("timezone_offset")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<SymNodeChannelCtl>(entity =>
            {
                entity.HasKey(e => new { e.NodeId, e.ChannelId });

                entity.ToTable("sym_node_channel_ctl");

                entity.Property(e => e.NodeId)
                    .HasColumnName("node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.ChannelId)
                    .HasColumnName("channel_id")
                    .HasMaxLength(128);

                entity.Property(e => e.IgnoreEnabled)
                    .HasColumnName("ignore_enabled")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LastExtractTime)
                    .HasColumnName("last_extract_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.SuspendEnabled)
                    .HasColumnName("suspend_enabled")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SymNodeCommunication>(entity =>
            {
                entity.HasKey(e => new { e.NodeId, e.Queue, e.CommunicationType });

                entity.ToTable("sym_node_communication");

                entity.Property(e => e.NodeId)
                    .HasColumnName("node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Queue)
                    .HasColumnName("queue")
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'default'::character varying");

                entity.Property(e => e.CommunicationType)
                    .HasColumnName("communication_type")
                    .HasMaxLength(10);

                entity.Property(e => e.BatchToSendCount)
                    .HasColumnName("batch_to_send_count")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FailCount)
                    .HasColumnName("fail_count")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LastLockMillis)
                    .HasColumnName("last_lock_millis")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LastLockTime)
                    .HasColumnName("last_lock_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LockTime)
                    .HasColumnName("lock_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LockingServerId)
                    .HasColumnName("locking_server_id")
                    .HasMaxLength(255);

                entity.Property(e => e.NodePriority)
                    .HasColumnName("node_priority")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SkipCount)
                    .HasColumnName("skip_count")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SuccessCount)
                    .HasColumnName("success_count")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TotalFailCount)
                    .HasColumnName("total_fail_count")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TotalFailMillis)
                    .HasColumnName("total_fail_millis")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TotalSuccessCount)
                    .HasColumnName("total_success_count")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TotalSuccessMillis)
                    .HasColumnName("total_success_millis")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SymNodeGroup>(entity =>
            {
                entity.HasKey(e => e.NodeGroupId);

                entity.ToTable("sym_node_group");

                entity.Property(e => e.NodeGroupId)
                    .HasColumnName("node_group_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");
            });

            modelBuilder.Entity<SymNodeGroupChannelWnd>(entity =>
            {
                entity.HasKey(e => new { e.NodeGroupId, e.ChannelId, e.StartTime, e.EndTime });

                entity.ToTable("sym_node_group_channel_wnd");

                entity.Property(e => e.NodeGroupId)
                    .HasColumnName("node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.ChannelId)
                    .HasColumnName("channel_id")
                    .HasMaxLength(128);

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Enabled).HasColumnName("enabled");
            });

            modelBuilder.Entity<SymNodeGroupLink>(entity =>
            {
                entity.HasKey(e => new { e.SourceNodeGroupId, e.TargetNodeGroupId });

                entity.ToTable("sym_node_group_link");

                entity.Property(e => e.SourceNodeGroupId)
                    .HasColumnName("source_node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.TargetNodeGroupId)
                    .HasColumnName("target_node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.DataEventAction)
                    .HasColumnName("data_event_action")
                    .HasDefaultValueSql("'W'::bpchar");

                entity.Property(e => e.IsReversible).HasColumnName("is_reversible");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.SyncConfigEnabled)
                    .HasColumnName("sync_config_enabled")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.SourceNodeGroup)
                    .WithMany(p => p.SymNodeGroupLinkSourceNodeGroup)
                    .HasForeignKey(d => d.SourceNodeGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_lnk_2_grp_src");

                entity.HasOne(d => d.TargetNodeGroup)
                    .WithMany(p => p.SymNodeGroupLinkTargetNodeGroup)
                    .HasForeignKey(d => d.TargetNodeGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_lnk_2_grp_tgt");
            });

            modelBuilder.Entity<SymNodeHost>(entity =>
            {
                entity.HasKey(e => new { e.NodeId, e.HostName });

                entity.ToTable("sym_node_host");

                entity.Property(e => e.NodeId)
                    .HasColumnName("node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.HostName)
                    .HasColumnName("host_name")
                    .HasMaxLength(60);

                entity.Property(e => e.AvailableProcessors)
                    .HasColumnName("available_processors")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.FreeMemoryBytes)
                    .HasColumnName("free_memory_bytes")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.HeartbeatTime)
                    .HasColumnName("heartbeat_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.InstanceId)
                    .HasColumnName("instance_id")
                    .HasMaxLength(60);

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(50);

                entity.Property(e => e.JavaVendor)
                    .HasColumnName("java_vendor")
                    .HasMaxLength(255);

                entity.Property(e => e.JavaVersion)
                    .HasColumnName("java_version")
                    .HasMaxLength(50);

                entity.Property(e => e.JdbcVersion)
                    .HasColumnName("jdbc_version")
                    .HasMaxLength(255);

                entity.Property(e => e.LastRestartTime)
                    .HasColumnName("last_restart_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.MaxMemoryBytes)
                    .HasColumnName("max_memory_bytes")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OsArch)
                    .HasColumnName("os_arch")
                    .HasMaxLength(50);

                entity.Property(e => e.OsName)
                    .HasColumnName("os_name")
                    .HasMaxLength(50);

                entity.Property(e => e.OsUser)
                    .HasColumnName("os_user")
                    .HasMaxLength(50);

                entity.Property(e => e.OsVersion)
                    .HasColumnName("os_version")
                    .HasMaxLength(50);

                entity.Property(e => e.SymmetricVersion)
                    .HasColumnName("symmetric_version")
                    .HasMaxLength(50);

                entity.Property(e => e.TimezoneOffset)
                    .HasColumnName("timezone_offset")
                    .HasMaxLength(6);

                entity.Property(e => e.TotalMemoryBytes)
                    .HasColumnName("total_memory_bytes")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SymNodeHostChannelStats>(entity =>
            {
                entity.HasKey(e => new { e.NodeId, e.HostName, e.ChannelId, e.StartTime, e.EndTime });

                entity.ToTable("sym_node_host_channel_stats");

                entity.HasIndex(e => new { e.NodeId, e.StartTime, e.EndTime })
                    .HasName("sym_idx_nd_hst_chnl_sts");

                entity.Property(e => e.NodeId)
                    .HasColumnName("node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.HostName)
                    .HasColumnName("host_name")
                    .HasMaxLength(60);

                entity.Property(e => e.ChannelId)
                    .HasColumnName("channel_id")
                    .HasMaxLength(128);

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.DataBytesExtracted)
                    .HasColumnName("data_bytes_extracted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DataBytesLoaded)
                    .HasColumnName("data_bytes_loaded")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DataBytesSent)
                    .HasColumnName("data_bytes_sent")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DataEventInserted)
                    .HasColumnName("data_event_inserted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DataExtracted)
                    .HasColumnName("data_extracted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DataExtractedErrors)
                    .HasColumnName("data_extracted_errors")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DataLoaded)
                    .HasColumnName("data_loaded")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DataLoadedErrors)
                    .HasColumnName("data_loaded_errors")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DataRouted)
                    .HasColumnName("data_routed")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DataSent)
                    .HasColumnName("data_sent")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DataSentErrors)
                    .HasColumnName("data_sent_errors")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DataUnrouted)
                    .HasColumnName("data_unrouted")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<SymNodeHostJobStats>(entity =>
            {
                entity.HasKey(e => new { e.NodeId, e.HostName, e.JobName, e.StartTime, e.EndTime });

                entity.ToTable("sym_node_host_job_stats");

                entity.HasIndex(e => new { e.NodeId, e.StartTime, e.EndTime })
                    .HasName("sym_idx_nd_hst_job");

                entity.Property(e => e.NodeId)
                    .HasColumnName("node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.HostName)
                    .HasColumnName("host_name")
                    .HasMaxLength(60);

                entity.Property(e => e.JobName)
                    .HasColumnName("job_name")
                    .HasMaxLength(50);

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.ProcessedCount)
                    .HasColumnName("processed_count")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetNodeCount)
                    .HasColumnName("target_node_count")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetNodeId)
                    .HasColumnName("target_node_id")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SymNodeHostStats>(entity =>
            {
                entity.HasKey(e => new { e.NodeId, e.HostName, e.StartTime, e.EndTime });

                entity.ToTable("sym_node_host_stats");

                entity.HasIndex(e => new { e.NodeId, e.StartTime, e.EndTime })
                    .HasName("sym_idx_nd_hst_sts");

                entity.Property(e => e.NodeId)
                    .HasColumnName("node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.HostName)
                    .HasColumnName("host_name")
                    .HasMaxLength(60);

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.NodesDisabled)
                    .HasColumnName("nodes_disabled")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NodesLoaded)
                    .HasColumnName("nodes_loaded")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NodesPulled)
                    .HasColumnName("nodes_pulled")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NodesPushed)
                    .HasColumnName("nodes_pushed")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NodesRegistered)
                    .HasColumnName("nodes_registered")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NodesRejected)
                    .HasColumnName("nodes_rejected")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PurgedBatchIncomingRows)
                    .HasColumnName("purged_batch_incoming_rows")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PurgedBatchOutgoingRows)
                    .HasColumnName("purged_batch_outgoing_rows")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PurgedDataEventRows)
                    .HasColumnName("purged_data_event_rows")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PurgedDataRows)
                    .HasColumnName("purged_data_rows")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Restarted).HasColumnName("restarted");

                entity.Property(e => e.TotalNodesPullTime)
                    .HasColumnName("total_nodes_pull_time")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TotalNodesPushTime)
                    .HasColumnName("total_nodes_push_time")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TriggersCreatedCount).HasColumnName("triggers_created_count");

                entity.Property(e => e.TriggersRebuiltCount).HasColumnName("triggers_rebuilt_count");

                entity.Property(e => e.TriggersRemovedCount).HasColumnName("triggers_removed_count");
            });

            modelBuilder.Entity<SymNodeIdentity>(entity =>
            {
                entity.HasKey(e => e.NodeId);

                entity.ToTable("sym_node_identity");

                entity.Property(e => e.NodeId)
                    .HasColumnName("node_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Node)
                    .WithOne(p => p.SymNodeIdentity)
                    .HasForeignKey<SymNodeIdentity>(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_ident_2_node");
            });

            modelBuilder.Entity<SymNodeSecurity>(entity =>
            {
                entity.HasKey(e => e.NodeId);

                entity.ToTable("sym_node_security");

                entity.Property(e => e.NodeId)
                    .HasColumnName("node_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAtNodeId)
                    .HasColumnName("created_at_node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.InitialLoadCreateBy)
                    .HasColumnName("initial_load_create_by")
                    .HasMaxLength(255);

                entity.Property(e => e.InitialLoadEnabled)
                    .HasColumnName("initial_load_enabled")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.InitialLoadId).HasColumnName("initial_load_id");

                entity.Property(e => e.InitialLoadTime)
                    .HasColumnName("initial_load_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.NodePassword)
                    .IsRequired()
                    .HasColumnName("node_password")
                    .HasMaxLength(50);

                entity.Property(e => e.RegistrationEnabled)
                    .HasColumnName("registration_enabled")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RegistrationTime)
                    .HasColumnName("registration_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.RevInitialLoadCreateBy)
                    .HasColumnName("rev_initial_load_create_by")
                    .HasMaxLength(255);

                entity.Property(e => e.RevInitialLoadEnabled)
                    .HasColumnName("rev_initial_load_enabled")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RevInitialLoadId).HasColumnName("rev_initial_load_id");

                entity.Property(e => e.RevInitialLoadTime)
                    .HasColumnName("rev_initial_load_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.HasOne(d => d.Node)
                    .WithOne(p => p.SymNodeSecurity)
                    .HasForeignKey<SymNodeSecurity>(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_sec_2_node");
            });

            modelBuilder.Entity<SymNotification>(entity =>
            {
                entity.HasKey(e => e.NotificationId);

                entity.ToTable("sym_notification");

                entity.Property(e => e.NotificationId)
                    .HasColumnName("notification_id")
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Expression).HasColumnName("expression");

                entity.Property(e => e.ExternalId)
                    .IsRequired()
                    .HasColumnName("external_id")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'ALL'::character varying");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.NodeGroupId)
                    .IsRequired()
                    .HasColumnName("node_group_id")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'ALL'::character varying");

                entity.Property(e => e.SeverityLevel).HasColumnName("severity_level");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SymOutgoingBatch>(entity =>
            {
                entity.HasKey(e => new { e.BatchId, e.NodeId });

                entity.ToTable("sym_outgoing_batch");

                entity.HasIndex(e => e.ErrorFlag)
                    .HasName("sym_idx_ob_in_error");

                entity.HasIndex(e => e.Status)
                    .HasName("sym_idx_ob_status");

                entity.HasIndex(e => new { e.NodeId, e.Status })
                    .HasName("sym_idx_ob_node_status");

                entity.Property(e => e.BatchId).HasColumnName("batch_id");

                entity.Property(e => e.NodeId)
                    .HasColumnName("node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.ByteCount).HasColumnName("byte_count");

                entity.Property(e => e.ChannelId)
                    .HasColumnName("channel_id")
                    .HasMaxLength(128);

                entity.Property(e => e.CommonFlag)
                    .HasColumnName("common_flag")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(255);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.DataDeleteRowCount).HasColumnName("data_delete_row_count");

                entity.Property(e => e.DataInsertRowCount).HasColumnName("data_insert_row_count");

                entity.Property(e => e.DataRowCount).HasColumnName("data_row_count");

                entity.Property(e => e.DataUpdateRowCount).HasColumnName("data_update_row_count");

                entity.Property(e => e.ErrorFlag)
                    .HasColumnName("error_flag")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExtractCount).HasColumnName("extract_count");

                entity.Property(e => e.ExtractDeleteRowCount).HasColumnName("extract_delete_row_count");

                entity.Property(e => e.ExtractInsertRowCount).HasColumnName("extract_insert_row_count");

                entity.Property(e => e.ExtractJobFlag)
                    .HasColumnName("extract_job_flag")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExtractMillis).HasColumnName("extract_millis");

                entity.Property(e => e.ExtractRowCount).HasColumnName("extract_row_count");

                entity.Property(e => e.ExtractStartTime)
                    .HasColumnName("extract_start_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.ExtractUpdateRowCount).HasColumnName("extract_update_row_count");

                entity.Property(e => e.FailedDataId).HasColumnName("failed_data_id");

                entity.Property(e => e.FailedLineNumber).HasColumnName("failed_line_number");

                entity.Property(e => e.FallbackInsertCount).HasColumnName("fallback_insert_count");

                entity.Property(e => e.FallbackUpdateCount).HasColumnName("fallback_update_count");

                entity.Property(e => e.FilterMillis).HasColumnName("filter_millis");

                entity.Property(e => e.IgnoreCount).HasColumnName("ignore_count");

                entity.Property(e => e.IgnoreRowCount).HasColumnName("ignore_row_count");

                entity.Property(e => e.LastUpdateHostname)
                    .HasColumnName("last_update_hostname")
                    .HasMaxLength(255);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LoadCount).HasColumnName("load_count");

                entity.Property(e => e.LoadDeleteRowCount).HasColumnName("load_delete_row_count");

                entity.Property(e => e.LoadFlag)
                    .HasColumnName("load_flag")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoadId).HasColumnName("load_id");

                entity.Property(e => e.LoadInsertRowCount).HasColumnName("load_insert_row_count");

                entity.Property(e => e.LoadMillis).HasColumnName("load_millis");

                entity.Property(e => e.LoadRowCount).HasColumnName("load_row_count");

                entity.Property(e => e.LoadStartTime)
                    .HasColumnName("load_start_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LoadUpdateRowCount).HasColumnName("load_update_row_count");

                entity.Property(e => e.MissingDeleteCount).HasColumnName("missing_delete_count");

                entity.Property(e => e.NetworkMillis).HasColumnName("network_millis");

                entity.Property(e => e.OtherRowCount).HasColumnName("other_row_count");

                entity.Property(e => e.ReloadRowCount).HasColumnName("reload_row_count");

                entity.Property(e => e.RouterMillis).HasColumnName("router_millis");

                entity.Property(e => e.SentCount).HasColumnName("sent_count");

                entity.Property(e => e.SkipCount).HasColumnName("skip_count");

                entity.Property(e => e.SqlCode).HasColumnName("sql_code");

                entity.Property(e => e.SqlMessage).HasColumnName("sql_message");

                entity.Property(e => e.SqlState)
                    .HasColumnName("sql_state")
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("character(2)");

                entity.Property(e => e.Summary)
                    .HasColumnName("summary")
                    .HasMaxLength(255);

                entity.Property(e => e.TotalExtractMillis).HasColumnName("total_extract_millis");

                entity.Property(e => e.TotalLoadMillis).HasColumnName("total_load_millis");

                entity.Property(e => e.TransferStartTime)
                    .HasColumnName("transfer_start_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.TransformExtractMillis).HasColumnName("transform_extract_millis");

                entity.Property(e => e.TransformLoadMillis).HasColumnName("transform_load_millis");
            });

            modelBuilder.Entity<SymParameter>(entity =>
            {
                entity.HasKey(e => new { e.ExternalId, e.NodeGroupId, e.ParamKey });

                entity.ToTable("sym_parameter");

                entity.Property(e => e.ExternalId)
                    .HasColumnName("external_id")
                    .HasMaxLength(255);

                entity.Property(e => e.NodeGroupId)
                    .HasColumnName("node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.ParamKey)
                    .HasColumnName("param_key")
                    .HasMaxLength(80);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.ParamValue).HasColumnName("param_value");
            });

            modelBuilder.Entity<SymRegistrationRedirect>(entity =>
            {
                entity.HasKey(e => e.RegistrantExternalId);

                entity.ToTable("sym_registration_redirect");

                entity.Property(e => e.RegistrantExternalId)
                    .HasColumnName("registrant_external_id")
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.RegistrationNodeId)
                    .IsRequired()
                    .HasColumnName("registration_node_id")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SymRegistrationRequest>(entity =>
            {
                entity.HasKey(e => new { e.NodeGroupId, e.ExternalId, e.CreateTime });

                entity.ToTable("sym_registration_request");

                entity.HasIndex(e => e.Status)
                    .HasName("sym_idx_reg_req_2");

                entity.HasIndex(e => new { e.NodeGroupId, e.ExternalId, e.Status, e.HostName, e.IpAddress })
                    .HasName("sym_idx_reg_req_1");

                entity.Property(e => e.NodeGroupId)
                    .HasColumnName("node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.ExternalId)
                    .HasColumnName("external_id")
                    .HasMaxLength(255);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.AttemptCount)
                    .HasColumnName("attempt_count")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ErrorMessage).HasColumnName("error_message");

                entity.Property(e => e.HostName)
                    .IsRequired()
                    .HasColumnName("host_name")
                    .HasMaxLength(60);

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasColumnName("ip_address")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.RegisteredNodeId)
                    .HasColumnName("registered_node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("character(2)");
            });

            modelBuilder.Entity<SymRouter>(entity =>
            {
                entity.HasKey(e => e.RouterId);

                entity.ToTable("sym_router");

                entity.Property(e => e.RouterId)
                    .HasColumnName("router_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.RouterExpression).HasColumnName("router_expression");

                entity.Property(e => e.RouterType)
                    .HasColumnName("router_type")
                    .HasMaxLength(50);

                entity.Property(e => e.SourceNodeGroupId)
                    .IsRequired()
                    .HasColumnName("source_node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.SyncOnDelete)
                    .HasColumnName("sync_on_delete")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SyncOnInsert)
                    .HasColumnName("sync_on_insert")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SyncOnUpdate)
                    .HasColumnName("sync_on_update")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.TargetCatalogName)
                    .HasColumnName("target_catalog_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TargetNodeGroupId)
                    .IsRequired()
                    .HasColumnName("target_node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.TargetSchemaName)
                    .HasColumnName("target_schema_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TargetTableName)
                    .HasColumnName("target_table_name")
                    .HasMaxLength(255);

                entity.Property(e => e.UseSourceCatalogSchema)
                    .HasColumnName("use_source_catalog_schema")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.SymNodeGroupLink)
                    .WithMany(p => p.SymRouter)
                    .HasForeignKey(d => new { d.SourceNodeGroupId, d.TargetNodeGroupId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_rt_2_grp_lnk");
            });

            modelBuilder.Entity<SymSequence>(entity =>
            {
                entity.HasKey(e => e.SequenceName);

                entity.ToTable("sym_sequence");

                entity.Property(e => e.SequenceName)
                    .HasColumnName("sequence_name")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CacheSize).HasColumnName("cache_size");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.CurrentValue).HasColumnName("current_value");

                entity.Property(e => e.CycleFlag)
                    .HasColumnName("cycle_flag")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IncrementBy)
                    .HasColumnName("increment_by")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.MaxValue)
                    .HasColumnName("max_value")
                    .HasDefaultValueSql("'9999999999'::bigint");

                entity.Property(e => e.MinValue)
                    .HasColumnName("min_value")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<SymTableReloadRequest>(entity =>
            {
                entity.HasKey(e => new { e.TargetNodeId, e.SourceNodeId, e.TriggerId, e.RouterId, e.CreateTime });

                entity.ToTable("sym_table_reload_request");

                entity.Property(e => e.TargetNodeId)
                    .HasColumnName("target_node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.SourceNodeId)
                    .HasColumnName("source_node_id")
                    .HasMaxLength(50);

                entity.Property(e => e.TriggerId)
                    .HasColumnName("trigger_id")
                    .HasMaxLength(128);

                entity.Property(e => e.RouterId)
                    .HasColumnName("router_id")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.BeforeCustomSql).HasColumnName("before_custom_sql");

                entity.Property(e => e.ChannelId)
                    .HasColumnName("channel_id")
                    .HasMaxLength(128);

                entity.Property(e => e.CreateTable).HasColumnName("create_table");

                entity.Property(e => e.DeleteFirst).HasColumnName("delete_first");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LoadId).HasColumnName("load_id");

                entity.Property(e => e.Processed).HasColumnName("processed");

                entity.Property(e => e.ReloadSelect).HasColumnName("reload_select");

                entity.Property(e => e.ReloadTime)
                    .HasColumnName("reload_time")
                    .HasColumnType("timestamp(6) without time zone");
            });

            modelBuilder.Entity<SymTransformColumn>(entity =>
            {
                entity.HasKey(e => new { e.TransformId, e.IncludeOn, e.TargetColumnName });

                entity.ToTable("sym_transform_column");

                entity.Property(e => e.TransformId)
                    .HasColumnName("transform_id")
                    .HasMaxLength(50);

                entity.Property(e => e.IncludeOn)
                    .HasColumnName("include_on")
                    .HasDefaultValueSql("'*'::bpchar");

                entity.Property(e => e.TargetColumnName)
                    .HasColumnName("target_column_name")
                    .HasMaxLength(128);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SourceColumnName)
                    .HasColumnName("source_column_name")
                    .HasMaxLength(128);

                entity.Property(e => e.TransformExpression).HasColumnName("transform_expression");

                entity.Property(e => e.TransformOrder)
                    .HasColumnName("transform_order")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.TransformType)
                    .HasColumnName("transform_type")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'copy'::character varying");
            });

            modelBuilder.Entity<SymTransformTable>(entity =>
            {
                entity.HasKey(e => new { e.TransformId, e.SourceNodeGroupId, e.TargetNodeGroupId });

                entity.ToTable("sym_transform_table");

                entity.Property(e => e.TransformId)
                    .HasColumnName("transform_id")
                    .HasMaxLength(50);

                entity.Property(e => e.SourceNodeGroupId)
                    .HasColumnName("source_node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.TargetNodeGroupId)
                    .HasColumnName("target_node_group_id")
                    .HasMaxLength(50);

                entity.Property(e => e.ColumnPolicy)
                    .IsRequired()
                    .HasColumnName("column_policy")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'SPECIFIED'::character varying");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.DeleteAction)
                    .IsRequired()
                    .HasColumnName("delete_action")
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.SourceCatalogName)
                    .HasColumnName("source_catalog_name")
                    .HasMaxLength(255);

                entity.Property(e => e.SourceSchemaName)
                    .HasColumnName("source_schema_name")
                    .HasMaxLength(255);

                entity.Property(e => e.SourceTableName)
                    .IsRequired()
                    .HasColumnName("source_table_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TargetCatalogName)
                    .HasColumnName("target_catalog_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TargetSchemaName)
                    .HasColumnName("target_schema_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TargetTableName)
                    .HasColumnName("target_table_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TransformOrder)
                    .HasColumnName("transform_order")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.TransformPoint)
                    .IsRequired()
                    .HasColumnName("transform_point")
                    .HasMaxLength(10);

                entity.Property(e => e.UpdateAction)
                    .IsRequired()
                    .HasColumnName("update_action")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'UPDATE_COL'::character varying");

                entity.Property(e => e.UpdateFirst)
                    .HasColumnName("update_first")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.SymNodeGroupLink)
                    .WithMany(p => p.SymTransformTable)
                    .HasForeignKey(d => new { d.SourceNodeGroupId, d.TargetNodeGroupId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_tt_2_grp_lnk");
            });

            modelBuilder.Entity<SymTrigger>(entity =>
            {
                entity.HasKey(e => e.TriggerId);

                entity.ToTable("sym_trigger");

                entity.Property(e => e.TriggerId)
                    .HasColumnName("trigger_id")
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.ChannelExpression).HasColumnName("channel_expression");

                entity.Property(e => e.ChannelId)
                    .IsRequired()
                    .HasColumnName("channel_id")
                    .HasMaxLength(128);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.CustomBeforeDeleteText).HasColumnName("custom_before_delete_text");

                entity.Property(e => e.CustomBeforeInsertText).HasColumnName("custom_before_insert_text");

                entity.Property(e => e.CustomBeforeUpdateText).HasColumnName("custom_before_update_text");

                entity.Property(e => e.CustomOnDeleteText).HasColumnName("custom_on_delete_text");

                entity.Property(e => e.CustomOnInsertText).HasColumnName("custom_on_insert_text");

                entity.Property(e => e.CustomOnUpdateText).HasColumnName("custom_on_update_text");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ExcludedColumnNames).HasColumnName("excluded_column_names");

                entity.Property(e => e.ExternalSelect).HasColumnName("external_select");

                entity.Property(e => e.IncludedColumnNames).HasColumnName("included_column_names");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.NameForDeleteTrigger)
                    .HasColumnName("name_for_delete_trigger")
                    .HasMaxLength(255);

                entity.Property(e => e.NameForInsertTrigger)
                    .HasColumnName("name_for_insert_trigger")
                    .HasMaxLength(255);

                entity.Property(e => e.NameForUpdateTrigger)
                    .HasColumnName("name_for_update_trigger")
                    .HasMaxLength(255);

                entity.Property(e => e.ReloadChannelId)
                    .IsRequired()
                    .HasColumnName("reload_channel_id")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("'reload'::character varying");

                entity.Property(e => e.SourceCatalogName)
                    .HasColumnName("source_catalog_name")
                    .HasMaxLength(255);

                entity.Property(e => e.SourceSchemaName)
                    .HasColumnName("source_schema_name")
                    .HasMaxLength(255);

                entity.Property(e => e.SourceTableName)
                    .IsRequired()
                    .HasColumnName("source_table_name")
                    .HasMaxLength(255);

                entity.Property(e => e.StreamRow).HasColumnName("stream_row");

                entity.Property(e => e.SyncKeyNames).HasColumnName("sync_key_names");

                entity.Property(e => e.SyncOnDelete)
                    .HasColumnName("sync_on_delete")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SyncOnDeleteCondition).HasColumnName("sync_on_delete_condition");

                entity.Property(e => e.SyncOnIncomingBatch).HasColumnName("sync_on_incoming_batch");

                entity.Property(e => e.SyncOnInsert)
                    .HasColumnName("sync_on_insert")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SyncOnInsertCondition).HasColumnName("sync_on_insert_condition");

                entity.Property(e => e.SyncOnUpdate)
                    .HasColumnName("sync_on_update")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SyncOnUpdateCondition).HasColumnName("sync_on_update_condition");

                entity.Property(e => e.TxIdExpression).HasColumnName("tx_id_expression");

                entity.Property(e => e.UseCaptureLobs).HasColumnName("use_capture_lobs");

                entity.Property(e => e.UseCaptureOldData)
                    .HasColumnName("use_capture_old_data")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UseHandleKeyUpdates)
                    .HasColumnName("use_handle_key_updates")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UseStreamLobs).HasColumnName("use_stream_lobs");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.SymTriggerChannel)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_trg_2_chnl");

                entity.HasOne(d => d.ReloadChannel)
                    .WithMany(p => p.SymTriggerReloadChannel)
                    .HasForeignKey(d => d.ReloadChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_trg_2_rld_chnl");
            });

            modelBuilder.Entity<SymTriggerHist>(entity =>
            {
                entity.HasKey(e => e.TriggerHistId);

                entity.ToTable("sym_trigger_hist");

                entity.HasIndex(e => new { e.TriggerId, e.InactiveTime })
                    .HasName("sym_idx_trigg_hist_1");

                entity.Property(e => e.TriggerHistId)
                    .HasColumnName("trigger_hist_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ColumnNames)
                    .IsRequired()
                    .HasColumnName("column_names");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.ErrorMessage).HasColumnName("error_message");

                entity.Property(e => e.InactiveTime)
                    .HasColumnName("inactive_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LastTriggerBuildReason).HasColumnName("last_trigger_build_reason");

                entity.Property(e => e.NameForDeleteTrigger)
                    .HasColumnName("name_for_delete_trigger")
                    .HasMaxLength(255);

                entity.Property(e => e.NameForInsertTrigger)
                    .HasColumnName("name_for_insert_trigger")
                    .HasMaxLength(255);

                entity.Property(e => e.NameForUpdateTrigger)
                    .HasColumnName("name_for_update_trigger")
                    .HasMaxLength(255);

                entity.Property(e => e.PkColumnNames)
                    .IsRequired()
                    .HasColumnName("pk_column_names");

                entity.Property(e => e.SourceCatalogName)
                    .HasColumnName("source_catalog_name")
                    .HasMaxLength(255);

                entity.Property(e => e.SourceSchemaName)
                    .HasColumnName("source_schema_name")
                    .HasMaxLength(255);

                entity.Property(e => e.SourceTableName)
                    .IsRequired()
                    .HasColumnName("source_table_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TableHash).HasColumnName("table_hash");

                entity.Property(e => e.TriggerId)
                    .IsRequired()
                    .HasColumnName("trigger_id")
                    .HasMaxLength(128);

                entity.Property(e => e.TriggerRowHash).HasColumnName("trigger_row_hash");

                entity.Property(e => e.TriggerTemplateHash).HasColumnName("trigger_template_hash");
            });

            modelBuilder.Entity<SymTriggerRouter>(entity =>
            {
                entity.HasKey(e => new { e.TriggerId, e.RouterId });

                entity.ToTable("sym_trigger_router");

                entity.Property(e => e.TriggerId)
                    .HasColumnName("trigger_id")
                    .HasMaxLength(128);

                entity.Property(e => e.RouterId)
                    .HasColumnName("router_id")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.InitialLoadDeleteStmt).HasColumnName("initial_load_delete_stmt");

                entity.Property(e => e.InitialLoadOrder)
                    .HasColumnName("initial_load_order")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.InitialLoadSelect).HasColumnName("initial_load_select");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.PingBackEnabled).HasColumnName("ping_back_enabled");

                entity.HasOne(d => d.Router)
                    .WithMany(p => p.SymTriggerRouter)
                    .HasForeignKey(d => d.RouterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_tr_2_rtr");

                entity.HasOne(d => d.Trigger)
                    .WithMany(p => p.SymTriggerRouter)
                    .HasForeignKey(d => d.TriggerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_tr_2_trg");
            });

            modelBuilder.Entity<SymTriggerRouterGrouplet>(entity =>
            {
                entity.HasKey(e => new { e.GroupletId, e.TriggerId, e.RouterId, e.AppliesWhen });

                entity.ToTable("sym_trigger_router_grouplet");

                entity.Property(e => e.GroupletId)
                    .HasColumnName("grouplet_id")
                    .HasMaxLength(50);

                entity.Property(e => e.TriggerId)
                    .HasColumnName("trigger_id")
                    .HasMaxLength(128);

                entity.Property(e => e.RouterId)
                    .HasColumnName("router_id")
                    .HasMaxLength(50);

                entity.Property(e => e.AppliesWhen).HasColumnName("applies_when");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.LastUpdateBy)
                    .HasColumnName("last_update_by")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("last_update_time")
                    .HasColumnType("timestamp(6) without time zone");

                entity.HasOne(d => d.Grouplet)
                    .WithMany(p => p.SymTriggerRouterGrouplet)
                    .HasForeignKey(d => d.GroupletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_trgplt_2_gplt");

                entity.HasOne(d => d.SymTriggerRouter)
                    .WithMany(p => p.SymTriggerRouterGrouplet)
                    .HasForeignKey(d => new { d.TriggerId, d.RouterId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sym_fk_trgplt_2_tr");
            });
        }

        private void SqlModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

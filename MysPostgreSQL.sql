CREATE TABLE "Channel" (
"Id" int4 NOT NULL DEFAULT nextval('"Channel_Id_seq"'::regclass),
"ChannelId" varchar(128) COLLATE "default" NOT NULL,
"Description" varchar(255) COLLATE "default",
CONSTRAINT "Channel_pkey" PRIMARY KEY ("Id") ,
CONSTRAINT "UQ__Channel__38C3E815BDE93267" UNIQUE ("ChannelId")
)
WITHOUT OIDS;

ALTER TABLE "Channel" OWNER TO "postgres";

CREATE TABLE "Node" (
"Id" int4 NOT NULL DEFAULT nextval('"Node_Id_seq"'::regclass),
"NodeGroupId" int4 NOT NULL,
"DatabaseType" int4 NOT NULL,
"DatabaseHost" varchar(16) COLLATE "default",
"DatabaseName" varchar(16) COLLATE "default",
"DatabaseUser" varchar(16) COLLATE "default",
"DatabasePassword" varchar(16) COLLATE "default",
"SyncUrlPort" varchar(4) COLLATE "default",
"ExternalId" varchar(8) COLLATE "default" NOT NULL,
"JobPurgePeriodTimeMs" int4 DEFAULT 7200000,
"JobRoutingPeriodTimeMs" int4 DEFAULT 5000,
"JobPushPeriodTimeMs" int4 DEFAULT 10000,
"JobPullPeriodTimeMs" int4 DEFAULT 10000,
"NodePassword" varchar(50) COLLATE "default",
"Version" int4 NOT NULL DEFAULT 0,
"InitialLoadCreateFirst" bool NOT NULL,
CONSTRAINT "Node_pkey" PRIMARY KEY ("Id") ,
CONSTRAINT "UQ__Node__599A6201BA246948" UNIQUE ("NodeGroupId", "ExternalId")
)
WITHOUT OIDS;

ALTER TABLE "Node" OWNER TO "postgres";

CREATE TABLE "NodeGroup" (
"Id" int4 NOT NULL DEFAULT nextval('"NodeGroup_Id_seq"'::regclass),
"ProjectId" int4 NOT NULL,
"NodeGroupId" varchar(50) COLLATE "default" NOT NULL,
"Description" varchar(255) COLLATE "default",
CONSTRAINT "NodeGroup_pkey" PRIMARY KEY ("Id") ,
CONSTRAINT "UQ__NodeGrou__2B71BB70E8EC1C0F" UNIQUE ("NodeGroupId")
)
WITHOUT OIDS;

ALTER TABLE "NodeGroup" OWNER TO "postgres";

CREATE TABLE "Project" (
"Id" int4 NOT NULL DEFAULT nextval('"Project_Id_seq"'::regclass),
"Name" varchar(64) COLLATE "default" NOT NULL,
CONSTRAINT "Project_pkey" PRIMARY KEY ("Id") ,
CONSTRAINT "UQ__Project__737584F67BFEC234" UNIQUE ("Name")
)
WITHOUT OIDS;

ALTER TABLE "Project" OWNER TO "postgres";

CREATE TABLE "Router" (
"Id" int4 NOT NULL DEFAULT nextval('"Router_Id_seq"'::regclass),
"RouterId" varchar(50) COLLATE "default" NOT NULL,
"SourceNodeGroupId" int4 NOT NULL,
"ProjectId" int4 NOT NULL,
"TargetNodeId" int4 NOT NULL,
CONSTRAINT "Router_pkey" PRIMARY KEY ("Id") ,
CONSTRAINT "UQ__Router__6C9DDD0BCF6FFE85" UNIQUE ("RouterId")
)
WITHOUT OIDS;

ALTER TABLE "Router" OWNER TO "postgres";

CREATE TABLE "sym_channel" (
"channel_id" varchar(128) COLLATE "default" NOT NULL,
"processing_order" int4 NOT NULL DEFAULT 1,
"max_batch_size" int4 NOT NULL DEFAULT 1000,
"max_batch_to_send" int4 NOT NULL DEFAULT 60,
"max_data_to_route" int4 NOT NULL DEFAULT 100000,
"extract_period_millis" int4 NOT NULL DEFAULT 0,
"enabled" int2 NOT NULL DEFAULT 1,
"use_old_data_to_route" int2 NOT NULL DEFAULT 1,
"use_row_data_to_route" int2 NOT NULL DEFAULT 1,
"use_pk_data_to_route" int2 NOT NULL DEFAULT 1,
"reload_flag" int2 NOT NULL DEFAULT 0,
"file_sync_flag" int2 NOT NULL DEFAULT 0,
"contains_big_lob" int2 NOT NULL DEFAULT 0,
"batch_algorithm" varchar(50) COLLATE "default" NOT NULL DEFAULT 'default'::character varying,
"data_loader_type" varchar(50) COLLATE "default" NOT NULL DEFAULT 'default'::character varying,
"description" varchar(255) COLLATE "default",
"queue" varchar(25) COLLATE "default" NOT NULL DEFAULT 'default'::character varying,
"max_network_kbps" numeric(10,3) NOT NULL DEFAULT 0.000,
"data_event_action" char(1) COLLATE "default",
"create_time" timestamp(6),
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6),
CONSTRAINT "sym_channel_pkey" PRIMARY KEY ("channel_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_channel" OWNER TO "postgres";

CREATE TABLE "sym_conflict" (
"conflict_id" varchar(50) COLLATE "default" NOT NULL,
"source_node_group_id" varchar(50) COLLATE "default" NOT NULL,
"target_node_group_id" varchar(50) COLLATE "default" NOT NULL,
"target_channel_id" varchar(128) COLLATE "default",
"target_catalog_name" varchar(255) COLLATE "default",
"target_schema_name" varchar(255) COLLATE "default",
"target_table_name" varchar(255) COLLATE "default",
"detect_type" varchar(128) COLLATE "default" NOT NULL,
"detect_expression" text COLLATE "default",
"resolve_type" varchar(128) COLLATE "default" NOT NULL,
"ping_back" varchar(128) COLLATE "default" NOT NULL,
"resolve_changes_only" int2 DEFAULT 0,
"resolve_row_only" int2 DEFAULT 0,
"create_time" timestamp(6) NOT NULL,
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
CONSTRAINT "sym_conflict_pkey" PRIMARY KEY ("conflict_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_conflict" OWNER TO "postgres";

CREATE TABLE "sym_context" (
"name" varchar(80) COLLATE "default" NOT NULL,
"context_value" text COLLATE "default",
"create_time" timestamp(6),
"last_update_time" timestamp(6),
CONSTRAINT "sym_context_pkey" PRIMARY KEY ("name") 
)
WITHOUT OIDS;

ALTER TABLE "sym_context" OWNER TO "postgres";

CREATE TABLE "sym_data" (
"data_id" int8 NOT NULL DEFAULT nextval('sym_data_data_id_seq'::regclass),
"table_name" varchar(255) COLLATE "default" NOT NULL,
"event_type" char(1) COLLATE "default" NOT NULL,
"row_data" text COLLATE "default",
"pk_data" text COLLATE "default",
"old_data" text COLLATE "default",
"trigger_hist_id" int4 NOT NULL,
"channel_id" varchar(128) COLLATE "default",
"transaction_id" varchar(255) COLLATE "default",
"source_node_id" varchar(50) COLLATE "default",
"external_data" varchar(50) COLLATE "default",
"node_list" varchar(255) COLLATE "default",
"create_time" timestamp(6),
CONSTRAINT "sym_data_pkey" PRIMARY KEY ("data_id") 
)
WITHOUT OIDS;

CREATE INDEX "sym_idx_d_channel_id" ON "sym_data" USING btree ("data_id" "pg_catalog"."int8_ops" ASC NULLS LAST, "channel_id" "pg_catalog"."text_ops" ASC NULLS LAST);
ALTER TABLE "sym_data" OWNER TO "postgres";

CREATE TABLE "sym_data_event" (
"data_id" int8 NOT NULL,
"batch_id" int8 NOT NULL,
"router_id" varchar(50) COLLATE "default" NOT NULL,
"create_time" timestamp(6),
CONSTRAINT "sym_data_event_pkey" PRIMARY KEY ("data_id", "batch_id", "router_id") 
)
WITHOUT OIDS;

CREATE INDEX "sym_idx_de_batchid" ON "sym_data_event" USING btree ("batch_id" "pg_catalog"."int8_ops" ASC NULLS LAST);
ALTER TABLE "sym_data_event" OWNER TO "postgres";

CREATE TABLE "sym_data_gap" (
"start_id" int8 NOT NULL,
"end_id" int8 NOT NULL,
"status" char(2) COLLATE "default",
"create_time" timestamp(6) NOT NULL,
"last_update_hostname" varchar(255) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
CONSTRAINT "sym_data_gap_pkey" PRIMARY KEY ("start_id", "end_id") 
)
WITHOUT OIDS;

CREATE INDEX "sym_idx_dg_status" ON "sym_data_gap" USING btree ("status" "pg_catalog"."bpchar_ops" ASC NULLS LAST);
ALTER TABLE "sym_data_gap" OWNER TO "postgres";

CREATE TABLE "sym_extension" (
"extension_id" varchar(50) COLLATE "default" NOT NULL,
"extension_type" varchar(10) COLLATE "default" NOT NULL,
"interface_name" varchar(255) COLLATE "default",
"node_group_id" varchar(50) COLLATE "default" NOT NULL,
"enabled" int2 NOT NULL DEFAULT 1,
"extension_order" int4 NOT NULL DEFAULT 1,
"extension_text" text COLLATE "default",
"create_time" timestamp(6),
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6),
CONSTRAINT "sym_extension_pkey" PRIMARY KEY ("extension_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_extension" OWNER TO "postgres";

CREATE TABLE "sym_extract_request" (
"request_id" int8 NOT NULL,
"node_id" varchar(50) COLLATE "default" NOT NULL,
"queue" varchar(128) COLLATE "default",
"status" char(2) COLLATE "default",
"start_batch_id" int8 NOT NULL,
"end_batch_id" int8 NOT NULL,
"trigger_id" varchar(128) COLLATE "default" NOT NULL,
"router_id" varchar(50) COLLATE "default" NOT NULL,
"last_update_time" timestamp(6),
"create_time" timestamp(6),
CONSTRAINT "sym_extract_request_pkey" PRIMARY KEY ("request_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_extract_request" OWNER TO "postgres";

CREATE TABLE "sym_file_incoming" (
"relative_dir" varchar(255) COLLATE "default" NOT NULL,
"file_name" varchar(128) COLLATE "default" NOT NULL,
"last_event_type" char(1) COLLATE "default" NOT NULL,
"node_id" varchar(50) COLLATE "default" NOT NULL,
"file_modified_time" int8,
CONSTRAINT "sym_file_incoming_pkey" PRIMARY KEY ("relative_dir", "file_name") 
)
WITHOUT OIDS;

ALTER TABLE "sym_file_incoming" OWNER TO "postgres";

CREATE TABLE "sym_file_snapshot" (
"trigger_id" varchar(128) COLLATE "default" NOT NULL,
"router_id" varchar(50) COLLATE "default" NOT NULL,
"relative_dir" varchar(255) COLLATE "default" NOT NULL,
"file_name" varchar(128) COLLATE "default" NOT NULL,
"channel_id" varchar(128) COLLATE "default" NOT NULL DEFAULT 'filesync'::character varying,
"reload_channel_id" varchar(128) COLLATE "default" NOT NULL DEFAULT 'filesync_reload'::character varying,
"last_event_type" char(1) COLLATE "default" NOT NULL,
"crc32_checksum" int8,
"file_size" int8,
"file_modified_time" int8,
"last_update_time" timestamp(6) NOT NULL,
"last_update_by" varchar(50) COLLATE "default",
"create_time" timestamp(6) NOT NULL,
CONSTRAINT "sym_file_snapshot_pkey" PRIMARY KEY ("trigger_id", "router_id", "relative_dir", "file_name") 
)
WITHOUT OIDS;

CREATE INDEX "sym_idx_f_snpsht_chid" ON "sym_file_snapshot" USING btree ("reload_channel_id" "pg_catalog"."text_ops" ASC NULLS LAST);
ALTER TABLE "sym_file_snapshot" OWNER TO "postgres";

CREATE TABLE "sym_file_trigger" (
"trigger_id" varchar(128) COLLATE "default" NOT NULL,
"channel_id" varchar(128) COLLATE "default" NOT NULL DEFAULT 'filesync'::character varying,
"reload_channel_id" varchar(128) COLLATE "default" NOT NULL DEFAULT 'filesync_reload'::character varying,
"base_dir" varchar(255) COLLATE "default" NOT NULL,
"recurse" int2 NOT NULL DEFAULT 1,
"includes_files" varchar(255) COLLATE "default",
"excludes_files" varchar(255) COLLATE "default",
"sync_on_create" int2 NOT NULL DEFAULT 1,
"sync_on_modified" int2 NOT NULL DEFAULT 1,
"sync_on_delete" int2 NOT NULL DEFAULT 1,
"sync_on_ctl_file" int2 NOT NULL DEFAULT 0,
"delete_after_sync" int2 NOT NULL DEFAULT 0,
"before_copy_script" text COLLATE "default",
"after_copy_script" text COLLATE "default",
"create_time" timestamp(6) NOT NULL,
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
"description" text COLLATE "default",
CONSTRAINT "sym_file_trigger_pkey" PRIMARY KEY ("trigger_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_file_trigger" OWNER TO "postgres";

CREATE TABLE "sym_file_trigger_router" (
"trigger_id" varchar(128) COLLATE "default" NOT NULL,
"router_id" varchar(50) COLLATE "default" NOT NULL,
"enabled" int2 NOT NULL DEFAULT 1,
"initial_load_enabled" int2 NOT NULL DEFAULT 1,
"target_base_dir" varchar(255) COLLATE "default",
"conflict_strategy" varchar(128) COLLATE "default" NOT NULL DEFAULT 'source_wins'::character varying,
"create_time" timestamp(6) NOT NULL,
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
"description" text COLLATE "default",
CONSTRAINT "sym_file_trigger_router_pkey" PRIMARY KEY ("trigger_id", "router_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_file_trigger_router" OWNER TO "postgres";

CREATE TABLE "sym_grouplet" (
"grouplet_id" varchar(50) COLLATE "default" NOT NULL,
"grouplet_link_policy" char(1) COLLATE "default" NOT NULL DEFAULT 'I'::bpchar,
"description" varchar(255) COLLATE "default",
"create_time" timestamp(6) NOT NULL,
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
CONSTRAINT "sym_grouplet_pkey" PRIMARY KEY ("grouplet_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_grouplet" OWNER TO "postgres";

CREATE TABLE "sym_grouplet_link" (
"grouplet_id" varchar(50) COLLATE "default" NOT NULL,
"external_id" varchar(255) COLLATE "default" NOT NULL,
"create_time" timestamp(6) NOT NULL,
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
CONSTRAINT "sym_grouplet_link_pkey" PRIMARY KEY ("grouplet_id", "external_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_grouplet_link" OWNER TO "postgres";

CREATE TABLE "sym_incoming_batch" (
"batch_id" int8 NOT NULL,
"node_id" varchar(50) COLLATE "default" NOT NULL,
"channel_id" varchar(128) COLLATE "default",
"status" char(2) COLLATE "default",
"error_flag" int2 DEFAULT 0,
"sql_state" varchar(10) COLLATE "default",
"sql_code" int4 NOT NULL DEFAULT 0,
"sql_message" text COLLATE "default",
"last_update_hostname" varchar(255) COLLATE "default",
"last_update_time" timestamp(6),
"create_time" timestamp(6),
"summary" varchar(255) COLLATE "default",
"ignore_count" int4 NOT NULL DEFAULT 0,
"byte_count" int8 NOT NULL DEFAULT 0,
"load_flag" int2 DEFAULT 0,
"extract_count" int4 NOT NULL DEFAULT 0,
"sent_count" int4 NOT NULL DEFAULT 0,
"load_count" int4 NOT NULL DEFAULT 0,
"reload_row_count" int4 NOT NULL DEFAULT 0,
"other_row_count" int4 NOT NULL DEFAULT 0,
"data_row_count" int4 NOT NULL DEFAULT 0,
"extract_row_count" int4 NOT NULL DEFAULT 0,
"load_row_count" int4 NOT NULL DEFAULT 0,
"data_insert_row_count" int4 NOT NULL DEFAULT 0,
"data_update_row_count" int4 NOT NULL DEFAULT 0,
"data_delete_row_count" int4 NOT NULL DEFAULT 0,
"extract_insert_row_count" int4 NOT NULL DEFAULT 0,
"extract_update_row_count" int4 NOT NULL DEFAULT 0,
"extract_delete_row_count" int4 NOT NULL DEFAULT 0,
"load_insert_row_count" int4 NOT NULL DEFAULT 0,
"load_update_row_count" int4 NOT NULL DEFAULT 0,
"load_delete_row_count" int4 NOT NULL DEFAULT 0,
"network_millis" int4 NOT NULL DEFAULT 0,
"filter_millis" int4 NOT NULL DEFAULT 0,
"load_millis" int4 NOT NULL DEFAULT 0,
"router_millis" int4 NOT NULL DEFAULT 0,
"extract_millis" int4 NOT NULL DEFAULT 0,
"transform_extract_millis" int4 NOT NULL DEFAULT 0,
"transform_load_millis" int4 NOT NULL DEFAULT 0,
"load_id" int8,
"common_flag" int2 DEFAULT 0,
"fallback_insert_count" int4 NOT NULL DEFAULT 0,
"fallback_update_count" int4 NOT NULL DEFAULT 0,
"ignore_row_count" int4 NOT NULL DEFAULT 0,
"missing_delete_count" int4 NOT NULL DEFAULT 0,
"skip_count" int4 NOT NULL DEFAULT 0,
"failed_row_number" int4 NOT NULL DEFAULT 0,
"failed_line_number" int4 NOT NULL DEFAULT 0,
"failed_data_id" int8 NOT NULL DEFAULT 0,
CONSTRAINT "sym_incoming_batch_pkey" PRIMARY KEY ("batch_id", "node_id") 
)
WITHOUT OIDS;

CREATE INDEX "sym_idx_ib_in_error" ON "sym_incoming_batch" USING btree ("error_flag" "pg_catalog"."int2_ops" ASC NULLS LAST);
CREATE INDEX "sym_idx_ib_time_status" ON "sym_incoming_batch" USING btree ("create_time" "pg_catalog"."timestamp_ops" ASC NULLS LAST, "status" "pg_catalog"."bpchar_ops" ASC NULLS LAST);
ALTER TABLE "sym_incoming_batch" OWNER TO "postgres";

CREATE TABLE "sym_incoming_error" (
"batch_id" int8 NOT NULL,
"node_id" varchar(50) COLLATE "default" NOT NULL,
"failed_row_number" int8 NOT NULL,
"failed_line_number" int8 NOT NULL DEFAULT 0,
"target_catalog_name" varchar(255) COLLATE "default",
"target_schema_name" varchar(255) COLLATE "default",
"target_table_name" varchar(255) COLLATE "default" NOT NULL,
"event_type" char(1) COLLATE "default" NOT NULL,
"binary_encoding" varchar(10) COLLATE "default" NOT NULL DEFAULT 'HEX'::character varying,
"column_names" text COLLATE "default" NOT NULL,
"pk_column_names" text COLLATE "default" NOT NULL,
"row_data" text COLLATE "default",
"old_data" text COLLATE "default",
"cur_data" text COLLATE "default",
"resolve_data" text COLLATE "default",
"resolve_ignore" int2 DEFAULT 0,
"conflict_id" varchar(50) COLLATE "default",
"create_time" timestamp(6),
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
CONSTRAINT "sym_incoming_error_pkey" PRIMARY KEY ("batch_id", "node_id", "failed_row_number") 
)
WITHOUT OIDS;

ALTER TABLE "sym_incoming_error" OWNER TO "postgres";

CREATE TABLE "sym_job" (
"job_name" varchar(50) COLLATE "default" NOT NULL,
"job_type" varchar(10) COLLATE "default" NOT NULL,
"requires_registration" int2 NOT NULL DEFAULT 1,
"job_expression" text COLLATE "default",
"description" varchar(255) COLLATE "default",
"default_schedule" varchar(50) COLLATE "default",
"default_auto_start" int2 NOT NULL DEFAULT 1,
"node_group_id" varchar(50) COLLATE "default" NOT NULL,
"create_by" varchar(50) COLLATE "default",
"create_time" timestamp(6),
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6),
CONSTRAINT "sym_job_pkey" PRIMARY KEY ("job_name") 
)
WITHOUT OIDS;

ALTER TABLE "sym_job" OWNER TO "postgres";

CREATE TABLE "sym_load_filter" (
"load_filter_id" varchar(50) COLLATE "default" NOT NULL,
"load_filter_type" varchar(10) COLLATE "default" NOT NULL,
"source_node_group_id" varchar(50) COLLATE "default" NOT NULL,
"target_node_group_id" varchar(50) COLLATE "default" NOT NULL,
"target_catalog_name" varchar(255) COLLATE "default",
"target_schema_name" varchar(255) COLLATE "default",
"target_table_name" varchar(255) COLLATE "default",
"filter_on_update" int2 NOT NULL DEFAULT 1,
"filter_on_insert" int2 NOT NULL DEFAULT 1,
"filter_on_delete" int2 NOT NULL DEFAULT 1,
"before_write_script" text COLLATE "default",
"after_write_script" text COLLATE "default",
"batch_complete_script" text COLLATE "default",
"batch_commit_script" text COLLATE "default",
"batch_rollback_script" text COLLATE "default",
"handle_error_script" text COLLATE "default",
"create_time" timestamp(6) NOT NULL,
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
"load_filter_order" int4 NOT NULL DEFAULT 1,
"fail_on_error" int2 NOT NULL DEFAULT 0,
CONSTRAINT "sym_load_filter_pkey" PRIMARY KEY ("load_filter_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_load_filter" OWNER TO "postgres";

CREATE TABLE "sym_lock" (
"lock_action" varchar(50) COLLATE "default" NOT NULL,
"lock_type" varchar(50) COLLATE "default" NOT NULL,
"locking_server_id" varchar(255) COLLATE "default",
"lock_time" timestamp(6),
"shared_count" int4 NOT NULL DEFAULT 0,
"shared_enable" int4 NOT NULL DEFAULT 0,
"last_lock_time" timestamp(6),
"last_locking_server_id" varchar(255) COLLATE "default",
CONSTRAINT "sym_lock_pkey" PRIMARY KEY ("lock_action") 
)
WITHOUT OIDS;

ALTER TABLE "sym_lock" OWNER TO "postgres";

CREATE TABLE "sym_monitor" (
"monitor_id" varchar(128) COLLATE "default" NOT NULL,
"node_group_id" varchar(50) COLLATE "default" NOT NULL DEFAULT 'ALL'::character varying,
"external_id" varchar(255) COLLATE "default" NOT NULL DEFAULT 'ALL'::character varying,
"type" varchar(50) COLLATE "default" NOT NULL,
"expression" text COLLATE "default",
"threshold" int8 NOT NULL DEFAULT 0,
"run_period" int4 NOT NULL DEFAULT 0,
"run_count" int4 NOT NULL DEFAULT 0,
"severity_level" int4 NOT NULL DEFAULT 0,
"enabled" int2 NOT NULL DEFAULT 0,
"create_time" timestamp(6),
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6),
CONSTRAINT "sym_monitor_pkey" PRIMARY KEY ("monitor_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_monitor" OWNER TO "postgres";

CREATE TABLE "sym_monitor_event" (
"monitor_id" varchar(128) COLLATE "default" NOT NULL,
"node_id" varchar(50) COLLATE "default" NOT NULL,
"event_time" timestamp(6) NOT NULL,
"host_name" varchar(60) COLLATE "default",
"type" varchar(50) COLLATE "default" NOT NULL,
"threshold" int8 NOT NULL DEFAULT 0,
"event_value" int8 NOT NULL DEFAULT 0,
"event_count" int4 NOT NULL DEFAULT 0,
"severity_level" int4 NOT NULL DEFAULT 0,
"is_resolved" int2 NOT NULL DEFAULT 0,
"is_notified" int2 NOT NULL DEFAULT 0,
"details" text COLLATE "default",
"last_update_time" timestamp(6),
CONSTRAINT "sym_monitor_event_pkey" PRIMARY KEY ("monitor_id", "node_id", "event_time") 
)
WITHOUT OIDS;

ALTER TABLE "sym_monitor_event" OWNER TO "postgres";

CREATE TABLE "sym_node" (
"node_id" varchar(50) COLLATE "default" NOT NULL,
"node_group_id" varchar(50) COLLATE "default" NOT NULL,
"external_id" varchar(255) COLLATE "default" NOT NULL,
"heartbeat_time" timestamp(6),
"timezone_offset" varchar(6) COLLATE "default",
"sync_enabled" int2 DEFAULT 0,
"sync_url" varchar(255) COLLATE "default",
"schema_version" varchar(50) COLLATE "default",
"symmetric_version" varchar(50) COLLATE "default",
"config_version" varchar(50) COLLATE "default",
"database_type" varchar(50) COLLATE "default",
"database_version" varchar(50) COLLATE "default",
"batch_to_send_count" int4 DEFAULT 0,
"batch_in_error_count" int4 DEFAULT 0,
"created_at_node_id" varchar(50) COLLATE "default",
"deployment_type" varchar(50) COLLATE "default",
"deployment_sub_type" varchar(50) COLLATE "default",
CONSTRAINT "sym_node_pkey" PRIMARY KEY ("node_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_node" OWNER TO "postgres";

CREATE TABLE "sym_node_channel_ctl" (
"node_id" varchar(50) COLLATE "default" NOT NULL,
"channel_id" varchar(128) COLLATE "default" NOT NULL,
"suspend_enabled" int2 DEFAULT 0,
"ignore_enabled" int2 DEFAULT 0,
"last_extract_time" timestamp(6),
CONSTRAINT "sym_node_channel_ctl_pkey" PRIMARY KEY ("node_id", "channel_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_node_channel_ctl" OWNER TO "postgres";

CREATE TABLE "sym_node_communication" (
"node_id" varchar(50) COLLATE "default" NOT NULL,
"queue" varchar(25) COLLATE "default" NOT NULL DEFAULT 'default'::character varying,
"communication_type" varchar(10) COLLATE "default" NOT NULL,
"lock_time" timestamp(6),
"locking_server_id" varchar(255) COLLATE "default",
"last_lock_time" timestamp(6),
"last_lock_millis" int8 DEFAULT 0,
"success_count" int8 DEFAULT 0,
"fail_count" int8 DEFAULT 0,
"skip_count" int8 DEFAULT 0,
"total_success_count" int8 DEFAULT 0,
"total_fail_count" int8 DEFAULT 0,
"total_success_millis" int8 DEFAULT 0,
"total_fail_millis" int8 DEFAULT 0,
"batch_to_send_count" int8 DEFAULT 0,
"node_priority" int4 DEFAULT 0,
CONSTRAINT "sym_node_communication_pkey" PRIMARY KEY ("node_id", "queue", "communication_type") 
)
WITHOUT OIDS;

ALTER TABLE "sym_node_communication" OWNER TO "postgres";

CREATE TABLE "sym_node_group" (
"node_group_id" varchar(50) COLLATE "default" NOT NULL,
"description" varchar(255) COLLATE "default",
"create_time" timestamp(6),
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6),
CONSTRAINT "sym_node_group_pkey" PRIMARY KEY ("node_group_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_node_group" OWNER TO "postgres";

CREATE TABLE "sym_node_group_channel_wnd" (
"node_group_id" varchar(50) COLLATE "default" NOT NULL,
"channel_id" varchar(128) COLLATE "default" NOT NULL,
"start_time" timestamp(6) NOT NULL,
"end_time" timestamp(6) NOT NULL,
"enabled" int2 NOT NULL DEFAULT 0,
CONSTRAINT "sym_node_group_channel_wnd_pkey" PRIMARY KEY ("node_group_id", "channel_id", "start_time", "end_time") 
)
WITHOUT OIDS;

ALTER TABLE "sym_node_group_channel_wnd" OWNER TO "postgres";

CREATE TABLE "sym_node_group_link" (
"source_node_group_id" varchar(50) COLLATE "default" NOT NULL,
"target_node_group_id" varchar(50) COLLATE "default" NOT NULL,
"data_event_action" char(1) COLLATE "default" NOT NULL DEFAULT 'W'::bpchar,
"sync_config_enabled" int2 NOT NULL DEFAULT 1,
"is_reversible" int2 NOT NULL DEFAULT 0,
"create_time" timestamp(6),
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6),
CONSTRAINT "sym_node_group_link_pkey" PRIMARY KEY ("source_node_group_id", "target_node_group_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_node_group_link" OWNER TO "postgres";

CREATE TABLE "sym_node_host" (
"node_id" varchar(50) COLLATE "default" NOT NULL,
"host_name" varchar(60) COLLATE "default" NOT NULL,
"instance_id" varchar(60) COLLATE "default",
"ip_address" varchar(50) COLLATE "default",
"os_user" varchar(50) COLLATE "default",
"os_name" varchar(50) COLLATE "default",
"os_arch" varchar(50) COLLATE "default",
"os_version" varchar(50) COLLATE "default",
"available_processors" int4 DEFAULT 0,
"free_memory_bytes" int8 DEFAULT 0,
"total_memory_bytes" int8 DEFAULT 0,
"max_memory_bytes" int8 DEFAULT 0,
"java_version" varchar(50) COLLATE "default",
"java_vendor" varchar(255) COLLATE "default",
"jdbc_version" varchar(255) COLLATE "default",
"symmetric_version" varchar(50) COLLATE "default",
"timezone_offset" varchar(6) COLLATE "default",
"heartbeat_time" timestamp(6),
"last_restart_time" timestamp(6) NOT NULL,
"create_time" timestamp(6) NOT NULL,
CONSTRAINT "sym_node_host_pkey" PRIMARY KEY ("node_id", "host_name") 
)
WITHOUT OIDS;

ALTER TABLE "sym_node_host" OWNER TO "postgres";

CREATE TABLE "sym_node_host_channel_stats" (
"node_id" varchar(50) COLLATE "default" NOT NULL,
"host_name" varchar(60) COLLATE "default" NOT NULL,
"channel_id" varchar(128) COLLATE "default" NOT NULL,
"start_time" timestamp(6) NOT NULL,
"end_time" timestamp(6) NOT NULL,
"data_routed" int8 DEFAULT 0,
"data_unrouted" int8 DEFAULT 0,
"data_event_inserted" int8 DEFAULT 0,
"data_extracted" int8 DEFAULT 0,
"data_bytes_extracted" int8 DEFAULT 0,
"data_extracted_errors" int8 DEFAULT 0,
"data_bytes_sent" int8 DEFAULT 0,
"data_sent" int8 DEFAULT 0,
"data_sent_errors" int8 DEFAULT 0,
"data_loaded" int8 DEFAULT 0,
"data_bytes_loaded" int8 DEFAULT 0,
"data_loaded_errors" int8 DEFAULT 0,
CONSTRAINT "sym_node_host_channel_stats_pkey" PRIMARY KEY ("node_id", "host_name", "channel_id", "start_time", "end_time") 
)
WITHOUT OIDS;

CREATE INDEX "sym_idx_nd_hst_chnl_sts" ON "sym_node_host_channel_stats" USING btree ("node_id" "pg_catalog"."text_ops" ASC NULLS LAST, "start_time" "pg_catalog"."timestamp_ops" ASC NULLS LAST, "end_time" "pg_catalog"."timestamp_ops" ASC NULLS LAST);
ALTER TABLE "sym_node_host_channel_stats" OWNER TO "postgres";

CREATE TABLE "sym_node_host_job_stats" (
"node_id" varchar(50) COLLATE "default" NOT NULL,
"host_name" varchar(60) COLLATE "default" NOT NULL,
"job_name" varchar(50) COLLATE "default" NOT NULL,
"start_time" timestamp(6) NOT NULL,
"end_time" timestamp(6) NOT NULL,
"processed_count" int8 DEFAULT 0,
"target_node_id" varchar(50) COLLATE "default",
"target_node_count" int4 DEFAULT 0,
CONSTRAINT "sym_node_host_job_stats_pkey" PRIMARY KEY ("node_id", "host_name", "job_name", "start_time", "end_time") 
)
WITHOUT OIDS;

CREATE INDEX "sym_idx_nd_hst_job" ON "sym_node_host_job_stats" USING btree ("node_id" "pg_catalog"."text_ops" ASC NULLS LAST, "start_time" "pg_catalog"."timestamp_ops" ASC NULLS LAST, "end_time" "pg_catalog"."timestamp_ops" ASC NULLS LAST);
ALTER TABLE "sym_node_host_job_stats" OWNER TO "postgres";

CREATE TABLE "sym_node_host_stats" (
"node_id" varchar(50) COLLATE "default" NOT NULL,
"host_name" varchar(60) COLLATE "default" NOT NULL,
"start_time" timestamp(6) NOT NULL,
"end_time" timestamp(6) NOT NULL,
"restarted" int8 NOT NULL DEFAULT 0,
"nodes_pulled" int8 DEFAULT 0,
"total_nodes_pull_time" int8 DEFAULT 0,
"nodes_pushed" int8 DEFAULT 0,
"total_nodes_push_time" int8 DEFAULT 0,
"nodes_rejected" int8 DEFAULT 0,
"nodes_registered" int8 DEFAULT 0,
"nodes_loaded" int8 DEFAULT 0,
"nodes_disabled" int8 DEFAULT 0,
"purged_data_rows" int8 DEFAULT 0,
"purged_data_event_rows" int8 DEFAULT 0,
"purged_batch_outgoing_rows" int8 DEFAULT 0,
"purged_batch_incoming_rows" int8 DEFAULT 0,
"triggers_created_count" int8,
"triggers_rebuilt_count" int8,
"triggers_removed_count" int8,
CONSTRAINT "sym_node_host_stats_pkey" PRIMARY KEY ("node_id", "host_name", "start_time", "end_time") 
)
WITHOUT OIDS;

CREATE INDEX "sym_idx_nd_hst_sts" ON "sym_node_host_stats" USING btree ("node_id" "pg_catalog"."text_ops" ASC NULLS LAST, "start_time" "pg_catalog"."timestamp_ops" ASC NULLS LAST, "end_time" "pg_catalog"."timestamp_ops" ASC NULLS LAST);
ALTER TABLE "sym_node_host_stats" OWNER TO "postgres";

CREATE TABLE "sym_node_identity" (
"node_id" varchar(50) COLLATE "default" NOT NULL,
CONSTRAINT "sym_node_identity_pkey" PRIMARY KEY ("node_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_node_identity" OWNER TO "postgres";

CREATE TABLE "sym_node_security" (
"node_id" varchar(50) COLLATE "default" NOT NULL,
"node_password" varchar(50) COLLATE "default" NOT NULL,
"registration_enabled" int2 DEFAULT 0,
"registration_time" timestamp(6),
"initial_load_enabled" int2 DEFAULT 0,
"initial_load_time" timestamp(6),
"initial_load_id" int8,
"initial_load_create_by" varchar(255) COLLATE "default",
"rev_initial_load_enabled" int2 DEFAULT 0,
"rev_initial_load_time" timestamp(6),
"rev_initial_load_id" int8,
"rev_initial_load_create_by" varchar(255) COLLATE "default",
"created_at_node_id" varchar(50) COLLATE "default",
CONSTRAINT "sym_node_security_pkey" PRIMARY KEY ("node_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_node_security" OWNER TO "postgres";

CREATE TABLE "sym_notification" (
"notification_id" varchar(128) COLLATE "default" NOT NULL,
"node_group_id" varchar(50) COLLATE "default" NOT NULL DEFAULT 'ALL'::character varying,
"external_id" varchar(255) COLLATE "default" NOT NULL DEFAULT 'ALL'::character varying,
"severity_level" int4 NOT NULL DEFAULT 0,
"type" varchar(50) COLLATE "default" NOT NULL,
"expression" text COLLATE "default",
"enabled" int2 NOT NULL DEFAULT 0,
"create_time" timestamp(6),
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6),
CONSTRAINT "sym_notification_pkey" PRIMARY KEY ("notification_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_notification" OWNER TO "postgres";

CREATE TABLE "sym_outgoing_batch" (
"batch_id" int8 NOT NULL,
"node_id" varchar(50) COLLATE "default" NOT NULL,
"channel_id" varchar(128) COLLATE "default",
"status" char(2) COLLATE "default",
"error_flag" int2 DEFAULT 0,
"sql_state" varchar(10) COLLATE "default",
"sql_code" int4 NOT NULL DEFAULT 0,
"sql_message" text COLLATE "default",
"last_update_hostname" varchar(255) COLLATE "default",
"last_update_time" timestamp(6),
"create_time" timestamp(6),
"summary" varchar(255) COLLATE "default",
"ignore_count" int4 NOT NULL DEFAULT 0,
"byte_count" int8 NOT NULL DEFAULT 0,
"load_flag" int2 DEFAULT 0,
"extract_count" int4 NOT NULL DEFAULT 0,
"sent_count" int4 NOT NULL DEFAULT 0,
"load_count" int4 NOT NULL DEFAULT 0,
"reload_row_count" int4 NOT NULL DEFAULT 0,
"other_row_count" int4 NOT NULL DEFAULT 0,
"data_row_count" int4 NOT NULL DEFAULT 0,
"extract_row_count" int4 NOT NULL DEFAULT 0,
"load_row_count" int4 NOT NULL DEFAULT 0,
"data_insert_row_count" int4 NOT NULL DEFAULT 0,
"data_update_row_count" int4 NOT NULL DEFAULT 0,
"data_delete_row_count" int4 NOT NULL DEFAULT 0,
"extract_insert_row_count" int4 NOT NULL DEFAULT 0,
"extract_update_row_count" int4 NOT NULL DEFAULT 0,
"extract_delete_row_count" int4 NOT NULL DEFAULT 0,
"load_insert_row_count" int4 NOT NULL DEFAULT 0,
"load_update_row_count" int4 NOT NULL DEFAULT 0,
"load_delete_row_count" int4 NOT NULL DEFAULT 0,
"network_millis" int4 NOT NULL DEFAULT 0,
"filter_millis" int4 NOT NULL DEFAULT 0,
"load_millis" int4 NOT NULL DEFAULT 0,
"router_millis" int4 NOT NULL DEFAULT 0,
"extract_millis" int4 NOT NULL DEFAULT 0,
"transform_extract_millis" int4 NOT NULL DEFAULT 0,
"transform_load_millis" int4 NOT NULL DEFAULT 0,
"load_id" int8,
"common_flag" int2 DEFAULT 0,
"fallback_insert_count" int4 NOT NULL DEFAULT 0,
"fallback_update_count" int4 NOT NULL DEFAULT 0,
"ignore_row_count" int4 NOT NULL DEFAULT 0,
"missing_delete_count" int4 NOT NULL DEFAULT 0,
"skip_count" int4 NOT NULL DEFAULT 0,
"total_extract_millis" int4 NOT NULL DEFAULT 0,
"total_load_millis" int4 NOT NULL DEFAULT 0,
"extract_job_flag" int2 DEFAULT 0,
"extract_start_time" timestamp(6),
"transfer_start_time" timestamp(6),
"load_start_time" timestamp(6),
"failed_data_id" int8 NOT NULL DEFAULT 0,
"failed_line_number" int8 NOT NULL DEFAULT 0,
"create_by" varchar(255) COLLATE "default",
CONSTRAINT "sym_outgoing_batch_pkey" PRIMARY KEY ("batch_id", "node_id") 
)
WITHOUT OIDS;

CREATE INDEX "sym_idx_ob_in_error" ON "sym_outgoing_batch" USING btree ("error_flag" "pg_catalog"."int2_ops" ASC NULLS LAST);
CREATE INDEX "sym_idx_ob_node_status" ON "sym_outgoing_batch" USING btree ("node_id" "pg_catalog"."text_ops" ASC NULLS LAST, "status" "pg_catalog"."bpchar_ops" ASC NULLS LAST);
CREATE INDEX "sym_idx_ob_status" ON "sym_outgoing_batch" USING btree ("status" "pg_catalog"."bpchar_ops" ASC NULLS LAST);
ALTER TABLE "sym_outgoing_batch" OWNER TO "postgres";

CREATE TABLE "sym_parameter" (
"external_id" varchar(255) COLLATE "default" NOT NULL,
"node_group_id" varchar(50) COLLATE "default" NOT NULL,
"param_key" varchar(80) COLLATE "default" NOT NULL,
"param_value" text COLLATE "default",
"create_time" timestamp(6),
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6),
CONSTRAINT "sym_parameter_pkey" PRIMARY KEY ("external_id", "node_group_id", "param_key") 
)
WITHOUT OIDS;

ALTER TABLE "sym_parameter" OWNER TO "postgres";

CREATE TABLE "sym_registration_redirect" (
"registrant_external_id" varchar(255) COLLATE "default" NOT NULL,
"registration_node_id" varchar(50) COLLATE "default" NOT NULL,
CONSTRAINT "sym_registration_redirect_pkey" PRIMARY KEY ("registrant_external_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_registration_redirect" OWNER TO "postgres";

CREATE TABLE "sym_registration_request" (
"node_group_id" varchar(50) COLLATE "default" NOT NULL,
"external_id" varchar(255) COLLATE "default" NOT NULL,
"status" char(2) COLLATE "default" NOT NULL,
"host_name" varchar(60) COLLATE "default" NOT NULL,
"ip_address" varchar(50) COLLATE "default" NOT NULL,
"attempt_count" int4 DEFAULT 0,
"registered_node_id" varchar(50) COLLATE "default",
"error_message" text COLLATE "default",
"create_time" timestamp(6) NOT NULL,
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
CONSTRAINT "sym_registration_request_pkey" PRIMARY KEY ("node_group_id", "external_id", "create_time") 
)
WITHOUT OIDS;

CREATE INDEX "sym_idx_reg_req_1" ON "sym_registration_request" USING btree ("node_group_id" "pg_catalog"."text_ops" ASC NULLS LAST, "external_id" "pg_catalog"."text_ops" ASC NULLS LAST, "status" "pg_catalog"."bpchar_ops" ASC NULLS LAST, "host_name" "pg_catalog"."text_ops" ASC NULLS LAST, "ip_address" "pg_catalog"."text_ops" ASC NULLS LAST);
CREATE INDEX "sym_idx_reg_req_2" ON "sym_registration_request" USING btree ("status" "pg_catalog"."bpchar_ops" ASC NULLS LAST);
ALTER TABLE "sym_registration_request" OWNER TO "postgres";

CREATE TABLE "sym_router" (
"router_id" varchar(50) COLLATE "default" NOT NULL,
"target_catalog_name" varchar(255) COLLATE "default",
"target_schema_name" varchar(255) COLLATE "default",
"target_table_name" varchar(255) COLLATE "default",
"source_node_group_id" varchar(50) COLLATE "default" NOT NULL,
"target_node_group_id" varchar(50) COLLATE "default" NOT NULL,
"router_type" varchar(50) COLLATE "default",
"router_expression" text COLLATE "default",
"sync_on_update" int2 NOT NULL DEFAULT 1,
"sync_on_insert" int2 NOT NULL DEFAULT 1,
"sync_on_delete" int2 NOT NULL DEFAULT 1,
"use_source_catalog_schema" int2 NOT NULL DEFAULT 1,
"create_time" timestamp(6) NOT NULL,
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
"description" text COLLATE "default",
CONSTRAINT "sym_router_pkey" PRIMARY KEY ("router_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_router" OWNER TO "postgres";

CREATE TABLE "sym_sequence" (
"sequence_name" varchar(50) COLLATE "default" NOT NULL,
"current_value" int8 NOT NULL DEFAULT 0,
"increment_by" int4 NOT NULL DEFAULT 1,
"min_value" int8 NOT NULL DEFAULT 1,
"max_value" int8 NOT NULL DEFAULT '9999999999'::bigint,
"cycle_flag" int2 DEFAULT 0,
"cache_size" int4 NOT NULL DEFAULT 0,
"create_time" timestamp(6),
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
CONSTRAINT "sym_sequence_pkey" PRIMARY KEY ("sequence_name") 
)
WITHOUT OIDS;

ALTER TABLE "sym_sequence" OWNER TO "postgres";

CREATE TABLE "sym_table_reload_request" (
"target_node_id" varchar(50) COLLATE "default" NOT NULL,
"source_node_id" varchar(50) COLLATE "default" NOT NULL,
"trigger_id" varchar(128) COLLATE "default" NOT NULL,
"router_id" varchar(50) COLLATE "default" NOT NULL,
"create_time" timestamp(6) NOT NULL,
"create_table" int2 NOT NULL DEFAULT 0,
"delete_first" int2 NOT NULL DEFAULT 0,
"reload_select" text COLLATE "default",
"before_custom_sql" text COLLATE "default",
"reload_time" timestamp(6),
"load_id" int8,
"processed" int2 NOT NULL DEFAULT 0,
"channel_id" varchar(128) COLLATE "default",
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
CONSTRAINT "sym_table_reload_request_pkey" PRIMARY KEY ("target_node_id", "source_node_id", "trigger_id", "router_id", "create_time") 
)
WITHOUT OIDS;

ALTER TABLE "sym_table_reload_request" OWNER TO "postgres";

CREATE TABLE "sym_transform_column" (
"transform_id" varchar(50) COLLATE "default" NOT NULL,
"include_on" char(1) COLLATE "default" NOT NULL DEFAULT '*'::bpchar,
"target_column_name" varchar(128) COLLATE "default" NOT NULL,
"source_column_name" varchar(128) COLLATE "default",
"pk" int2 DEFAULT 0,
"transform_type" varchar(50) COLLATE "default" DEFAULT 'copy'::character varying,
"transform_expression" text COLLATE "default",
"transform_order" int4 NOT NULL DEFAULT 1,
"create_time" timestamp(6),
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6),
"description" text COLLATE "default",
CONSTRAINT "sym_transform_column_pkey" PRIMARY KEY ("transform_id", "include_on", "target_column_name") 
)
WITHOUT OIDS;

ALTER TABLE "sym_transform_column" OWNER TO "postgres";

CREATE TABLE "sym_transform_table" (
"transform_id" varchar(50) COLLATE "default" NOT NULL,
"source_node_group_id" varchar(50) COLLATE "default" NOT NULL,
"target_node_group_id" varchar(50) COLLATE "default" NOT NULL,
"transform_point" varchar(10) COLLATE "default" NOT NULL,
"source_catalog_name" varchar(255) COLLATE "default",
"source_schema_name" varchar(255) COLLATE "default",
"source_table_name" varchar(255) COLLATE "default" NOT NULL,
"target_catalog_name" varchar(255) COLLATE "default",
"target_schema_name" varchar(255) COLLATE "default",
"target_table_name" varchar(255) COLLATE "default",
"update_first" int2 DEFAULT 0,
"update_action" varchar(255) COLLATE "default" NOT NULL DEFAULT 'UPDATE_COL'::character varying,
"delete_action" varchar(10) COLLATE "default" NOT NULL,
"transform_order" int4 NOT NULL DEFAULT 1,
"column_policy" varchar(10) COLLATE "default" NOT NULL DEFAULT 'SPECIFIED'::character varying,
"create_time" timestamp(6),
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6),
"description" text COLLATE "default",
CONSTRAINT "sym_transform_table_pkey" PRIMARY KEY ("transform_id", "source_node_group_id", "target_node_group_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_transform_table" OWNER TO "postgres";

CREATE TABLE "sym_trigger" (
"trigger_id" varchar(128) COLLATE "default" NOT NULL,
"source_catalog_name" varchar(255) COLLATE "default",
"source_schema_name" varchar(255) COLLATE "default",
"source_table_name" varchar(255) COLLATE "default" NOT NULL,
"channel_id" varchar(128) COLLATE "default" NOT NULL,
"reload_channel_id" varchar(128) COLLATE "default" NOT NULL DEFAULT 'reload'::character varying,
"sync_on_update" int2 NOT NULL DEFAULT 1,
"sync_on_insert" int2 NOT NULL DEFAULT 1,
"sync_on_delete" int2 NOT NULL DEFAULT 1,
"sync_on_incoming_batch" int2 NOT NULL DEFAULT 0,
"name_for_update_trigger" varchar(255) COLLATE "default",
"name_for_insert_trigger" varchar(255) COLLATE "default",
"name_for_delete_trigger" varchar(255) COLLATE "default",
"sync_on_update_condition" text COLLATE "default",
"sync_on_insert_condition" text COLLATE "default",
"sync_on_delete_condition" text COLLATE "default",
"custom_before_update_text" text COLLATE "default",
"custom_before_insert_text" text COLLATE "default",
"custom_before_delete_text" text COLLATE "default",
"custom_on_update_text" text COLLATE "default",
"custom_on_insert_text" text COLLATE "default",
"custom_on_delete_text" text COLLATE "default",
"external_select" text COLLATE "default",
"tx_id_expression" text COLLATE "default",
"channel_expression" text COLLATE "default",
"excluded_column_names" text COLLATE "default",
"included_column_names" text COLLATE "default",
"sync_key_names" text COLLATE "default",
"use_stream_lobs" int2 NOT NULL DEFAULT 0,
"use_capture_lobs" int2 NOT NULL DEFAULT 0,
"use_capture_old_data" int2 NOT NULL DEFAULT 1,
"use_handle_key_updates" int2 NOT NULL DEFAULT 1,
"stream_row" int2 NOT NULL DEFAULT 0,
"create_time" timestamp(6) NOT NULL,
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
"description" text COLLATE "default",
CONSTRAINT "sym_trigger_pkey" PRIMARY KEY ("trigger_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_trigger" OWNER TO "postgres";

CREATE TABLE "sym_trigger_hist" (
"trigger_hist_id" int4 NOT NULL,
"trigger_id" varchar(128) COLLATE "default" NOT NULL,
"source_table_name" varchar(255) COLLATE "default" NOT NULL,
"source_catalog_name" varchar(255) COLLATE "default",
"source_schema_name" varchar(255) COLLATE "default",
"name_for_update_trigger" varchar(255) COLLATE "default",
"name_for_insert_trigger" varchar(255) COLLATE "default",
"name_for_delete_trigger" varchar(255) COLLATE "default",
"table_hash" int8 NOT NULL DEFAULT 0,
"trigger_row_hash" int8 NOT NULL DEFAULT 0,
"trigger_template_hash" int8 NOT NULL DEFAULT 0,
"column_names" text COLLATE "default" NOT NULL,
"pk_column_names" text COLLATE "default" NOT NULL,
"last_trigger_build_reason" char(1) COLLATE "default" NOT NULL,
"error_message" text COLLATE "default",
"create_time" timestamp(6) NOT NULL,
"inactive_time" timestamp(6),
CONSTRAINT "sym_trigger_hist_pkey" PRIMARY KEY ("trigger_hist_id") 
)
WITHOUT OIDS;

CREATE INDEX "sym_idx_trigg_hist_1" ON "sym_trigger_hist" USING btree ("trigger_id" "pg_catalog"."text_ops" ASC NULLS LAST, "inactive_time" "pg_catalog"."timestamp_ops" ASC NULLS LAST);
ALTER TABLE "sym_trigger_hist" OWNER TO "postgres";

CREATE TABLE "sym_trigger_router" (
"trigger_id" varchar(128) COLLATE "default" NOT NULL,
"router_id" varchar(50) COLLATE "default" NOT NULL,
"enabled" int2 NOT NULL DEFAULT 1,
"initial_load_order" int4 NOT NULL DEFAULT 1,
"initial_load_select" text COLLATE "default",
"initial_load_delete_stmt" text COLLATE "default",
"ping_back_enabled" int2 NOT NULL DEFAULT 0,
"create_time" timestamp(6) NOT NULL,
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
"description" text COLLATE "default",
CONSTRAINT "sym_trigger_router_pkey" PRIMARY KEY ("trigger_id", "router_id") 
)
WITHOUT OIDS;

ALTER TABLE "sym_trigger_router" OWNER TO "postgres";

CREATE TABLE "sym_trigger_router_grouplet" (
"grouplet_id" varchar(50) COLLATE "default" NOT NULL,
"trigger_id" varchar(128) COLLATE "default" NOT NULL,
"router_id" varchar(50) COLLATE "default" NOT NULL,
"applies_when" char(1) COLLATE "default" NOT NULL,
"create_time" timestamp(6) NOT NULL,
"last_update_by" varchar(50) COLLATE "default",
"last_update_time" timestamp(6) NOT NULL,
CONSTRAINT "sym_trigger_router_grouplet_pkey" PRIMARY KEY ("grouplet_id", "trigger_id", "router_id", "applies_when") 
)
WITHOUT OIDS;

ALTER TABLE "sym_trigger_router_grouplet" OWNER TO "postgres";

CREATE TABLE "Trigger" (
"Id" int4 NOT NULL DEFAULT nextval('"Trigger_Id_seq"'::regclass),
"ChannelId" int4 NOT NULL,
"TriggerId" varchar(128) COLLATE "default" NOT NULL,
"SourceTableName" varchar(255) COLLATE "default" NOT NULL,
CONSTRAINT "Trigger_pkey" PRIMARY KEY ("Id") ,
CONSTRAINT "Trigger_ChannelId_TriggerId_key1" UNIQUE ("ChannelId", "TriggerId")
)
WITHOUT OIDS;

ALTER TABLE "Trigger" OWNER TO "postgres";

CREATE TABLE "TriggerRouter" (
"TriggerId" int4 NOT NULL,
"RouterId" int4 NOT NULL,
CONSTRAINT "TriggerRouter_pkey" PRIMARY KEY ("TriggerId", "RouterId") 
)
WITHOUT OIDS;

ALTER TABLE "TriggerRouter" OWNER TO "postgres";


ALTER TABLE "Node" ADD CONSTRAINT "FK__Node__NodeGroupI__5629CD9C" FOREIGN KEY ("NodeGroupId") REFERENCES "NodeGroup" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "NodeGroup" ADD CONSTRAINT "FK__NodeGroup__Proje__5441852A" FOREIGN KEY ("ProjectId") REFERENCES "Project" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "Router" ADD CONSTRAINT "FK__Router__SourceNo__5812160E" FOREIGN KEY ("SourceNodeGroupId") REFERENCES "NodeGroup" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "Router" ADD CONSTRAINT "Router_ProjectId_fkey2" FOREIGN KEY ("ProjectId") REFERENCES "Project" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "Router" ADD CONSTRAINT "Router_TargetNodeId_fkey1" FOREIGN KEY ("TargetNodeId") REFERENCES "Node" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "sym_conflict" ADD CONSTRAINT "sym_fk_cf_2_grp_lnk" FOREIGN KEY ("source_node_group_id", "target_node_group_id") REFERENCES "sym_node_group_link" ("source_node_group_id", "target_node_group_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_file_trigger_router" ADD CONSTRAINT "sym_fk_ftr_2_ftrg" FOREIGN KEY ("trigger_id") REFERENCES "sym_file_trigger" ("trigger_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_file_trigger_router" ADD CONSTRAINT "sym_fk_ftr_2_rtr" FOREIGN KEY ("router_id") REFERENCES "sym_router" ("router_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_grouplet_link" ADD CONSTRAINT "sym_fk_gpltlnk_2_gplt" FOREIGN KEY ("grouplet_id") REFERENCES "sym_grouplet" ("grouplet_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_node_group_link" ADD CONSTRAINT "sym_fk_lnk_2_grp_src" FOREIGN KEY ("source_node_group_id") REFERENCES "sym_node_group" ("node_group_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_node_group_link" ADD CONSTRAINT "sym_fk_lnk_2_grp_tgt" FOREIGN KEY ("target_node_group_id") REFERENCES "sym_node_group" ("node_group_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_node_identity" ADD CONSTRAINT "sym_fk_ident_2_node" FOREIGN KEY ("node_id") REFERENCES "sym_node" ("node_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_node_security" ADD CONSTRAINT "sym_fk_sec_2_node" FOREIGN KEY ("node_id") REFERENCES "sym_node" ("node_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_router" ADD CONSTRAINT "sym_fk_rt_2_grp_lnk" FOREIGN KEY ("source_node_group_id", "target_node_group_id") REFERENCES "sym_node_group_link" ("source_node_group_id", "target_node_group_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_transform_table" ADD CONSTRAINT "sym_fk_tt_2_grp_lnk" FOREIGN KEY ("source_node_group_id", "target_node_group_id") REFERENCES "sym_node_group_link" ("source_node_group_id", "target_node_group_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_trigger" ADD CONSTRAINT "sym_fk_trg_2_chnl" FOREIGN KEY ("channel_id") REFERENCES "sym_channel" ("channel_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_trigger" ADD CONSTRAINT "sym_fk_trg_2_rld_chnl" FOREIGN KEY ("reload_channel_id") REFERENCES "sym_channel" ("channel_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_trigger_router" ADD CONSTRAINT "sym_fk_tr_2_rtr" FOREIGN KEY ("router_id") REFERENCES "sym_router" ("router_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_trigger_router" ADD CONSTRAINT "sym_fk_tr_2_trg" FOREIGN KEY ("trigger_id") REFERENCES "sym_trigger" ("trigger_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_trigger_router_grouplet" ADD CONSTRAINT "sym_fk_trgplt_2_gplt" FOREIGN KEY ("grouplet_id") REFERENCES "sym_grouplet" ("grouplet_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "sym_trigger_router_grouplet" ADD CONSTRAINT "sym_fk_trgplt_2_tr" FOREIGN KEY ("trigger_id", "router_id") REFERENCES "sym_trigger_router" ("trigger_id", "router_id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "Trigger" ADD CONSTRAINT "FK__Trigger__Channel__571DF1D5" FOREIGN KEY ("ChannelId") REFERENCES "Channel" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "TriggerRouter" ADD CONSTRAINT "FK__TriggerRo__Route__5AEE82B9" FOREIGN KEY ("RouterId") REFERENCES "Router" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "TriggerRouter" ADD CONSTRAINT "FK__TriggerRo__Trigg__59FA5E80" FOREIGN KEY ("TriggerId") REFERENCES "Trigger" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;


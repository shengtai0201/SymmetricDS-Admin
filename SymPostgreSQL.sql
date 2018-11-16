CREATE TABLE "Channel" (
"Id" serial4 NOT NULL,
"ChannelId" varchar(128) NOT NULL,
"Description" varchar(255),
PRIMARY KEY ("Id") ,
CONSTRAINT "UQ__Channel__38C3E815BDE93267" UNIQUE ("ChannelId")
)
WITHOUT OIDS;

CREATE TABLE "Node" (
"Id" serial4 NOT NULL,
"NodeGroupId" int4 NOT NULL,
"DatabaseType" int4 NOT NULL,
"DatabaseHost" varchar(16),
"DatabaseName" varchar(16),
"DatabaseUser" varchar(16),
"DatabasePassword" varchar(16),
"SyncUrlPort" varchar(4),
"ExternalId" varchar(8) NOT NULL,
"JobPurgePeriodTimeMs" int4 DEFAULT ((7200000)),
"JobRoutingPeriodTimeMs" int4 DEFAULT ((5000)),
"JobPushPeriodTimeMs" int4 DEFAULT ((10000)),
"JobPullPeriodTimeMs" int4 DEFAULT ((10000)),
"InitialLoadCreateFirst" bool NOT NULL,
"NodePassword" varchar(50),
"Version" int4 NOT NULL DEFAULT 0,
PRIMARY KEY ("Id") ,
CONSTRAINT "UQ__Node__599A6201BA246948" UNIQUE ("NodeGroupId", "ExternalId")
)
WITHOUT OIDS;

CREATE TABLE "NodeGroup" (
"Id" serial4 NOT NULL,
"ProjectId" int4 NOT NULL,
"NodeGroupId" varchar(50) NOT NULL,
"Description" varchar(255),
PRIMARY KEY ("Id") ,
CONSTRAINT "UQ__NodeGrou__2B71BB70E8EC1C0F" UNIQUE ("NodeGroupId")
)
WITHOUT OIDS;

CREATE TABLE "Project" (
"Id" serial4 NOT NULL,
"Name" varchar(64) NOT NULL,
PRIMARY KEY ("Id") ,
CONSTRAINT "UQ__Project__737584F67BFEC234" UNIQUE ("Name")
)
WITHOUT OIDS;

CREATE TABLE "Router" (
"Id" serial4 NOT NULL,
"ProjectId" int4 NOT NULL,
"RouterId" varchar(50) NOT NULL,
"SourceNodeGroupId" int4 NOT NULL,
"TargetNodeId" int4 NOT NULL,
PRIMARY KEY ("Id") ,
CONSTRAINT "UQ__Router__6C9DDD0BCF6FFE85" UNIQUE ("RouterId")
)
WITHOUT OIDS;

CREATE TABLE "Trigger" (
"Id" serial4 NOT NULL,
"ChannelId" int4 NOT NULL,
"TriggerId" varchar(128) NOT NULL,
"SourceTableName" varchar(255) NOT NULL,
PRIMARY KEY ("Id") ,
UNIQUE ("ChannelId", "TriggerId")
)
WITHOUT OIDS;

CREATE TABLE "TriggerRouter" (
"TriggerId" int4 NOT NULL,
"RouterId" int4 NOT NULL,
PRIMARY KEY ("TriggerId", "RouterId") 
)
WITHOUT OIDS;


ALTER TABLE "Node" ADD CONSTRAINT "FK__Node__NodeGroupI__5629CD9C" FOREIGN KEY ("NodeGroupId") REFERENCES "NodeGroup" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "NodeGroup" ADD CONSTRAINT "FK__NodeGroup__Proje__5441852A" FOREIGN KEY ("ProjectId") REFERENCES "Project" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "Router" ADD CONSTRAINT "FK__Router__SourceNo__5812160E" FOREIGN KEY ("SourceNodeGroupId") REFERENCES "NodeGroup" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "Trigger" ADD CONSTRAINT "FK__Trigger__Channel__571DF1D5" FOREIGN KEY ("ChannelId") REFERENCES "Channel" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "TriggerRouter" ADD CONSTRAINT "FK__TriggerRo__Trigg__59FA5E80" FOREIGN KEY ("TriggerId") REFERENCES "Trigger" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "TriggerRouter" ADD CONSTRAINT "FK__TriggerRo__Route__5AEE82B9" FOREIGN KEY ("RouterId") REFERENCES "Router" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "Router" ADD FOREIGN KEY ("ProjectId") REFERENCES "Project" ("Id") ON DELETE CASCADE;
ALTER TABLE "Router" ADD FOREIGN KEY ("TargetNodeId") REFERENCES "Node" ("Id") ON DELETE CASCADE;


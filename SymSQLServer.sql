CREATE TABLE [Channel] (
[Id] int NOT NULL,
[ChannelId] varchar(128) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
[Description] varchar(255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
PRIMARY KEY ([Id]) ,
CONSTRAINT [UQ__Channel__38C3E815BDE93267] UNIQUE ([ChannelId] ASC)
)
GO

DBCC CHECKIDENT (N'[Channel]', RESEED, 0)
GO
ALTER TABLE [Channel] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [Node] (
[Id] int NOT NULL,
[NodeGroupId] int NOT NULL,
[DatabaseType] int NULL,
[DatabaseHost] varchar(16) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
[DatabaseName] varchar(16) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
[DatabaseUser] varchar(16) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
[DatabasePassword] varchar(16) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
[SyncUrlPort] varchar(4) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
[ExternalId] varchar(8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
[JobPurgePeriodTimeMs] int NULL DEFAULT ((7200000)),
[JobRoutingPeriodTimeMs] int NULL DEFAULT ((5000)),
[JobPushPeriodTimeMs] int NULL DEFAULT ((10000)),
[JobPullPeriodTimeMs] int NULL DEFAULT ((10000)),
[InitialLoadCreateFirst] bit NOT NULL DEFAULT ((1)),
[NodePassword] varchar(50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
[Version] int NOT NULL,
PRIMARY KEY ([Id]) ,
CONSTRAINT [UQ__Node__599A6201BA246948] UNIQUE ([NodeGroupId] ASC, [ExternalId] ASC)
)
GO

DBCC CHECKIDENT (N'[Node]', RESEED, 0)
GO
ALTER TABLE [Node] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [NodeGroup] (
[Id] int NOT NULL,
[ProjectId] int NOT NULL,
[NodeGroupId] varchar(50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
[Description] varchar(255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
PRIMARY KEY ([Id]) ,
CONSTRAINT [UQ__NodeGrou__2B71BB70E8EC1C0F] UNIQUE ([NodeGroupId] ASC)
)
GO

DBCC CHECKIDENT (N'[NodeGroup]', RESEED, 0)
GO
ALTER TABLE [NodeGroup] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [Project] (
[Id] int NOT NULL,
[Name] nvarchar(64) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
PRIMARY KEY ([Id]) ,
CONSTRAINT [UQ__Project__737584F67BFEC234] UNIQUE ([Name] ASC)
)
GO

DBCC CHECKIDENT (N'[Project]', RESEED, 0)
GO
ALTER TABLE [Project] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [Router] (
[Id] int NOT NULL,
[RouterId] varchar(50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
[SourceNodeGroupId] int NULL,
[TargetNodeGroupId] int NULL,
PRIMARY KEY ([Id]) ,
CONSTRAINT [UQ__Router__6C9DDD0BCF6FFE85] UNIQUE ([RouterId] ASC)
)
GO

DBCC CHECKIDENT (N'[Router]', RESEED, 0)
GO
ALTER TABLE [Router] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [Trigger] (
[Id] int NOT NULL,
[ChannelId] int NOT NULL,
[TriggerId] varchar(128) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
[SourceTableName] varchar(255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
PRIMARY KEY ([Id]) ,
UNIQUE ([ChannelId] ASC, [TriggerId] ASC)
)
GO

DBCC CHECKIDENT (N'[Trigger]', RESEED, 0)
GO
ALTER TABLE [Trigger] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [TriggerRouter] (
[TriggerId] int NOT NULL,
[RouterId] int NOT NULL,
PRIMARY KEY ([TriggerId], [RouterId]) 
)
GO

DBCC CHECKIDENT (N'[TriggerRouter]', RESEED, 0)
GO
ALTER TABLE [TriggerRouter] SET ( LOCK_ESCALATION = TABLE )
GO


ALTER TABLE [Node] ADD CONSTRAINT [FK__Node__NodeGroupI__5629CD9C] FOREIGN KEY ([NodeGroupId]) REFERENCES [NodeGroup] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [NodeGroup] ADD CONSTRAINT [FK__NodeGroup__Proje__5441852A] FOREIGN KEY ([ProjectId]) REFERENCES [Project] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Router] ADD CONSTRAINT [FK__Router__SourceNo__5812160E] FOREIGN KEY ([SourceNodeGroupId]) REFERENCES [NodeGroup] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Router] ADD CONSTRAINT [FK__Router__TargetNo__59063A47] FOREIGN KEY ([TargetNodeGroupId]) REFERENCES [NodeGroup] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Trigger] ADD CONSTRAINT [FK__Trigger__Channel__571DF1D5] FOREIGN KEY ([ChannelId]) REFERENCES [Channel] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [TriggerRouter] ADD CONSTRAINT [FK__TriggerRo__Trigg__59FA5E80] FOREIGN KEY ([TriggerId]) REFERENCES [Trigger] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [TriggerRouter] ADD CONSTRAINT [FK__TriggerRo__Route__5AEE82B9] FOREIGN KEY ([RouterId]) REFERENCES [Router] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


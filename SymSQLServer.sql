USE [Sym]
GO
/****** Object:  Table [dbo].[Channel]    Script Date: 2018/11/29 上午 09:18:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Channel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChannelId] [varchar](128) NOT NULL,
	[Description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ChannelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Node]    Script Date: 2018/11/29 上午 09:18:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Node](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NodeGroupId] [int] NOT NULL,
	[DatabaseType] [int] NOT NULL,
	[DatabaseHost] [varchar](16) NULL,
	[DatabaseName] [varchar](16) NULL,
	[DatabaseUser] [varchar](16) NULL,
	[DatabasePassword] [varchar](16) NULL,
	[SyncUrlPort] [varchar](4) NULL,
	[ExternalId] [varchar](8) NOT NULL,
	[JobPurgePeriodTimeMs] [int] NULL,
	[JobRoutingPeriodTimeMs] [int] NULL,
	[JobPushPeriodTimeMs] [int] NULL,
	[JobPullPeriodTimeMs] [int] NULL,
	[InitialLoadCreateFirst] [bit] NOT NULL,
	[NodePassword] [varchar](50) NULL,
	[Version] [int] NOT NULL,
 CONSTRAINT [PK__Node__3214EC072C15CEDA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Node__599A6201BA246948] UNIQUE NONCLUSTERED 
(
	[NodeGroupId] ASC,
	[ExternalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NodeGroup]    Script Date: 2018/11/29 上午 09:18:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodeGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[NodeGroupId] [varchar](50) NOT NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK__NodeGrou__3214EC077D6F367C] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__NodeGrou__2B71BB705D235567] UNIQUE NONCLUSTERED 
(
	[NodeGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 2018/11/29 上午 09:18:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Router]    Script Date: 2018/11/29 上午 09:18:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Router](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[RouterId] [varchar](50) NOT NULL,
	[SourceNodeGroupId] [int] NOT NULL,
	[TargetNodeId] [int] NOT NULL,
 CONSTRAINT [PK__Router__3214EC076F716841] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Router__6C9DDD0BC2F868EA] UNIQUE NONCLUSTERED 
(
	[RouterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trigger]    Script Date: 2018/11/29 上午 09:18:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trigger](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChannelId] [int] NOT NULL,
	[TriggerId] [varchar](128) NOT NULL,
	[SourceTableName] [varchar](255) NOT NULL,
 CONSTRAINT [PK__Trigger__3214EC07E6098069] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Trigger__09D0C9E3256E676D] UNIQUE NONCLUSTERED 
(
	[ChannelId] ASC,
	[TriggerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TriggerRouter]    Script Date: 2018/11/29 上午 09:18:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TriggerRouter](
	[TriggerId] [int] NOT NULL,
	[RouterId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TriggerId] ASC,
	[RouterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Node] ADD  CONSTRAINT [DF__Node__JobPurgePe__403A8C7D]  DEFAULT ((7200000)) FOR [JobPurgePeriodTimeMs]
GO
ALTER TABLE [dbo].[Node] ADD  CONSTRAINT [DF__Node__JobRouting__412EB0B6]  DEFAULT ((5000)) FOR [JobRoutingPeriodTimeMs]
GO
ALTER TABLE [dbo].[Node] ADD  CONSTRAINT [DF__Node__JobPushPer__4222D4EF]  DEFAULT ((10000)) FOR [JobPushPeriodTimeMs]
GO
ALTER TABLE [dbo].[Node] ADD  CONSTRAINT [DF__Node__JobPullPer__4316F928]  DEFAULT ((10000)) FOR [JobPullPeriodTimeMs]
GO
ALTER TABLE [dbo].[Node] ADD  CONSTRAINT [DF__Node__InitialLoa__440B1D61]  DEFAULT ((1)) FOR [InitialLoadCreateFirst]
GO
ALTER TABLE [dbo].[Node]  WITH CHECK ADD  CONSTRAINT [FK_Node_NodeGroup] FOREIGN KEY([NodeGroupId])
REFERENCES [dbo].[NodeGroup] ([Id])
GO
ALTER TABLE [dbo].[Node] CHECK CONSTRAINT [FK_Node_NodeGroup]
GO
ALTER TABLE [dbo].[NodeGroup]  WITH CHECK ADD  CONSTRAINT [FK_NodeGroup_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[NodeGroup] CHECK CONSTRAINT [FK_NodeGroup_Project]
GO
ALTER TABLE [dbo].[Router]  WITH CHECK ADD  CONSTRAINT [FK_Router_Node] FOREIGN KEY([TargetNodeId])
REFERENCES [dbo].[Node] ([Id])
GO
ALTER TABLE [dbo].[Router] CHECK CONSTRAINT [FK_Router_Node]
GO
ALTER TABLE [dbo].[Router]  WITH CHECK ADD  CONSTRAINT [FK_Router_NodeGroup] FOREIGN KEY([SourceNodeGroupId])
REFERENCES [dbo].[NodeGroup] ([Id])
GO
ALTER TABLE [dbo].[Router] CHECK CONSTRAINT [FK_Router_NodeGroup]
GO
ALTER TABLE [dbo].[Router]  WITH CHECK ADD  CONSTRAINT [FK_Router_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Router] CHECK CONSTRAINT [FK_Router_Project]
GO
ALTER TABLE [dbo].[Trigger]  WITH CHECK ADD  CONSTRAINT [FK_Trigger_Channel] FOREIGN KEY([ChannelId])
REFERENCES [dbo].[Channel] ([Id])
GO
ALTER TABLE [dbo].[Trigger] CHECK CONSTRAINT [FK_Trigger_Channel]
GO
ALTER TABLE [dbo].[TriggerRouter]  WITH CHECK ADD  CONSTRAINT [FK_TriggerRouter_Router] FOREIGN KEY([RouterId])
REFERENCES [dbo].[Router] ([Id])
GO
ALTER TABLE [dbo].[TriggerRouter] CHECK CONSTRAINT [FK_TriggerRouter_Router]
GO
ALTER TABLE [dbo].[TriggerRouter]  WITH CHECK ADD  CONSTRAINT [FK_TriggerRouter_Trigger] FOREIGN KEY([TriggerId])
REFERENCES [dbo].[Trigger] ([Id])
GO
ALTER TABLE [dbo].[TriggerRouter] CHECK CONSTRAINT [FK_TriggerRouter_Trigger]
GO

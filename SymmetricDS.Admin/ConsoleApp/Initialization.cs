using Microsoft.EntityFrameworkCore;
using SymmetricDS.Admin.Master;
using SymmetricDS.Admin.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.ConsoleApp
{
    public class Initialization : IInitialization
    {
        private readonly Databases database;
        private readonly MasterDbContext masterDbContext;
        private readonly ServerDbContext serverDbContext;

        public Initialization(Databases database, string connectionString)
        {
            this.database = database;
            this.masterDbContext = new MasterDbContext(database, connectionString);
            this.serverDbContext = new ServerDbContext(database, connectionString);
        }

        //private readonly SymDbContext dbContext;
        //public Initialization(INode configuration)
        //{
        //    this.dbContext = new SymDbContext(configuration.ConnectionString);
        //}

        public bool Channel()
        {
            var oldChannels = this.masterDbContext.SymChannel.Select(x => x).ToDictionary(x => x.ChannelId, x => x);
            var newChannels = this.serverDbContext.Channel.Select(x => x).ToDictionary(x => x.ChannelId, x => x);

            foreach (var channel in newChannels)
            {
                if (!oldChannels.ContainsKey(channel.Key))
                {
                    // 新增
                    this.masterDbContext.SymChannel.Add(new SymChannel
                    {
                        ChannelId = channel.Value.ChannelId,
                        ProcessingOrder = 1,
                        MaxBatchSize = 100000,
                        Enabled = 1,
                        Description = channel.Value.Description
                    });
                }
                else
                {
                    // 修改
                    var oldChannel = oldChannels[channel.Key];
                    oldChannel.Description = channel.Value.Description;
                }
            }

            foreach (var channel in oldChannels)
            {
                if (new string[] { "config", "reload", "monitor", "heartbeat", "default", "dynamic" }.Contains(channel.Key))
                    continue;

                if (!newChannels.ContainsKey(channel.Key))
                {
                    // 刪除
                    this.masterDbContext.SymChannel.Remove(channel.Value);
                }
            }

            bool result = false;
            try
            {
                this.masterDbContext.SaveChanges();
                result = true;
            }
            catch { }

            return result;
        }

        public void CreateTables(string path, IConfiguration configuration)
        {
            string fileName = Path.GetFullPath(path + @"bin\symadmin.bat");

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = $"--engine {configuration.EngineName} create-sym-tables"
            };

            Process process = Process.Start(startInfo);

            StreamReader reader = process.StandardOutput;
            string line = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                if (!string.IsNullOrEmpty(line))
                    Console.WriteLine(line);

                line = reader.ReadLine();
            }
            reader.Close();
            reader.Dispose();

            process.WaitForExit();
            process.Close();
            process.Dispose();
        }

        public bool Node(INode node)
        {
            var oldNode = this.masterDbContext.SymNode.SingleOrDefault(x => x.NodeId == node.ExternalId);
            if (oldNode == null)
            {
                // 新增
                this.masterDbContext.SymNode.Add(new SymNode
                {
                    NodeId = node.ExternalId,
                    NodeGroupId = node.GroupId,
                    ExternalId = node.ExternalId,
                    SyncEnabled = 1
                });
            }
            else
            {
                // 修改
                oldNode.NodeGroupId = node.GroupId;
            }

            // 刪除
            var otherNodes = this.masterDbContext.SymNode.Where(x => x.NodeId != node.ExternalId).ToList();
            if (otherNodes.Count > 0)
                this.masterDbContext.SymNode.RemoveRange(otherNodes);

            DateTime dateTimeNow = DateTime.Now;
            var oldNodeSecurity = this.masterDbContext.SymNodeSecurity.SingleOrDefault(x => x.NodeId == node.ExternalId);
            if (oldNodeSecurity == null)
            {
                // 新增
                this.masterDbContext.SymNodeSecurity.Add(new SymNodeSecurity
                {
                    NodeId = node.ExternalId,
                    NodePassword = node.Password,
                    RegistrationEnabled = 0,
                    RegistrationTime = dateTimeNow,
                    InitialLoadEnabled = 0,
                    InitialLoadTime = dateTimeNow,
                    RevInitialLoadEnabled = 0,
                    CreatedAtNodeId = node.ExternalId
                });
            }
            else
            {
                // 修改
                oldNodeSecurity.NodePassword = node.Password;
                oldNodeSecurity.RegistrationTime = dateTimeNow;
                oldNodeSecurity.InitialLoadTime = dateTimeNow;
            }

            // 刪除
            var otherNodeSecurities = this.masterDbContext.SymNodeSecurity.Where(x => x.NodeId != node.ExternalId).ToList();
            if (otherNodeSecurities.Count > 0)
                this.masterDbContext.SymNodeSecurity.RemoveRange(otherNodeSecurities);

            var oldNodeIdentity = this.masterDbContext.SymNodeIdentity.SingleOrDefault(x => x.NodeId == node.ExternalId);
            if (oldNodeIdentity == null)
            {
                // 新增
                this.masterDbContext.SymNodeIdentity.Add(new SymNodeIdentity
                {
                    NodeId = node.ExternalId
                });
            }

            // 刪除
            var otherNodeIdentities = this.masterDbContext.SymNodeIdentity.Where(x => x.NodeId != node.ExternalId).ToList();
            if (otherNodeIdentities.Count > 0)
                this.masterDbContext.SymNodeIdentity.RemoveRange(otherNodeIdentities);

            bool result = false;
            try
            {
                this.masterDbContext.SaveChanges();
                result = true;
            }
            catch { }

            return result;
        }

        public bool NodeGroups(INode node)
        {
            var oldNodeGroups = this.masterDbContext.SymNodeGroup.Select(x => x).ToDictionary(x => x.NodeGroupId, x => x);
            var newNodeGroups = this.serverDbContext.NodeGroup.Where(ng => ng.ProjectId == node.ProjectId).ToDictionary(x => x.NodeGroupId, x => x);

            foreach (var nodeGroup in newNodeGroups)
            {
                if (!oldNodeGroups.ContainsKey(nodeGroup.Key))
                {
                    // 新增
                    this.masterDbContext.SymNodeGroup.Add(new SymNodeGroup
                    {
                        NodeGroupId = nodeGroup.Value.NodeGroupId,
                        Description = nodeGroup.Value.Description
                    });
                }
                else
                {
                    // 修改
                    var oldNodeGroup = oldNodeGroups[nodeGroup.Key];
                    oldNodeGroup.Description = nodeGroup.Value.Description;
                }
            }

            foreach (var nodeGroup in oldNodeGroups)
            {
                if (!newNodeGroups.ContainsKey(nodeGroup.Key))
                {
                    // 刪除
                    this.masterDbContext.SymNodeGroup.Remove(nodeGroup.Value);
                }
            }

            bool result = false;
            try
            {
                this.masterDbContext.SaveChanges();
                result = true;
            }
            catch { }

            return result;
        }

        public bool Relationship()
        {
            var oldTriggerRouters = this.masterDbContext.SymTriggerRouter.Select(x => x).ToDictionary(x => string.Format("[{0}][{1}]", x.TriggerId, x.RouterId), x => x);
            var newTriggerRouters = this.serverDbContext.TriggerRouter.Include("Trigger").Include("Router").Select(x => x).ToDictionary(x => string.Format("[{0}][{1}]", x.Trigger.TriggerId, x.Router.RouterId), x => x);

            DateTime dateTimeNow = DateTime.Now;
            foreach (var triggerRouter in newTriggerRouters)
            {
                if (!oldTriggerRouters.ContainsKey(triggerRouter.Key))
                {
                    // 新增
                    this.masterDbContext.SymTriggerRouter.Add(new SymTriggerRouter
                    {
                        TriggerId = triggerRouter.Value.Trigger.TriggerId,
                        RouterId = triggerRouter.Value.Router.RouterId,
                        InitialLoadOrder = 200,
                        LastUpdateTime = dateTimeNow,
                        CreateTime = dateTimeNow
                    });
                }
                else
                {
                    // 修改
                    var oldTriggerRouter = oldTriggerRouters[triggerRouter.Key];
                    oldTriggerRouter.LastUpdateTime = dateTimeNow;
                    oldTriggerRouter.CreateTime = dateTimeNow;
                }
            }

            foreach (var triggerRouter in oldTriggerRouters)
            {
                if (!newTriggerRouters.ContainsKey(triggerRouter.Key))
                {
                    // 刪除
                    this.masterDbContext.SymTriggerRouter.Remove(triggerRouter.Value);
                }
            }

            bool result = false;
            try
            {
                this.masterDbContext.SaveChanges();
                result = true;
            }
            catch { }

            return result;
        }

        public bool Router()
        {
            var oldRouters = this.masterDbContext.SymRouter.Select(x => x).ToDictionary(x => x.RouterId, x => x);
            var newRouters = this.serverDbContext.Router.Include("SourceNodeGroup").Include("TargetNode.NodeGroup").Select(x => x).ToDictionary(x => x.RouterId, x => x);

            DateTime dateTimeNow = DateTime.Now;
            foreach (var router in newRouters)
            {
                if (!oldRouters.ContainsKey(router.Key))
                {
                    // 新增
                    this.masterDbContext.SymRouter.Add(new SymRouter
                    {
                        RouterId = router.Value.RouterId,
                        SourceNodeGroupId = router.Value.SourceNodeGroup.NodeGroupId,
                        TargetNodeGroupId = router.Value.TargetNode.NodeGroup.NodeGroupId,
                        RouterType = "default",
                        CreateTime = dateTimeNow,
                        LastUpdateTime = dateTimeNow
                    });
                }
                else
                {
                    // 修改
                    var oldRouter = oldRouters[router.Key];
                    oldRouter.SourceNodeGroupId = router.Value.SourceNodeGroup.NodeGroupId;
                    oldRouter.TargetNodeGroupId = router.Value.TargetNode.NodeGroup.NodeGroupId;
                    oldRouter.CreateTime = dateTimeNow;
                    oldRouter.LastUpdateTime = dateTimeNow;
                }
            }

            foreach (var router in oldRouters)
            {
                if (!newRouters.ContainsKey(router.Key))
                {
                    // 刪除
                    this.masterDbContext.SymRouter.Remove(router.Value);
                }
            }

            bool result = false;
            try
            {
                this.masterDbContext.SaveChanges();
                result = true;
            }
            catch { }

            return result;
        }

        public bool SynchronizationMethod(INode node)
        {
            var oldNodeGroupLinks = this.masterDbContext.SymNodeGroupLink.Select(x => x).ToDictionary(x => string.Format("[{0}][{1}]", x.SourceNodeGroupId, x.TargetNodeGroupId), x => x);

            var newNodeGroupLinks = new Dictionary<string, char>();
            var newNodeGroupLinkDatas = this.serverDbContext.Router.Include("SourceNodeGroup").Include("TargetNode.NodeGroup").Where(x => x.ProjectId == node.ProjectId).ToList();
            foreach (var data in newNodeGroupLinkDatas)
            {
                newNodeGroupLinks.Add(string.Format("[{0}][{1}]", data.SourceNodeGroup.NodeGroupId, data.TargetNode.NodeGroup.NodeGroupId), 'P');
                newNodeGroupLinks.Add(string.Format("[{0}][{1}]", data.TargetNode.NodeGroup.NodeGroupId, data.SourceNodeGroup.NodeGroupId), 'W');
            }

            foreach (var nodeGroupLink in newNodeGroupLinks)
            {
                if (!oldNodeGroupLinks.ContainsKey(nodeGroupLink.Key))
                {
                    var values = nodeGroupLink.Key.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                    // 新增
                    this.masterDbContext.SymNodeGroupLink.Add(new SymNodeGroupLink
                    {
                        SourceNodeGroupId = values[0],
                        TargetNodeGroupId = values[1],
                        DataEventAction = nodeGroupLink.Value
                    });
                }
                else
                {
                    // 修改
                    var oldNodeGroupLink = oldNodeGroupLinks[nodeGroupLink.Key];
                    oldNodeGroupLink.DataEventAction = nodeGroupLink.Value;
                }
            }

            foreach (var nodeGroupLink in oldNodeGroupLinks)
            {
                if (!newNodeGroupLinks.ContainsKey(nodeGroupLink.Key))
                {
                    // 刪除
                    this.masterDbContext.SymNodeGroupLink.Remove(nodeGroupLink.Value);
                }
            }

            bool result = false;
            try
            {
                this.masterDbContext.SaveChanges();
                result = true;
            }
            catch { }

            return result;
        }

        public bool Triggers()
        {
            var oldTriggers = this.masterDbContext.SymTrigger.Select(x => x).ToDictionary(x => x.TriggerId, x => x);
            var newTriggers = this.serverDbContext.Trigger.Include("Channel").Select(x => x).ToDictionary(x => x.TriggerId, x => x);

            DateTime dateTimeNow = DateTime.Now;
            foreach (var trigger in newTriggers)
            {
                if (!oldTriggers.ContainsKey(trigger.Key))
                {
                    // 新增
                    this.masterDbContext.SymTrigger.Add(new SymTrigger
                    {
                        TriggerId = trigger.Value.TriggerId,
                        SourceTableName = trigger.Value.SourceTableName,
                        ChannelId = trigger.Value.Channel.ChannelId,
                        ReloadChannelId = "reload",
                        SyncOnUpdate = 1,
                        SyncOnInsert = 1,
                        SyncOnDelete = 1,
                        SyncOnIncomingBatch = 0,
                        UseStreamLobs = 0,
                        UseCaptureLobs = 0,
                        UseCaptureOldData = 1,
                        UseHandleKeyUpdates = 1,
                        StreamRow = 0,
                        LastUpdateTime = dateTimeNow,
                        CreateTime = dateTimeNow
                    });
                }
                else
                {
                    // 修改
                    var oldTrigger = oldTriggers[trigger.Key];
                    oldTrigger.SourceTableName = trigger.Value.SourceTableName;
                    oldTrigger.ChannelId = trigger.Value.Channel.ChannelId;
                    oldTrigger.LastUpdateTime = dateTimeNow;
                    oldTrigger.CreateTime = dateTimeNow;
                }
            }

            foreach (var trigger in oldTriggers)
            {
                if (!newTriggers.ContainsKey(trigger.Key))
                {
                    // 刪除
                    this.masterDbContext.SymTrigger.Remove(trigger.Value);
                }
            }

            bool result = false;
            try
            {
                this.masterDbContext.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        public Node GetNode(int nodeId)
        {
            Node result = null;

            var node = this.serverDbContext.Node
                .Include("NodeGroup")
                .Include("NodeGroup.Router").Include("NodeGroup.Router.TargetNode").Include("NodeGroup.Router.TargetNode.NodeGroup")
                .SingleOrDefault(n => n.Id == nodeId);
            if (node != null)
                result = new Node(this.database, node);

            return result;
        }
    }
}

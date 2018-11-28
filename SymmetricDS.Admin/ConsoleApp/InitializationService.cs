using Microsoft.EntityFrameworkCore;
using Shengtai;
using SymmetricDS.Admin.Master;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SymmetricDS.Admin.ConsoleApp
{
    internal static class InitializationService
    {
        public static bool Channel(MasterDbContext masterDbContext, Server.ServerDbContext serverDbContext)
        {
            var oldChannels = masterDbContext.SymChannel.Select(x => x).ToDictionary(x => x.ChannelId, x => x);
            var newChannels = serverDbContext.Channel.Select(x => x).ToDictionary(x => x.ChannelId, x => x);

            foreach (var channel in newChannels)
            {
                if (!oldChannels.ContainsKey(channel.Key))
                {
                    // 新增
                    masterDbContext.SymChannel.Add(new SymChannel
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
                    masterDbContext.SymChannel.Remove(channel.Value);
                }
            }

            bool result = false;
            try
            {
                masterDbContext.SaveChanges();
                result = true;
            }
            catch { }

            return result;
        }

        public static void CreateTables(string path, IConfiguration configuration)
        {
            string fileName = Path.GetFullPath(path + @"bin\symadmin.bat");
            DefaultExtensions.ProcessStart(fileName, $"--engine {configuration.EngineName} create-sym-tables");
        }

        public static bool Node(INode node, MasterDbContext masterDbContext)
        {
            var oldNode = masterDbContext.SymNode.SingleOrDefault(x => x.NodeId == node.ExternalId);
            if (oldNode == null)
            {
                // 新增
                masterDbContext.SymNode.Add(new SymNode
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
            var otherNodes = masterDbContext.SymNode.Where(x => x.NodeId != node.ExternalId).ToList();
            if (otherNodes.Count > 0)
                masterDbContext.SymNode.RemoveRange(otherNodes);

            DateTime dateTimeNow = DateTime.Now;
            var oldNodeSecurity = masterDbContext.SymNodeSecurity.SingleOrDefault(x => x.NodeId == node.ExternalId);
            if (oldNodeSecurity == null)
            {
                // 新增
                masterDbContext.SymNodeSecurity.Add(new SymNodeSecurity
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
            var otherNodeSecurities = masterDbContext.SymNodeSecurity.Where(x => x.NodeId != node.ExternalId).ToList();
            if (otherNodeSecurities.Count > 0)
                masterDbContext.SymNodeSecurity.RemoveRange(otherNodeSecurities);

            var oldNodeIdentity = masterDbContext.SymNodeIdentity.SingleOrDefault(x => x.NodeId == node.ExternalId);
            if (oldNodeIdentity == null)
            {
                // 新增
                masterDbContext.SymNodeIdentity.Add(new SymNodeIdentity
                {
                    NodeId = node.ExternalId
                });
            }

            // 刪除
            var otherNodeIdentities = masterDbContext.SymNodeIdentity.Where(x => x.NodeId != node.ExternalId).ToList();
            if (otherNodeIdentities.Count > 0)
                masterDbContext.SymNodeIdentity.RemoveRange(otherNodeIdentities);

            bool result = false;
            try
            {
                masterDbContext.SaveChanges();
                result = true;
            }
            catch { }

            return result;
        }

        public static bool NodeGroups(INode node, MasterDbContext masterDbContext, Server.ServerDbContext serverDbContext)
        {
            var oldNodeGroups = masterDbContext.SymNodeGroup.Select(x => x).ToDictionary(x => x.NodeGroupId, x => x);
            var newNodeGroups = serverDbContext.NodeGroup.Where(ng => ng.ProjectId == node.ProjectId).ToDictionary(x => x.NodeGroupId, x => x);

            foreach (var nodeGroup in newNodeGroups)
            {
                if (!oldNodeGroups.ContainsKey(nodeGroup.Key))
                {
                    // 新增
                    masterDbContext.SymNodeGroup.Add(new SymNodeGroup
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
                    masterDbContext.SymNodeGroup.Remove(nodeGroup.Value);
                }
            }

            bool result = false;
            try
            {
                masterDbContext.SaveChanges();
                result = true;
            }
            catch { }

            return result;
        }

        public static bool Relationship(MasterDbContext masterDbContext, Server.ServerDbContext serverDbContext)
        {
            var oldTriggerRouters = masterDbContext.SymTriggerRouter.Select(x => x).ToDictionary(x => string.Format("[{0}][{1}]", x.TriggerId, x.RouterId), x => x);
            var newTriggerRouters = serverDbContext.TriggerRouter.Include("Trigger").Include("Router").Select(x => x).ToDictionary(x => string.Format("[{0}][{1}]", x.Trigger.TriggerId, x.Router.RouterId), x => x);

            DateTime dateTimeNow = DateTime.Now;
            foreach (var triggerRouter in newTriggerRouters)
            {
                if (!oldTriggerRouters.ContainsKey(triggerRouter.Key))
                {
                    // 新增
                    masterDbContext.SymTriggerRouter.Add(new SymTriggerRouter
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
                    masterDbContext.SymTriggerRouter.Remove(triggerRouter.Value);
                }
            }

            bool result = false;
            try
            {
                masterDbContext.SaveChanges();
                result = true;
            }
            catch { }

            return result;
        }

        public static bool Router(MasterDbContext masterDbContext, Server.ServerDbContext serverDbContext)
        {
            var oldRouters = masterDbContext.SymRouter.Select(x => x).ToDictionary(x => x.RouterId, x => x);
            var newRouters = serverDbContext.Router.Include("SourceNodeGroup").Include("TargetNode.NodeGroup").Select(x => x).ToDictionary(x => x.RouterId, x => x);

            DateTime dateTimeNow = DateTime.Now;
            foreach (var router in newRouters)
            {
                if (!oldRouters.ContainsKey(router.Key))
                {
                    // 新增
                    masterDbContext.SymRouter.Add(new SymRouter
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
                    masterDbContext.SymRouter.Remove(router.Value);
                }
            }

            bool result = false;
            try
            {
                masterDbContext.SaveChanges();
                result = true;
            }
            catch { }

            return result;
        }

        public static bool SynchronizationMethod(INode node, MasterDbContext masterDbContext, Server.ServerDbContext serverDbContext)
        {
            var oldNodeGroupLinks = masterDbContext.SymNodeGroupLink.Select(x => x).ToDictionary(x => string.Format("[{0}][{1}]", x.SourceNodeGroupId, x.TargetNodeGroupId), x => x);

            var newNodeGroupLinks = new Dictionary<string, char>();
            var newNodeGroupLinkDatas = serverDbContext.Router.Include("SourceNodeGroup").Include("TargetNode.NodeGroup").Where(x => x.ProjectId == node.ProjectId).ToList();
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
                    masterDbContext.SymNodeGroupLink.Add(new SymNodeGroupLink
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
                    masterDbContext.SymNodeGroupLink.Remove(nodeGroupLink.Value);
                }
            }

            bool result = false;
            try
            {
                masterDbContext.SaveChanges();
                result = true;
            }
            catch { }

            return result;
        }

        public static bool Triggers(MasterDbContext masterDbContext, Server.ServerDbContext serverDbContext)
        {
            var oldTriggers = masterDbContext.SymTrigger.Select(x => x).ToDictionary(x => x.TriggerId, x => x);
            var newTriggers = serverDbContext.Trigger.Include("Channel").Select(x => x).ToDictionary(x => x.TriggerId, x => x);

            DateTime dateTimeNow = DateTime.Now;
            foreach (var trigger in newTriggers)
            {
                if (!oldTriggers.ContainsKey(trigger.Key))
                {
                    // 新增
                    masterDbContext.SymTrigger.Add(new SymTrigger
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
                    masterDbContext.SymTrigger.Remove(trigger.Value);
                }
            }

            bool result = false;
            try
            {
                masterDbContext.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        public static Node GetNode(int nodeId, Server.ServerDbContext serverDbContext, Databases database)
        {
            Node result = null;

            var node = serverDbContext.Node
                .Include("NodeGroup").Include("NodeGroup.Router")
                .Include("NodeGroup.Router.TargetNode").Include("NodeGroup.Router.TargetNode.NodeGroup")
                .Include("Router.SourceNodeGroup.Node")
                .SingleOrDefault(n => n.Id == nodeId);
            if (node != null)
            {
                var projectId = node.NodeGroup.ProjectId;
                var router = node.NodeGroup.Router.SingleOrDefault(x => x.ProjectId == projectId);
                if (router == null)
                    result = new MasterNode(database, node);
                else
                    result = new Node(database, node);
            }

            return result;
        }

        public static void StartService(string path)
        {
            string fileName = Path.GetFullPath(path + @"bin\sym_service.bat");

            DefaultExtensions.ProcessStart(fileName, "start");
        }

        public static void InstallService(string path)
        {
            string fileName = Path.GetFullPath(path + @"bin\sym_service.bat");

            DefaultExtensions.ProcessStart(fileName, "install");
        }

        public static void StopService(string path)
        {
            string fileName = Path.GetFullPath(path + @"bin\sym_service.bat");

            DefaultExtensions.ProcessStart(fileName, "stop");
        }

        public static void UninstallService(string path)
        {
            string fileName = Path.GetFullPath(path + @"bin\sym_service.bat");

            DefaultExtensions.ProcessStart(fileName, "uninstall");
        }
    }
}

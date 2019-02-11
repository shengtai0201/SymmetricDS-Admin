using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shengtai.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace SymmetricDS.Admin.Server.Service
{
    public class InitializationService : Shengtai.Data.Core.Repository<ServerDbContext, AppSettings, ConnectionStrings>, IInitializationService
    {
        public InitializationService(IOptions<AppSettings> options) : base(options)
        {
        }

        public IDictionary<string, Channel> GetNewChannels()
        {
            return this.DbContext.Channel.Select(x => x).ToDictionary(x => x.ChannelId, x => x);
        }

        public IList<Router> GetNewNodeGroupLinkDatas(int projectId)
        {
            return this.DbContext.Router.Include("SourceNodeGroup").Include("TargetNode.NodeGroup").Where(x => x.ProjectId == projectId).ToList();
        }

        public IDictionary<string, NodeGroup> GetNewNodeGroups(int projectId)
        {
            return this.DbContext.NodeGroup.Where(ng => ng.ProjectId == projectId).ToDictionary(x => x.NodeGroupId, x => x);
        }

        public IDictionary<string, Router> GetNewRouters()
        {
            return this.DbContext.Router.Include("SourceNodeGroup").Include("TargetNode.NodeGroup").Select(x => x).ToDictionary(x => x.RouterId, x => x);
        }

        public IDictionary<string, TriggerRouter> GetNewTriggerRouters()
        {
            return this.DbContext.TriggerRouter.Include("Trigger").Include("Router").Select(x => x).ToDictionary(x => string.Format("[{0}][{1}]", x.Trigger.TriggerId, x.Router.RouterId), x => x);
        }

        public IDictionary<string, Trigger> GetNewTriggers()
        {
            return this.DbContext.Trigger.Include("Channel").Select(x => x).ToDictionary(x => x.TriggerId, x => x);
        }

        public Node GetNode(int nodeId)
        {
            return this.DbContext.Node
                .Include("NodeGroup").Include("NodeGroup.Router")
                .Include("NodeGroup.Router.TargetNode").Include("NodeGroup.Router.TargetNode.NodeGroup")
                .Include("Router.SourceNodeGroup.Node")
                .SingleOrDefault(n => n.Id == nodeId);
        }
    }
}
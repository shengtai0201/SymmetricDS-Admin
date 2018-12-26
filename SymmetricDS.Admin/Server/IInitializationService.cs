using System.Collections.Generic;

namespace SymmetricDS.Admin.Server
{
    public interface IInitializationService
    {
        IDictionary<string, Channel> GetNewChannels();

        Node GetNode(int nodeId);

        IDictionary<string, NodeGroup> GetNewNodeGroups(int projectId);

        IDictionary<string, TriggerRouter> GetNewTriggerRouters();

        IDictionary<string, Router> GetNewRouters();

        IList<Router> GetNewNodeGroupLinkDatas(int projectId);

        IDictionary<string, Trigger> GetNewTriggers();
    }
}
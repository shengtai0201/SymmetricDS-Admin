using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Server
{
    public partial class Router
    {
        public Router()
        {
            TriggerRouter = new HashSet<TriggerRouter>();
        }

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string RouterId { get; set; }
        public int? SourceNodeGroupId { get; set; }
        public int? TargetNodeGroupId { get; set; }

        public Project Project { get; set; }
        public NodeGroup SourceNodeGroup { get; set; }
        public NodeGroup TargetNodeGroup { get; set; }
        public ICollection<TriggerRouter> TriggerRouter { get; set; }
    }
}

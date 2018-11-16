using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Server
{
    public partial class NodeGroup
    {
        public NodeGroup()
        {
            Node = new HashSet<Node>();
            Router = new HashSet<Router>();
        }

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string NodeGroupId { get; set; }
        public string Description { get; set; }

        public Project Project { get; set; }
        public ICollection<Node> Node { get; set; }
        public ICollection<Router> Router { get; set; }
    }
}

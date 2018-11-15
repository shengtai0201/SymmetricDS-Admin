using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Server
{
    public partial class Project
    {
        public Project()
        {
            NodeGroup = new HashSet<NodeGroup>();
            Router = new HashSet<Router>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<NodeGroup> NodeGroup { get; set; }
        public ICollection<Router> Router { get; set; }
    }
}

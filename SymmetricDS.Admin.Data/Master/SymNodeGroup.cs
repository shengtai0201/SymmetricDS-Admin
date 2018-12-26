using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymNodeGroup
    {
        public SymNodeGroup()
        {
            SymNodeGroupLinkSourceNodeGroup = new HashSet<SymNodeGroupLink>();
            SymNodeGroupLinkTargetNodeGroup = new HashSet<SymNodeGroupLink>();
        }

        public string NodeGroupId { get; set; }
        public string Description { get; set; }
        public DateTime? CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }

        public ICollection<SymNodeGroupLink> SymNodeGroupLinkSourceNodeGroup { get; set; }
        public ICollection<SymNodeGroupLink> SymNodeGroupLinkTargetNodeGroup { get; set; }
    }
}
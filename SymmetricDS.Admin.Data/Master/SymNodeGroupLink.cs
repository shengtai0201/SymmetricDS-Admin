using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymNodeGroupLink
    {
        public SymNodeGroupLink()
        {
            SymConflict = new HashSet<SymConflict>();
            SymRouter = new HashSet<SymRouter>();
            SymTransformTable = new HashSet<SymTransformTable>();
        }

        public string SourceNodeGroupId { get; set; }
        public string TargetNodeGroupId { get; set; }
        public char DataEventAction { get; set; }
        public short SyncConfigEnabled { get; set; }
        public short IsReversible { get; set; }
        public DateTime? CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }

        public SymNodeGroup SourceNodeGroup { get; set; }
        public SymNodeGroup TargetNodeGroup { get; set; }
        public ICollection<SymConflict> SymConflict { get; set; }
        public ICollection<SymRouter> SymRouter { get; set; }
        public ICollection<SymTransformTable> SymTransformTable { get; set; }
    }
}

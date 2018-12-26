using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymTriggerRouter
    {
        public SymTriggerRouter()
        {
            SymTriggerRouterGrouplet = new HashSet<SymTriggerRouterGrouplet>();
        }

        public string TriggerId { get; set; }
        public string RouterId { get; set; }
        public short Enabled { get; set; }
        public int InitialLoadOrder { get; set; }
        public string InitialLoadSelect { get; set; }
        public string InitialLoadDeleteStmt { get; set; }
        public short PingBackEnabled { get; set; }
        public DateTime CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string Description { get; set; }

        public SymRouter Router { get; set; }
        public SymTrigger Trigger { get; set; }
        public ICollection<SymTriggerRouterGrouplet> SymTriggerRouterGrouplet { get; set; }
    }
}
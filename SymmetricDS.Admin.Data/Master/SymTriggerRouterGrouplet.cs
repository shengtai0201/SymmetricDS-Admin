using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymTriggerRouterGrouplet
    {
        public string GroupletId { get; set; }
        public string TriggerId { get; set; }
        public string RouterId { get; set; }
        public char AppliesWhen { get; set; }
        public DateTime CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public SymGrouplet Grouplet { get; set; }
        public SymTriggerRouter SymTriggerRouter { get; set; }
    }
}
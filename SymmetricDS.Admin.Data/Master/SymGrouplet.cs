using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymGrouplet
    {
        public SymGrouplet()
        {
            SymGroupletLink = new HashSet<SymGroupletLink>();
            SymTriggerRouterGrouplet = new HashSet<SymTriggerRouterGrouplet>();
        }

        public string GroupletId { get; set; }
        public char GroupletLinkPolicy { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public ICollection<SymGroupletLink> SymGroupletLink { get; set; }
        public ICollection<SymTriggerRouterGrouplet> SymTriggerRouterGrouplet { get; set; }
    }
}
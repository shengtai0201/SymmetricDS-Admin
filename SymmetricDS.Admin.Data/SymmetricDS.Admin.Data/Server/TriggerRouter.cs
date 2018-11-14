using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Data.Server
{
    public partial class TriggerRouter
    {
        public int TriggerId { get; set; }
        public int RouterId { get; set; }

        public Router Router { get; set; }
        public Trigger Trigger { get; set; }
    }
}

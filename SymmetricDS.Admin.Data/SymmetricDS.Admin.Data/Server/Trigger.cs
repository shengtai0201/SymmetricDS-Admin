using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Data.Server
{
    public partial class Trigger
    {
        public Trigger()
        {
            TriggerRouter = new HashSet<TriggerRouter>();
        }

        public int Id { get; set; }
        public int ChannelId { get; set; }
        public string TriggerId { get; set; }
        public string SourceTableName { get; set; }

        public Channel Channel { get; set; }
        public ICollection<TriggerRouter> TriggerRouter { get; set; }
    }
}

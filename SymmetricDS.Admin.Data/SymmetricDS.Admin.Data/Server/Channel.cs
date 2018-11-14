using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Data.Server
{
    public partial class Channel
    {
        public Channel()
        {
            Trigger = new HashSet<Trigger>();
        }

        public int Id { get; set; }
        public string ChannelId { get; set; }
        public string Description { get; set; }

        public ICollection<Trigger> Trigger { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin
{
    public class Channel
    {
        public string ChannelId { get; set; }
        public string Description { get; set; }

        // Trigger 中的 Table 若有關聯，需在同一個 Channel
        public ICollection<Trigger> Triggers { get; set; }
    }
}

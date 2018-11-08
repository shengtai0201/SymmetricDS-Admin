using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin
{
    public class NodeGroup
    {
        public string GroupId { get; set; }
        public string Description { get; set; }

        public NodeGroup Parent { get; set; }
    }
}

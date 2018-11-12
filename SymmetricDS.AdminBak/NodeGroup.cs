using SymmetricDS.Admin.Data;
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

        public ICollection<NodeGroup> Children { get; set; }

        public IEnumerable<sym_node_group> GetNodeGroups()
        {
            IList<sym_node_group> result = new List<sym_node_group>();



            return result;
        }
    }
}

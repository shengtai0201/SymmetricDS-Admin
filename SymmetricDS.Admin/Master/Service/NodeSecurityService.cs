using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymmetricDS.Admin.Master.Service
{
    internal static class NodeSecurityService
    {
        public static bool CheckRegister(ICollection<string> nodeIds, MasterDbContext dbContext)
        {
            var count = dbContext.SymNodeSecurity.Count(x => nodeIds.Contains(x.NodeId));
            return count == nodeIds.Count;
        }
    }
}

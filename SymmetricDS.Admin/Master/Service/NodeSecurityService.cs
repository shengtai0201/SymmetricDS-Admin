using Microsoft.Extensions.Options;
using Shengtai.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace SymmetricDS.Admin.Master.Service
{
    public class NodeSecurityService : Shengtai.Data.Core.Repository<MasterDbContext, AppSettings, ConnectionStrings>, INodeSecurityService
    {
        public NodeSecurityService(IOptions<AppSettings> options) : base(options)
        {
        }

        public bool CheckRegister(ICollection<string> nodeIds)
        {
            var count = this.DbContext.SymNodeSecurity.Count(x => nodeIds.Contains(x.NodeId));
            return count == nodeIds.Count;
        }
    }
}
using Microsoft.Extensions.Options;
using Shengtai.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace SymmetricDS.Admin.Master.Service
{
    public class NodeSecurityService : Repository<MasterDbContext, AppSettings, ConnectionStrings, IPrincipal>, INodeSecurityService
    {
        public NodeSecurityService(IOptions<AppSettings> options, MasterDbContext dbContext, IClient client) : base(options.Value, dbContext, client)
        {
        }

        public bool CheckRegister(ICollection<string> nodeIds)
        {
            var count = this.DbContext.SymNodeSecurity.Count(x => nodeIds.Contains(x.NodeId));
            return count == nodeIds.Count;
        }
    }
}
using Microsoft.Extensions.Options;
using Shengtai;
using Shengtai.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymmetricDS.Admin.Master.Service
{
    public class NpgsqlNodeSecurityService : NpgsqlRepository<MasterDbContext, ConnectionStrings>, INodeSecurityService
    {
        public NpgsqlNodeSecurityService(IOptions<AppSettings> options, MasterDbContext dbContext) : base(options.Value, dbContext) { }

        public bool CheckRegister(ICollection<string> nodeIds)
        {
            var count = this.DbContext.SymNodeSecurity.Count(x => nodeIds.Contains(x.NodeId));
            return count == nodeIds.Count;
        }
    }
}

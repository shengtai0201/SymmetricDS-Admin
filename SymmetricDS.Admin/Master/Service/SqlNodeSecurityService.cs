using Microsoft.Extensions.Options;
using Shengtai;
using Shengtai.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymmetricDS.Admin.Master.Service
{
    public class SqlNodeSecurityService : SqlRepository<MasterDbContext, ConnectionStrings>, INodeSecurityService
    {
        public SqlNodeSecurityService(IOptions<AppSettings> options, MasterDbContext dbContext) : base(options.Value, dbContext) { }

        public bool CheckRegister(ICollection<string> nodeIds)
        {
            return NodeSecurityService.CheckRegister(nodeIds, this.DbContext);
        }
    }
}

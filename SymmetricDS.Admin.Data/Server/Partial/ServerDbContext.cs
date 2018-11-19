using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricDS.Admin.Server
{
    public partial class ServerDbContext : SymDbContext
    {
        public ServerDbContext(Databases database, string connectionString) : base(database, connectionString) { }
    }
}

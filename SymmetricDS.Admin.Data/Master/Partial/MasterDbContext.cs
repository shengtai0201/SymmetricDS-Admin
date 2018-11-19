using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricDS.Admin.Master
{
    public partial class MasterDbContext : SymDbContext
    {
        public MasterDbContext(Databases database, string connectionString) : base(database, connectionString) { }
    }
}

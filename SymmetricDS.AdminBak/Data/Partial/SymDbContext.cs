using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.Data
{
    public partial class SymDbContext : DbContext
    {
        public SymDbContext(string connectionString) : base(connectionString) { }
    }
}

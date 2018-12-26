using Microsoft.EntityFrameworkCore;

namespace SymmetricDS.Admin.Server
{
    public partial class ServerDbContext : DbContext
    {
        public ServerDbContext(DbContextOptions<ServerDbContext> options) : base(options)
        {
        }
    }
}
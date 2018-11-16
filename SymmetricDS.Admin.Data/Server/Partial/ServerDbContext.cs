using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricDS.Admin.Server
{
    public partial class ServerDbContext : DbContext
    {
        private readonly Databases database;
        private readonly string connectionString;

        public ServerDbContext(Databases database, string connectionString)
        {
            this.database = database;
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                switch (this.database)
                {
                    case Databases.PostgreSQL:
                        optionsBuilder.UseNpgsql(this.connectionString);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

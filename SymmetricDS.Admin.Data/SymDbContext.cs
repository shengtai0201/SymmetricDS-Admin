﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricDS.Admin
{
    public abstract class SymDbContext : DbContext
    {
        private readonly Databases database;
        private readonly string connectionString;

        public SymDbContext(Databases database, string connectionString)
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

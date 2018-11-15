using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SymmetricDS.Admin.Server
{
    public partial class ServerDbContext : DbContext
    {
        public ServerDbContext()
        {
        }

        public ServerDbContext(DbContextOptions<ServerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Channel> Channel { get; set; }
        public virtual DbSet<Node> Node { get; set; }
        public virtual DbSet<NodeGroup> NodeGroup { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Router> Router { get; set; }
        public virtual DbSet<Trigger> Trigger { get; set; }
        public virtual DbSet<TriggerRouter> TriggerRouter { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=Sym;Username=postgres;port=5432");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Channel>(entity =>
            {
                entity.HasIndex(e => e.ChannelId)
                    .HasName("UQ__Channel__38C3E815BDE93267")
                    .IsUnique();

                entity.Property(e => e.ChannelId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Description).HasMaxLength(255);
            });

            modelBuilder.Entity<Node>(entity =>
            {
                entity.HasIndex(e => new { e.NodeGroupId, e.ExternalId })
                    .HasName("UQ__Node__599A6201BA246948")
                    .IsUnique();

                entity.Property(e => e.DatabaseHost).HasMaxLength(16);

                entity.Property(e => e.DatabaseName).HasMaxLength(16);

                entity.Property(e => e.DatabasePassword).HasMaxLength(16);

                entity.Property(e => e.DatabaseUser).HasMaxLength(16);

                entity.Property(e => e.ExternalId)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.JobPullPeriodTimeMs).HasDefaultValueSql("10000");

                entity.Property(e => e.JobPurgePeriodTimeMs).HasDefaultValueSql("7200000");

                entity.Property(e => e.JobPushPeriodTimeMs).HasDefaultValueSql("10000");

                entity.Property(e => e.JobRoutingPeriodTimeMs).HasDefaultValueSql("5000");

                entity.Property(e => e.NodePassword).HasMaxLength(50);

                entity.Property(e => e.SyncUrlPort).HasMaxLength(4);

                entity.HasOne(d => d.NodeGroup)
                    .WithMany(p => p.Node)
                    .HasForeignKey(d => d.NodeGroupId)
                    .HasConstraintName("FK__Node__NodeGroupI__5629CD9C");
            });

            modelBuilder.Entity<NodeGroup>(entity =>
            {
                entity.HasIndex(e => e.NodeGroupId)
                    .HasName("UQ__NodeGrou__2B71BB70E8EC1C0F")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.NodeGroupId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.NodeGroup)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__NodeGroup__Proje__5441852A");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Project__737584F67BFEC234")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Router>(entity =>
            {
                entity.HasIndex(e => e.RouterId)
                    .HasName("UQ__Router__6C9DDD0BCF6FFE85")
                    .IsUnique();

                entity.Property(e => e.RouterId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Router)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("Router_ProjectId_fkey");

                entity.HasOne(d => d.SourceNodeGroup)
                    .WithMany(p => p.RouterSourceNodeGroup)
                    .HasForeignKey(d => d.SourceNodeGroupId)
                    .HasConstraintName("FK__Router__SourceNo__5812160E");

                entity.HasOne(d => d.TargetNodeGroup)
                    .WithMany(p => p.RouterTargetNodeGroup)
                    .HasForeignKey(d => d.TargetNodeGroupId)
                    .HasConstraintName("FK__Router__TargetNo__59063A47");
            });

            modelBuilder.Entity<Trigger>(entity =>
            {
                entity.HasIndex(e => new { e.ChannelId, e.TriggerId })
                    .HasName("Trigger_ChannelId_TriggerId_key")
                    .IsUnique();

                entity.Property(e => e.SourceTableName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.TriggerId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Trigger)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("FK__Trigger__Channel__571DF1D5");
            });

            modelBuilder.Entity<TriggerRouter>(entity =>
            {
                entity.HasKey(e => new { e.TriggerId, e.RouterId });

                entity.HasOne(d => d.Router)
                    .WithMany(p => p.TriggerRouter)
                    .HasForeignKey(d => d.RouterId)
                    .HasConstraintName("FK__TriggerRo__Route__5AEE82B9");

                entity.HasOne(d => d.Trigger)
                    .WithMany(p => p.TriggerRouter)
                    .HasForeignKey(d => d.TriggerId)
                    .HasConstraintName("FK__TriggerRo__Trigg__59FA5E80");
            });
        }
    }
}

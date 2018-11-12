namespace SymmetricDS.Admin.Server
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ServerDbContext : DbContext
    {
        public ServerDbContext()
            : base("name=ServerDbContext")
        {
        }

        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<Node> Nodes { get; set; }
        public virtual DbSet<NodeGroup> NodeGroups { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Router> Routers { get; set; }
        public virtual DbSet<Trigger> Triggers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Channel>()
                .Property(e => e.ChannelId)
                .IsUnicode(false);

            modelBuilder.Entity<Channel>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Channel>()
                .HasMany(e => e.Triggers)
                .WithRequired(e => e.Channel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Node>()
                .Property(e => e.DatabaseHost)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .Property(e => e.DatabaseName)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .Property(e => e.DatabaseUser)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .Property(e => e.DatabasePassword)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .Property(e => e.SyncUrlPort)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .Property(e => e.ExternalId)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .Property(e => e.NodePassword)
                .IsUnicode(false);

            modelBuilder.Entity<NodeGroup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<NodeGroup>()
                .Property(e => e.NodeGroupId)
                .IsUnicode(false);

            modelBuilder.Entity<NodeGroup>()
                .HasMany(e => e.Nodes)
                .WithRequired(e => e.NodeGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NodeGroup>()
                .HasMany(e => e.Routers)
                .WithOptional(e => e.NodeGroup)
                .HasForeignKey(e => e.SourceNodeGroupId);

            modelBuilder.Entity<NodeGroup>()
                .HasMany(e => e.Routers1)
                .WithOptional(e => e.NodeGroup1)
                .HasForeignKey(e => e.TargetNodeGroupId);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.NodeGroups)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Router>()
                .Property(e => e.RouterId)
                .IsUnicode(false);

            modelBuilder.Entity<Router>()
                .HasMany(e => e.Triggers)
                .WithMany(e => e.Routers)
                .Map(m => m.ToTable("TriggerRouter").MapLeftKey("RouterId").MapRightKey("TriggerId"));

            modelBuilder.Entity<Trigger>()
                .Property(e => e.TriggerId)
                .IsUnicode(false);

            modelBuilder.Entity<Trigger>()
                .Property(e => e.SourceTableName)
                .IsUnicode(false);
        }
    }
}

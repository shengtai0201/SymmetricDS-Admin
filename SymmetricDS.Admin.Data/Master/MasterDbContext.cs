using Microsoft.EntityFrameworkCore;

namespace SymmetricDS.Admin.Master
{
    public partial class MasterDbContext : DbContext
    {
        public virtual DbSet<SymChannel> SymChannel { get; set; }
        public virtual DbSet<SymConflict> SymConflict { get; set; }
        public virtual DbSet<SymContext> SymContext { get; set; }
        public virtual DbSet<SymData> SymData { get; set; }
        public virtual DbSet<SymDataEvent> SymDataEvent { get; set; }
        public virtual DbSet<SymDataGap> SymDataGap { get; set; }
        public virtual DbSet<SymExtension> SymExtension { get; set; }
        public virtual DbSet<SymExtractRequest> SymExtractRequest { get; set; }
        public virtual DbSet<SymFileIncoming> SymFileIncoming { get; set; }
        public virtual DbSet<SymFileSnapshot> SymFileSnapshot { get; set; }
        public virtual DbSet<SymFileTrigger> SymFileTrigger { get; set; }
        public virtual DbSet<SymFileTriggerRouter> SymFileTriggerRouter { get; set; }
        public virtual DbSet<SymGrouplet> SymGrouplet { get; set; }
        public virtual DbSet<SymGroupletLink> SymGroupletLink { get; set; }
        public virtual DbSet<SymIncomingBatch> SymIncomingBatch { get; set; }
        public virtual DbSet<SymIncomingError> SymIncomingError { get; set; }
        public virtual DbSet<SymJob> SymJob { get; set; }
        public virtual DbSet<SymLoadFilter> SymLoadFilter { get; set; }
        public virtual DbSet<SymLock> SymLock { get; set; }
        public virtual DbSet<SymMonitor> SymMonitor { get; set; }
        public virtual DbSet<SymMonitorEvent> SymMonitorEvent { get; set; }
        public virtual DbSet<SymNode> SymNode { get; set; }
        public virtual DbSet<SymNodeChannelCtl> SymNodeChannelCtl { get; set; }
        public virtual DbSet<SymNodeCommunication> SymNodeCommunication { get; set; }
        public virtual DbSet<SymNodeGroup> SymNodeGroup { get; set; }
        public virtual DbSet<SymNodeGroupChannelWnd> SymNodeGroupChannelWnd { get; set; }
        public virtual DbSet<SymNodeGroupLink> SymNodeGroupLink { get; set; }
        public virtual DbSet<SymNodeHost> SymNodeHost { get; set; }
        public virtual DbSet<SymNodeHostChannelStats> SymNodeHostChannelStats { get; set; }
        public virtual DbSet<SymNodeHostJobStats> SymNodeHostJobStats { get; set; }
        public virtual DbSet<SymNodeHostStats> SymNodeHostStats { get; set; }
        public virtual DbSet<SymNodeIdentity> SymNodeIdentity { get; set; }
        public virtual DbSet<SymNodeSecurity> SymNodeSecurity { get; set; }
        public virtual DbSet<SymNotification> SymNotification { get; set; }
        public virtual DbSet<SymOutgoingBatch> SymOutgoingBatch { get; set; }
        public virtual DbSet<SymParameter> SymParameter { get; set; }
        public virtual DbSet<SymRegistrationRedirect> SymRegistrationRedirect { get; set; }
        public virtual DbSet<SymRegistrationRequest> SymRegistrationRequest { get; set; }
        public virtual DbSet<SymRouter> SymRouter { get; set; }
        public virtual DbSet<SymSequence> SymSequence { get; set; }
        public virtual DbSet<SymTableReloadRequest> SymTableReloadRequest { get; set; }
        public virtual DbSet<SymTransformColumn> SymTransformColumn { get; set; }
        public virtual DbSet<SymTransformTable> SymTransformTable { get; set; }
        public virtual DbSet<SymTrigger> SymTrigger { get; set; }
        public virtual DbSet<SymTriggerHist> SymTriggerHist { get; set; }
        public virtual DbSet<SymTriggerRouter> SymTriggerRouter { get; set; }
        public virtual DbSet<SymTriggerRouterGrouplet> SymTriggerRouterGrouplet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            switch (this.database)
            {
                case Databases.PostgreSQL:
                    this.NpgsqlModelCreating(modelBuilder);
                    break;

                case Databases.SQLServer:
                    this.SqlModelCreating(modelBuilder);
                    break;
            }
        }
    }
}
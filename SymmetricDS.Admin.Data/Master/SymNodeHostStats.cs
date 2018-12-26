using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymNodeHostStats
    {
        public string NodeId { get; set; }
        public string HostName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long Restarted { get; set; }
        public long? NodesPulled { get; set; }
        public long? TotalNodesPullTime { get; set; }
        public long? NodesPushed { get; set; }
        public long? TotalNodesPushTime { get; set; }
        public long? NodesRejected { get; set; }
        public long? NodesRegistered { get; set; }
        public long? NodesLoaded { get; set; }
        public long? NodesDisabled { get; set; }
        public long? PurgedDataRows { get; set; }
        public long? PurgedDataEventRows { get; set; }
        public long? PurgedBatchOutgoingRows { get; set; }
        public long? PurgedBatchIncomingRows { get; set; }
        public long? TriggersCreatedCount { get; set; }
        public long? TriggersRebuiltCount { get; set; }
        public long? TriggersRemovedCount { get; set; }
    }
}
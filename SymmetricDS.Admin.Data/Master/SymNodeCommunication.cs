using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymNodeCommunication
    {
        public string NodeId { get; set; }
        public string Queue { get; set; }
        public string CommunicationType { get; set; }
        public DateTime? LockTime { get; set; }
        public string LockingServerId { get; set; }
        public DateTime? LastLockTime { get; set; }
        public long? LastLockMillis { get; set; }
        public long? SuccessCount { get; set; }
        public long? FailCount { get; set; }
        public long? SkipCount { get; set; }
        public long? TotalSuccessCount { get; set; }
        public long? TotalFailCount { get; set; }
        public long? TotalSuccessMillis { get; set; }
        public long? TotalFailMillis { get; set; }
        public long? BatchToSendCount { get; set; }
        public int? NodePriority { get; set; }
    }
}
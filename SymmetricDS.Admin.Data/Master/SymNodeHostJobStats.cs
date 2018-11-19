using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymNodeHostJobStats
    {
        public string NodeId { get; set; }
        public string HostName { get; set; }
        public string JobName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long? ProcessedCount { get; set; }
        public string TargetNodeId { get; set; }
        public int? TargetNodeCount { get; set; }
    }
}

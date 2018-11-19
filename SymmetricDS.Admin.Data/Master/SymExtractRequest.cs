using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymExtractRequest
    {
        public long RequestId { get; set; }
        public string NodeId { get; set; }
        public string Queue { get; set; }
        public string Status { get; set; }
        public long StartBatchId { get; set; }
        public long EndBatchId { get; set; }
        public string TriggerId { get; set; }
        public string RouterId { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}

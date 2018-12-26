using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymMonitorEvent
    {
        public string MonitorId { get; set; }
        public string NodeId { get; set; }
        public DateTime EventTime { get; set; }
        public string HostName { get; set; }
        public string Type { get; set; }
        public long Threshold { get; set; }
        public long EventValue { get; set; }
        public int EventCount { get; set; }
        public int SeverityLevel { get; set; }
        public short IsResolved { get; set; }
        public short IsNotified { get; set; }
        public string Details { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}
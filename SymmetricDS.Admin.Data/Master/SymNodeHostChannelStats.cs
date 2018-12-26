using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymNodeHostChannelStats
    {
        public string NodeId { get; set; }
        public string HostName { get; set; }
        public string ChannelId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long? DataRouted { get; set; }
        public long? DataUnrouted { get; set; }
        public long? DataEventInserted { get; set; }
        public long? DataExtracted { get; set; }
        public long? DataBytesExtracted { get; set; }
        public long? DataExtractedErrors { get; set; }
        public long? DataBytesSent { get; set; }
        public long? DataSent { get; set; }
        public long? DataSentErrors { get; set; }
        public long? DataLoaded { get; set; }
        public long? DataBytesLoaded { get; set; }
        public long? DataLoadedErrors { get; set; }
    }
}
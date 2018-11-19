using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymFileSnapshot
    {
        public string TriggerId { get; set; }
        public string RouterId { get; set; }
        public string RelativeDir { get; set; }
        public string FileName { get; set; }
        public string ChannelId { get; set; }
        public string ReloadChannelId { get; set; }
        public char LastEventType { get; set; }
        public long? Crc32Checksum { get; set; }
        public long? FileSize { get; set; }
        public long? FileModifiedTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime CreateTime { get; set; }
    }
}

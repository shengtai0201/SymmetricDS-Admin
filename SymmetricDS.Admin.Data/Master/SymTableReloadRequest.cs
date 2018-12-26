using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymTableReloadRequest
    {
        public string TargetNodeId { get; set; }
        public string SourceNodeId { get; set; }
        public string TriggerId { get; set; }
        public string RouterId { get; set; }
        public DateTime CreateTime { get; set; }
        public short CreateTable { get; set; }
        public short DeleteFirst { get; set; }
        public string ReloadSelect { get; set; }
        public string BeforeCustomSql { get; set; }
        public DateTime? ReloadTime { get; set; }
        public long? LoadId { get; set; }
        public short Processed { get; set; }
        public string ChannelId { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
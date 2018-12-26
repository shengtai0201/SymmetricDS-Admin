using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymNodeChannelCtl
    {
        public string NodeId { get; set; }
        public string ChannelId { get; set; }
        public short? SuspendEnabled { get; set; }
        public short? IgnoreEnabled { get; set; }
        public DateTime? LastExtractTime { get; set; }
    }
}
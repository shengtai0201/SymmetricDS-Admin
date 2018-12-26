using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymNodeGroupChannelWnd
    {
        public string NodeGroupId { get; set; }
        public string ChannelId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public short Enabled { get; set; }
    }
}
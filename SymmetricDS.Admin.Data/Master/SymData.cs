using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymData
    {
        public long DataId { get; set; }
        public string TableName { get; set; }
        public char EventType { get; set; }
        public string RowData { get; set; }
        public string PkData { get; set; }
        public string OldData { get; set; }
        public int TriggerHistId { get; set; }
        public string ChannelId { get; set; }
        public string TransactionId { get; set; }
        public string SourceNodeId { get; set; }
        public string ExternalData { get; set; }
        public string NodeList { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}

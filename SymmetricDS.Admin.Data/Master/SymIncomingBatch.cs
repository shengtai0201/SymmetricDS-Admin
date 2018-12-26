using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymIncomingBatch
    {
        public long BatchId { get; set; }
        public string NodeId { get; set; }
        public string ChannelId { get; set; }
        public string Status { get; set; }
        public short? ErrorFlag { get; set; }
        public string SqlState { get; set; }
        public int SqlCode { get; set; }
        public string SqlMessage { get; set; }
        public string LastUpdateHostname { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Summary { get; set; }
        public int IgnoreCount { get; set; }
        public long ByteCount { get; set; }
        public short? LoadFlag { get; set; }
        public int ExtractCount { get; set; }
        public int SentCount { get; set; }
        public int LoadCount { get; set; }
        public int ReloadRowCount { get; set; }
        public int OtherRowCount { get; set; }
        public int DataRowCount { get; set; }
        public int ExtractRowCount { get; set; }
        public int LoadRowCount { get; set; }
        public int DataInsertRowCount { get; set; }
        public int DataUpdateRowCount { get; set; }
        public int DataDeleteRowCount { get; set; }
        public int ExtractInsertRowCount { get; set; }
        public int ExtractUpdateRowCount { get; set; }
        public int ExtractDeleteRowCount { get; set; }
        public int LoadInsertRowCount { get; set; }
        public int LoadUpdateRowCount { get; set; }
        public int LoadDeleteRowCount { get; set; }
        public int NetworkMillis { get; set; }
        public int FilterMillis { get; set; }
        public int LoadMillis { get; set; }
        public int RouterMillis { get; set; }
        public int ExtractMillis { get; set; }
        public int TransformExtractMillis { get; set; }
        public int TransformLoadMillis { get; set; }
        public long? LoadId { get; set; }
        public short? CommonFlag { get; set; }
        public int FallbackInsertCount { get; set; }
        public int FallbackUpdateCount { get; set; }
        public int IgnoreRowCount { get; set; }
        public int MissingDeleteCount { get; set; }
        public int SkipCount { get; set; }
        public int FailedRowNumber { get; set; }
        public int FailedLineNumber { get; set; }
        public long FailedDataId { get; set; }
    }
}
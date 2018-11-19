using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymIncomingError
    {
        public long BatchId { get; set; }
        public string NodeId { get; set; }
        public long FailedRowNumber { get; set; }
        public long FailedLineNumber { get; set; }
        public string TargetCatalogName { get; set; }
        public string TargetSchemaName { get; set; }
        public string TargetTableName { get; set; }
        public char EventType { get; set; }
        public string BinaryEncoding { get; set; }
        public string ColumnNames { get; set; }
        public string PkColumnNames { get; set; }
        public string RowData { get; set; }
        public string OldData { get; set; }
        public string CurData { get; set; }
        public string ResolveData { get; set; }
        public short? ResolveIgnore { get; set; }
        public string ConflictId { get; set; }
        public DateTime? CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}

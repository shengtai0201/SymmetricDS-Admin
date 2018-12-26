using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymTriggerHist
    {
        public int TriggerHistId { get; set; }
        public string TriggerId { get; set; }
        public string SourceTableName { get; set; }
        public string SourceCatalogName { get; set; }
        public string SourceSchemaName { get; set; }
        public string NameForUpdateTrigger { get; set; }
        public string NameForInsertTrigger { get; set; }
        public string NameForDeleteTrigger { get; set; }
        public long TableHash { get; set; }
        public long TriggerRowHash { get; set; }
        public long TriggerTemplateHash { get; set; }
        public string ColumnNames { get; set; }
        public string PkColumnNames { get; set; }
        public char LastTriggerBuildReason { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? InactiveTime { get; set; }
    }
}
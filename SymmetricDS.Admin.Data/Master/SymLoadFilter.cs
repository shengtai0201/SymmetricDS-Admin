using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymLoadFilter
    {
        public string LoadFilterId { get; set; }
        public string LoadFilterType { get; set; }
        public string SourceNodeGroupId { get; set; }
        public string TargetNodeGroupId { get; set; }
        public string TargetCatalogName { get; set; }
        public string TargetSchemaName { get; set; }
        public string TargetTableName { get; set; }
        public short FilterOnUpdate { get; set; }
        public short FilterOnInsert { get; set; }
        public short FilterOnDelete { get; set; }
        public string BeforeWriteScript { get; set; }
        public string AfterWriteScript { get; set; }
        public string BatchCompleteScript { get; set; }
        public string BatchCommitScript { get; set; }
        public string BatchRollbackScript { get; set; }
        public string HandleErrorScript { get; set; }
        public DateTime CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public int LoadFilterOrder { get; set; }
        public short FailOnError { get; set; }
    }
}
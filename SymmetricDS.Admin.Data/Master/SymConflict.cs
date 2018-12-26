using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymConflict
    {
        public string ConflictId { get; set; }
        public string SourceNodeGroupId { get; set; }
        public string TargetNodeGroupId { get; set; }
        public string TargetChannelId { get; set; }
        public string TargetCatalogName { get; set; }
        public string TargetSchemaName { get; set; }
        public string TargetTableName { get; set; }
        public string DetectType { get; set; }
        public string DetectExpression { get; set; }
        public string ResolveType { get; set; }
        public string PingBack { get; set; }
        public short? ResolveChangesOnly { get; set; }
        public short? ResolveRowOnly { get; set; }
        public DateTime CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public SymNodeGroupLink SymNodeGroupLink { get; set; }
    }
}
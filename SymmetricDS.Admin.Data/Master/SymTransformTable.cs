using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymTransformTable
    {
        public string TransformId { get; set; }
        public string SourceNodeGroupId { get; set; }
        public string TargetNodeGroupId { get; set; }
        public string TransformPoint { get; set; }
        public string SourceCatalogName { get; set; }
        public string SourceSchemaName { get; set; }
        public string SourceTableName { get; set; }
        public string TargetCatalogName { get; set; }
        public string TargetSchemaName { get; set; }
        public string TargetTableName { get; set; }
        public short? UpdateFirst { get; set; }
        public string UpdateAction { get; set; }
        public string DeleteAction { get; set; }
        public int TransformOrder { get; set; }
        public string ColumnPolicy { get; set; }
        public DateTime? CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string Description { get; set; }

        public SymNodeGroupLink SymNodeGroupLink { get; set; }
    }
}
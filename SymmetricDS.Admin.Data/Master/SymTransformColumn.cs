using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymTransformColumn
    {
        public string TransformId { get; set; }
        public char IncludeOn { get; set; }
        public string TargetColumnName { get; set; }
        public string SourceColumnName { get; set; }
        public short? Pk { get; set; }
        public string TransformType { get; set; }
        public string TransformExpression { get; set; }
        public int TransformOrder { get; set; }
        public DateTime? CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string Description { get; set; }
    }
}
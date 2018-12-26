using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymSequence
    {
        public string SequenceName { get; set; }
        public long CurrentValue { get; set; }
        public int IncrementBy { get; set; }
        public long MinValue { get; set; }
        public long MaxValue { get; set; }
        public short? CycleFlag { get; set; }
        public int CacheSize { get; set; }
        public DateTime? CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
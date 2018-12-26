using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymDataGap
    {
        public long StartId { get; set; }
        public long EndId { get; set; }
        public string Status { get; set; }
        public DateTime CreateTime { get; set; }
        public string LastUpdateHostname { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
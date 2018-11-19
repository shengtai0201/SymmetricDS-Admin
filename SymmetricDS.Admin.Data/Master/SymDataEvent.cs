using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymDataEvent
    {
        public long DataId { get; set; }
        public long BatchId { get; set; }
        public string RouterId { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymContext
    {
        public string Name { get; set; }
        public string ContextValue { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymGroupletLink
    {
        public string GroupletId { get; set; }
        public string ExternalId { get; set; }
        public DateTime CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public SymGrouplet Grouplet { get; set; }
    }
}

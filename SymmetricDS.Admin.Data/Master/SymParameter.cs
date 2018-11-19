using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymParameter
    {
        public string ExternalId { get; set; }
        public string NodeGroupId { get; set; }
        public string ParamKey { get; set; }
        public string ParamValue { get; set; }
        public DateTime? CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}

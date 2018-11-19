using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymExtension
    {
        public string ExtensionId { get; set; }
        public string ExtensionType { get; set; }
        public string InterfaceName { get; set; }
        public string NodeGroupId { get; set; }
        public short Enabled { get; set; }
        public int ExtensionOrder { get; set; }
        public string ExtensionText { get; set; }
        public DateTime? CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}

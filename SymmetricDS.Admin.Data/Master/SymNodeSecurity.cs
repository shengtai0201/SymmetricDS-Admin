using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymNodeSecurity
    {
        public string NodeId { get; set; }
        public string NodePassword { get; set; }
        public short? RegistrationEnabled { get; set; }
        public DateTime? RegistrationTime { get; set; }
        public short? InitialLoadEnabled { get; set; }
        public DateTime? InitialLoadTime { get; set; }
        public long? InitialLoadId { get; set; }
        public string InitialLoadCreateBy { get; set; }
        public short? RevInitialLoadEnabled { get; set; }
        public DateTime? RevInitialLoadTime { get; set; }
        public long? RevInitialLoadId { get; set; }
        public string RevInitialLoadCreateBy { get; set; }
        public string CreatedAtNodeId { get; set; }

        public SymNode Node { get; set; }
    }
}

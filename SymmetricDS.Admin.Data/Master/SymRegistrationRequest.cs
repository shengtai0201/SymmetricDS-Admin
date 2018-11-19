using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymRegistrationRequest
    {
        public string NodeGroupId { get; set; }
        public string ExternalId { get; set; }
        public string Status { get; set; }
        public string HostName { get; set; }
        public string IpAddress { get; set; }
        public int? AttemptCount { get; set; }
        public string RegisteredNodeId { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}

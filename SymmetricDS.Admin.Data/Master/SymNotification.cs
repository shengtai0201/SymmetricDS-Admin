using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymNotification
    {
        public string NotificationId { get; set; }
        public string NodeGroupId { get; set; }
        public string ExternalId { get; set; }
        public int SeverityLevel { get; set; }
        public string Type { get; set; }
        public string Expression { get; set; }
        public short Enabled { get; set; }
        public DateTime? CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}

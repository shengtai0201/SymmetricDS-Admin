using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymNodeHost
    {
        public string NodeId { get; set; }
        public string HostName { get; set; }
        public string InstanceId { get; set; }
        public string IpAddress { get; set; }
        public string OsUser { get; set; }
        public string OsName { get; set; }
        public string OsArch { get; set; }
        public string OsVersion { get; set; }
        public int? AvailableProcessors { get; set; }
        public long? FreeMemoryBytes { get; set; }
        public long? TotalMemoryBytes { get; set; }
        public long? MaxMemoryBytes { get; set; }
        public string JavaVersion { get; set; }
        public string JavaVendor { get; set; }
        public string JdbcVersion { get; set; }
        public string SymmetricVersion { get; set; }
        public string TimezoneOffset { get; set; }
        public DateTime? HeartbeatTime { get; set; }
        public DateTime LastRestartTime { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
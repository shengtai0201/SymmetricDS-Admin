using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymLock
    {
        public string LockAction { get; set; }
        public string LockType { get; set; }
        public string LockingServerId { get; set; }
        public DateTime? LockTime { get; set; }
        public int SharedCount { get; set; }
        public int SharedEnable { get; set; }
        public DateTime? LastLockTime { get; set; }
        public string LastLockingServerId { get; set; }
    }
}
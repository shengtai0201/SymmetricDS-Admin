using System;

namespace SymmetricDS.Admin.Master
{
    public partial class SymJob
    {
        public string JobName { get; set; }
        public string JobType { get; set; }
        public short RequiresRegistration { get; set; }
        public string JobExpression { get; set; }
        public string Description { get; set; }
        public string DefaultSchedule { get; set; }
        public short DefaultAutoStart { get; set; }
        public string NodeGroupId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}
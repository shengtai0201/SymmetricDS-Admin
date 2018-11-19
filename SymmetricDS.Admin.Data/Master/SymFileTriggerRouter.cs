using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymFileTriggerRouter
    {
        public string TriggerId { get; set; }
        public string RouterId { get; set; }
        public short Enabled { get; set; }
        public short InitialLoadEnabled { get; set; }
        public string TargetBaseDir { get; set; }
        public string ConflictStrategy { get; set; }
        public DateTime CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string Description { get; set; }

        public SymRouter Router { get; set; }
        public SymFileTrigger Trigger { get; set; }
    }
}

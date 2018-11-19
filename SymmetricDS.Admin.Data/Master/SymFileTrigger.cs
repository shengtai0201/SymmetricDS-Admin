using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymFileTrigger
    {
        public SymFileTrigger()
        {
            SymFileTriggerRouter = new HashSet<SymFileTriggerRouter>();
        }

        public string TriggerId { get; set; }
        public string ChannelId { get; set; }
        public string ReloadChannelId { get; set; }
        public string BaseDir { get; set; }
        public short Recurse { get; set; }
        public string IncludesFiles { get; set; }
        public string ExcludesFiles { get; set; }
        public short SyncOnCreate { get; set; }
        public short SyncOnModified { get; set; }
        public short SyncOnDelete { get; set; }
        public short SyncOnCtlFile { get; set; }
        public short DeleteAfterSync { get; set; }
        public string BeforeCopyScript { get; set; }
        public string AfterCopyScript { get; set; }
        public DateTime CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string Description { get; set; }

        public ICollection<SymFileTriggerRouter> SymFileTriggerRouter { get; set; }
    }
}

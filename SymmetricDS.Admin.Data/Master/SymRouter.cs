using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymRouter
    {
        public SymRouter()
        {
            SymFileTriggerRouter = new HashSet<SymFileTriggerRouter>();
            SymTriggerRouter = new HashSet<SymTriggerRouter>();
        }

        public string RouterId { get; set; }
        public string TargetCatalogName { get; set; }
        public string TargetSchemaName { get; set; }
        public string TargetTableName { get; set; }
        public string SourceNodeGroupId { get; set; }
        public string TargetNodeGroupId { get; set; }
        public string RouterType { get; set; }
        public string RouterExpression { get; set; }
        public short SyncOnUpdate { get; set; }
        public short SyncOnInsert { get; set; }
        public short SyncOnDelete { get; set; }
        public short UseSourceCatalogSchema { get; set; }
        public DateTime CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string Description { get; set; }

        public SymNodeGroupLink SymNodeGroupLink { get; set; }
        public ICollection<SymFileTriggerRouter> SymFileTriggerRouter { get; set; }
        public ICollection<SymTriggerRouter> SymTriggerRouter { get; set; }
    }
}

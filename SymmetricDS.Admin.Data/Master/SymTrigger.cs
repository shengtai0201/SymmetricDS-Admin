using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymTrigger
    {
        public SymTrigger()
        {
            SymTriggerRouter = new HashSet<SymTriggerRouter>();
        }

        public string TriggerId { get; set; }
        public string SourceCatalogName { get; set; }
        public string SourceSchemaName { get; set; }
        public string SourceTableName { get; set; }
        public string ChannelId { get; set; }
        public string ReloadChannelId { get; set; }
        public short SyncOnUpdate { get; set; }
        public short SyncOnInsert { get; set; }
        public short SyncOnDelete { get; set; }
        public short SyncOnIncomingBatch { get; set; }
        public string NameForUpdateTrigger { get; set; }
        public string NameForInsertTrigger { get; set; }
        public string NameForDeleteTrigger { get; set; }
        public string SyncOnUpdateCondition { get; set; }
        public string SyncOnInsertCondition { get; set; }
        public string SyncOnDeleteCondition { get; set; }
        public string CustomBeforeUpdateText { get; set; }
        public string CustomBeforeInsertText { get; set; }
        public string CustomBeforeDeleteText { get; set; }
        public string CustomOnUpdateText { get; set; }
        public string CustomOnInsertText { get; set; }
        public string CustomOnDeleteText { get; set; }
        public string ExternalSelect { get; set; }
        public string TxIdExpression { get; set; }
        public string ChannelExpression { get; set; }
        public string ExcludedColumnNames { get; set; }
        public string IncludedColumnNames { get; set; }
        public string SyncKeyNames { get; set; }
        public short UseStreamLobs { get; set; }
        public short UseCaptureLobs { get; set; }
        public short UseCaptureOldData { get; set; }
        public short UseHandleKeyUpdates { get; set; }
        public short StreamRow { get; set; }
        public DateTime CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string Description { get; set; }

        public SymChannel Channel { get; set; }
        public SymChannel ReloadChannel { get; set; }
        public ICollection<SymTriggerRouter> SymTriggerRouter { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public partial class SymChannel
    {
        public SymChannel()
        {
            SymTriggerChannel = new HashSet<SymTrigger>();
            SymTriggerReloadChannel = new HashSet<SymTrigger>();
        }

        public string ChannelId { get; set; }
        public int ProcessingOrder { get; set; }
        public int MaxBatchSize { get; set; }
        public int MaxBatchToSend { get; set; }
        public int MaxDataToRoute { get; set; }
        public int ExtractPeriodMillis { get; set; }
        public short Enabled { get; set; }
        public short UseOldDataToRoute { get; set; }
        public short UseRowDataToRoute { get; set; }
        public short UsePkDataToRoute { get; set; }
        public short ReloadFlag { get; set; }
        public short FileSyncFlag { get; set; }
        public short ContainsBigLob { get; set; }
        public string BatchAlgorithm { get; set; }
        public string DataLoaderType { get; set; }
        public string Description { get; set; }
        public string Queue { get; set; }
        public decimal MaxNetworkKbps { get; set; }
        public char? DataEventAction { get; set; }
        public DateTime? CreateTime { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }

        public ICollection<SymTrigger> SymTriggerChannel { get; set; }
        public ICollection<SymTrigger> SymTriggerReloadChannel { get; set; }
    }
}

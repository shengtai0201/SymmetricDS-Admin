using Shengtai;
using SymmetricDS.Admin.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricDS.Admin.WebApplication.Models
{
    public class TriggerViewModel : ViewModel<int, TriggerViewModel, Trigger>
    {
        public int? Id { get; set; }

        public ChannelViewModel Channel { get; set; }

        public string TriggerId { get; set; }

        public string SourceTableName { get; set; }

        public override TriggerViewModel Build(Trigger entity)
        {
            this.Channel = ChannelViewModel.NewInstance(entity.Channel);

            return this;
        }
    }
}

using Shengtai;
using SymmetricDS.Admin.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SymmetricDS.Admin.WebApplication.Models
{
    public class TriggerRouterViewModel : ViewModel<string, TriggerRouterViewModel, TriggerRouter>
    {
        private string id;

        [Key]
        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(this.id))
                    this.id = this.Trigger.Id.Value.ToString("00000000000") + "_" + this.Router.Id.Value.ToString("00000000000");

                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        private ChannelViewModel channel;
        public ChannelViewModel Channel
        {
            get
            {
                if (this.channel == null)
                    this.channel = this.Trigger.Channel;

                return this.channel;
            }
            set
            {
                this.channel = value;
            }
        }
        public TriggerViewModel Trigger { get; set; }

        public RouterViewModel Router { get; set; }

        public override TriggerRouterViewModel Build(TriggerRouter entity)
        {
            this.Trigger = TriggerViewModel.NewInstance(entity.Trigger).Build(entity.Trigger);
            this.Channel = this.Trigger.Channel;
            this.Router = RouterViewModel.NewInstance(entity.Router).Build(entity.Router);

            return this;
        }
    }
}

using Shengtai;
using SymmetricDS.Admin.Server;
using System.ComponentModel.DataAnnotations;

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

        public RouterViewModel Router { get; set; }

        public ChannelViewModel Channel { get; set; }
        public TriggerViewModel Trigger { get; set; }

        protected override TriggerRouterViewModel Build(TriggerRouter entity, object args = null)
        {
            this.Router = RouterViewModel.NewInstance(entity.Router);

            this.Channel = ChannelViewModel.NewInstance(entity.Trigger.Channel);
            this.Trigger = TriggerViewModel.NewInstance(entity.Trigger);

            return this;
        }
    }
}
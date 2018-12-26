using Shengtai;
using SymmetricDS.Admin.Server;
using System.ComponentModel.DataAnnotations;

namespace SymmetricDS.Admin.WebApplication.Models
{
    public class TriggerViewModel : ViewModel<int, TriggerViewModel, Trigger>
    {
        [Key]
        public int? Id { get; set; }

        public ChannelViewModel Channel { get; set; }

        public string TriggerId { get; set; }

        public string SourceTableName { get; set; }

        protected override TriggerViewModel Build(Trigger entity, object args = null)
        {
            this.Channel = ChannelViewModel.NewInstance(entity.Channel);

            return this;
        }
    }
}
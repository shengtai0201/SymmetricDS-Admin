using Shengtai;
using SymmetricDS.Admin.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricDS.Admin.WebApplication.Models
{
    public class ChannelViewModel : ViewModel<int, ChannelViewModel, Channel>
    {
        public int? Id { get; set; }

        public string ChannelId { get; set; }

        public string Description { get; set; }
    }
}

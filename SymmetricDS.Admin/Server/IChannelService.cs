using SymmetricDS.Admin.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricDS.Admin.Server
{
    public interface IChannelService
    {
        ICollection<ChannelViewModel> Read();
    }
}

using SymmetricDS.Admin.WebApplication.Models;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Server
{
    public interface IChannelService
    {
        ICollection<ChannelViewModel> Read();
    }
}
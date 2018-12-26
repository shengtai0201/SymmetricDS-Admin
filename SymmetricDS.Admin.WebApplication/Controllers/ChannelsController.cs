using Microsoft.AspNetCore.Mvc;
using Shengtai.Web.Telerik.Mvc;
using SymmetricDS.Admin.Server;
using SymmetricDS.Admin.WebApplication.Models;
using System.Security.Principal;

namespace SymmetricDS.Admin.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelsController : ApiController<int, ChannelViewModel, Channel>
    {
        public ChannelsController(IApiService<int, ChannelViewModel, Channel, IPrincipal> service) : base(service)
        {
        }
    }
}
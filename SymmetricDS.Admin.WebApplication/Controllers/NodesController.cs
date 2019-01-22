using Microsoft.AspNetCore.Mvc;
using Shengtai.Web.Telerik;
using Shengtai.Web.Telerik.Mvc;
using SymmetricDS.Admin.Server;
using SymmetricDS.Admin.WebApplication.Models;
using System.Security.Principal;

namespace SymmetricDS.Admin.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ApiController<int, NodeViewModel, Node>
    {
        public NodesController(IApiService<int, NodeViewModel, Node, IPrincipal> service) : base(service)
        {
        }
    }
}
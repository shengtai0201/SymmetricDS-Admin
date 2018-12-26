using Microsoft.AspNetCore.Mvc;
using Shengtai.Web.Telerik.Mvc;
using SymmetricDS.Admin.Server;
using SymmetricDS.Admin.WebApplication.Models;
using System.Security.Principal;

namespace SymmetricDS.Admin.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeGroupsController : ApiController<int, NodeGroupViewModel, NodeGroup>
    {
        public NodeGroupsController(IApiService<int, NodeGroupViewModel, NodeGroup, IPrincipal> service) : base(service)
        {
        }
    }
}
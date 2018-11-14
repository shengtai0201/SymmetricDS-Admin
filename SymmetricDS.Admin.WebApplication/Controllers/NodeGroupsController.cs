using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shengtai.Web.Telerik.Mvc;
using SymmetricDS.Admin.Server;
using SymmetricDS.Admin.WebApplication.Models;

namespace SymmetricDS.Admin.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeGroupsController : ApiController<int, NodeGroupViewModel, NodeGroup>
    {
        public NodeGroupsController(IApiService<int, NodeGroupViewModel, NodeGroup> service) : base(service) { }
    }
}
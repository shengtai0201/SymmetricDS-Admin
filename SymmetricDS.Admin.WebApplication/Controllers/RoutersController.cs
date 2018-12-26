using Microsoft.AspNetCore.Mvc;
using Shengtai.Web.Telerik.Mvc;
using SymmetricDS.Admin.Server;
using SymmetricDS.Admin.WebApplication.Models;
using System.Security.Principal;

namespace SymmetricDS.Admin.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutersController : ApiController<int, RouterViewModel, Router>
    {
        public RoutersController(IApiService<int, RouterViewModel, Router, IPrincipal> service) : base(service)
        {
        }
    }
}
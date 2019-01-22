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
    public class ProjectsController : ApiController<int, ProjectViewModel, Project>
    {
        public ProjectsController(IApiService<int, ProjectViewModel, Project, IPrincipal> service) : base(service)
        {
        }
    }
}
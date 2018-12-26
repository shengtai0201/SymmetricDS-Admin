using Microsoft.AspNetCore.Mvc;
using Shengtai;
using Shengtai.Web.Telerik.Mvc;
using SymmetricDS.Admin.Server;
using SymmetricDS.Admin.WebApplication.Models;
using System.Diagnostics;

namespace SymmetricDS.Admin.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectService projectService;
        private readonly INodeGroupService nodeGroupService;
        private readonly INodeService nodeService;
        private readonly IChannelService channelService;
        private readonly ITriggerService triggerService;

        public HomeController(IProjectService projectService, INodeGroupService nodeGroupService, INodeService nodeService,
            IChannelService channelService, ITriggerService triggerService)
        {
            this.projectService = projectService;
            this.nodeGroupService = nodeGroupService;
            this.nodeService = nodeService;
            this.channelService = channelService;
            this.triggerService = triggerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Project x GroupNode x Node

        [HttpPost]
        public IActionResult ReadDatabaseTypes()
        {
            var data = Extensions.GetEnumDictionary<Databases>();
            return Json(data);
        }

        [HttpGet]
        public IActionResult ProjectGroupNodes()
        {
            return View();
        }

        #endregion Project x GroupNode x Node

        #region Channel x Trigger

        [HttpGet]
        public IActionResult ChannelTriggers()
        {
            return View();
        }

        #endregion Channel x Trigger

        #region Router, Trigger

        [HttpPost]
        public IActionResult ReadChannels()
        {
            var data = this.channelService.Read();
            return Json(data);
        }

        [HttpPost]
        public IActionResult ReadTriggers([ModelBinder] DataSourceRequest request)
        {
            var data = this.triggerService.Read(request.ServerFiltering);
            return Json(data);
        }

        [HttpPost]
        public IActionResult ReadProjects()
        {
            var data = this.projectService.Read();
            return Json(data);
        }

        [HttpPost]
        public IActionResult ReadNodeGroups([ModelBinder] DataSourceRequest request)
        {
            var data = this.nodeGroupService.Read(request.ServerFiltering);
            return Json(data);
        }

        [HttpPost]
        public IActionResult ReadNodes([ModelBinder] DataSourceRequest request)
        {
            var data = this.nodeService.Read(request.ServerFiltering);
            return Json(data);
        }

        [HttpGet]
        public IActionResult Routers()
        {
            return View();
        }

        #endregion Router, Trigger
    }
}
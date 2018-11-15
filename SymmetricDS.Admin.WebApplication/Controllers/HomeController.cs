using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shengtai;
using Shengtai.Web.Telerik.Mvc;
using SymmetricDS.Admin.Server;
using SymmetricDS.Admin.WebApplication.Models;

namespace SymmetricDS.Admin.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectService projectService;
        private readonly INodeGroupService nodeGroupService;
        private readonly IChannelService channelService;
        private readonly ITriggerService triggerService;

        public HomeController(IProjectService projectService, INodeGroupService nodeGroupService, IChannelService channelService, ITriggerService triggerService)
        {
            this.projectService = projectService;
            this.nodeGroupService = nodeGroupService;
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
            var data = DefaultExtensions.GetEnumDictionary<Databases>();
            return Json(data);
        }

        [HttpGet]
        public IActionResult ProjectGroupNodes()
        {
            return View();
        }
        #endregion

        #region Channel x Trigger
        [HttpGet]
        public IActionResult ChannelTriggers()
        {
            return View();
        }
        #endregion

        #region Router x Trigger
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

        [HttpGet]
        public IActionResult Routers()
        {
            return View();
        }
        #endregion
    }
}

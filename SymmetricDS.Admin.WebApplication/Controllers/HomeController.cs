using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shengtai;
using SymmetricDS.Admin.WebApplication.Models;

namespace SymmetricDS.Admin.WebApplication.Controllers
{
    public class HomeController : Controller
    {
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
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using Shengtai.Web.Telerik.Mvc;
using SymmetricDS.Admin.Server;
using SymmetricDS.Admin.WebApplication.Models;
using System.Security.Principal;

namespace SymmetricDS.Admin.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriggerRoutersController : ApiController<string, TriggerRouterViewModel, TriggerRouter>
    {
        public TriggerRoutersController(IApiService<string, TriggerRouterViewModel, TriggerRouter, IPrincipal> service) : base(service)
        {
        }
    }
}
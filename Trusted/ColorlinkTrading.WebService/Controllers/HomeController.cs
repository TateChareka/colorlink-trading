using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trusted.GENIE.Models;
using Trusted.GENIE.Logic;

namespace Trusted.GENIE.WebService.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("Index")]
        public ActionResult Index()
        { 
            return View();
        }
    }
}
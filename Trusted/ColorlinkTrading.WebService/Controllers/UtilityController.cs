using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trusted.GENIE.Models;
using Trusted.GENIE.Logic;
using Trusted.GENIE.WebService.ActionFilters;

namespace Trusted.GENIE.WebService.Controllers
{
    [RoutePrefix("UtilityService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class UtilityServiceController : Controller
    {
        [Route("GetPeriodDates")]
        [HttpPost]
        public JsonResult GetPeriodDates(PeriodDatesRequestModel request)
        {
            return Json(GeneralLogic.GetPeriodDates(request), JsonRequestBehavior.DenyGet);
        }
    }
}
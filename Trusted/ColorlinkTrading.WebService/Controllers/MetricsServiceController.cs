using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trusted.GENIE.Logic;
using Trusted.GENIE.Models;
using Trusted.GENIE.WebService.ActionFilters;

namespace Trusted.GENIE.WebService.Controllers
{
    [RoutePrefix("MetricsService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class MetricsServiceController : Controller
    {
        [Route("Members")]
        [HttpPost]
        public JsonResult GetMemberMetrics(GenericRequestModel request)
        {
            return Json(MetricsLogic.GetMemberMetrics(request), JsonRequestBehavior.DenyGet);
        }

        [Route("Communications")]
        [HttpPost]
        public JsonResult GetCommunicationMetrics(GenericRequestModel request)
        {
            return Json(MetricsLogic.GetCommunicationMetrics(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetMemberMetricMonths")]
        [HttpPost]
        public JsonResult GetMemberMetricMonths(GenericItemRequestModel request)
        {
            return Json(MetricsLogic.GetMemberMetricMonths(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetMembersMetrics")]
        [HttpPost]
        public JsonResult GetMembersMetrics(GenericSearchRequestModel request)
        {
            return Json(MetricsLogic.GetMembersMetrics(request), JsonRequestBehavior.DenyGet);
        }



    }
}
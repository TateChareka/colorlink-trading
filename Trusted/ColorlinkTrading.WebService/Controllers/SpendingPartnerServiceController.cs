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
    [RoutePrefix("SpendingPartnerService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class SpendingPartnerServiceController : Controller
    {
        
        [Route("DeleteSpendingPartner")]
        [HttpPost]
        public JsonResult DeleteSpendingPartner(GenericItemRequestModel request)
        {
            return Json(SpendingPartnerLogic.DeleteSpendingPartner(request), JsonRequestBehavior.DenyGet);
        }        

        [Route("SpendingPartnerSearch")]
        [HttpPost]
        public JsonResult SpendingPartnerListSearch(GenericSearchRequestModel request)
        {
            return Json(SpendingPartnerLogic.SearchSpendingPartnerList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetSpendingPartneritem")]
        [HttpPost]
        public JsonResult GetSpendingPartneritem(GenericItemRequestModel request)
        {
            return Json(SpendingPartnerLogic.GetSpendingPartneritem(request), JsonRequestBehavior.DenyGet);
        }

        [Route("WriteSpendingPartner")]
        [HttpPost]
        public JsonResult WriteSpendingPartner(SpendingPartnerRequestModel request)
        {
            return Json(SpendingPartnerLogic.WriteSpendingPartner(request), JsonRequestBehavior.DenyGet);
        }

    }
}
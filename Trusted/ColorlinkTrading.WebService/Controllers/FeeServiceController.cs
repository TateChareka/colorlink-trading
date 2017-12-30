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
    [RoutePrefix("FeeService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class FeeServiceController : Controller
    {

        [Route("ProcessAccountFees")]
        [HttpPost]
        public JsonResult ProcessAccountFees(GenericSearchRequestModel request)
        {
            return Json(AccounFeesLogic.SearchAccounFees(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetAccountFeesItem")]
        [HttpPost]
        public JsonResult GetAccountFeesItem(GenericItemRequestModel request)
        {
            return Json(AccounFeesLogic.GetAccounFeeItem(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetAccountFeeMonths")]
        [HttpPost]
        public JsonResult GetAccountFeeMonths(GenericItemRequestModel request)
        {
            return Json(AccounFeesLogic.GetAccountFeeMonths(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetAccountFeeModels")]
        [HttpPost]
        public JsonResult GetAccountFeeModels(GenericItemRequestModel request)
        {
            return Json(AccounFeesLogic.GetAccountFeeModels(request), JsonRequestBehavior.DenyGet);
        }

        [Route("WriteAccountFee")]
        [HttpPost]
        public JsonResult WriteAccountFee(AccounFeesItemRequestModel request)
        {
            return Json(AccounFeesLogic.WriteAccountFee(request), JsonRequestBehavior.DenyGet);
        }

        [Route("DeleteAccountFee")]
        [HttpPost]
        public JsonResult DeleteAccountFee(GenericItemRequestModel request)
        {
            return Json(AccounFeesLogic.DeleteAccountFee(request), JsonRequestBehavior.DenyGet);
        }

    }
}
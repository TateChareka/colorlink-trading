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
    [RoutePrefix("TransactionService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class TransactionServiceController : Controller
    {
        [Route("GetVendors")]
        [HttpPost]
        public JsonResult GetVendors(GenericRequestModel request)
        {
            return Json(TransactionsLogic.GetVendors(request), JsonRequestBehavior.DenyGet);
        }

        [Route("WriteVendorUpload")]
        [HttpPost]
        public JsonResult WriteVendorUpload(SpendingToolRequestModel request)
        {
            return Json(TransactionsLogic.WriteVendorUpload(request), JsonRequestBehavior.DenyGet);
        }

        [Route("ProcessSpendingTooltransactions")]
        [HttpPost]
        public JsonResult ProcessSpendingTooltransactions(SpendingToolRequestModel request)
        {
            return Json(TransactionsLogic.ProcessSpendingTooltransactions(request), JsonRequestBehavior.DenyGet);
        }

    }
}
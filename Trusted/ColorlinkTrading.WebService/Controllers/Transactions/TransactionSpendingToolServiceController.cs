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
    [RoutePrefix("TransactionsSpendingToolService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class TransactionSpendingToolServiceController : Controller
    {
        [Route("SpendingToolSummaryList")]
        [HttpPost]
        public JsonResult SpendingToolSummary(SpendingToolSummaryRequestModel request)
        {
            return Json(SpendingToolLogic.SpendingToolSummaryList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("SpendingToolSummaryExport")]
        [HttpPost]
        public JsonResult SpendingToolSummaryExport(SpendingToolSummaryRequestModel request)
        {
            return Json(SpendingToolLogic.ExportSpendingToolSummaryList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("SpendingVendorMonths")]
        [HttpPost]
        public JsonResult VendorMonths(GenericRequestModel request)
        {
            return Json(SpendingToolLogic.GetSpendingToolMonths(request), JsonRequestBehavior.DenyGet);
        }

        [Route("SpendingVendors")]
        [HttpPost]
        public JsonResult Vendors(GenericRequestModel request)
        {
            return Json(SpendingToolLogic.GetSpendingToolVendors(request), JsonRequestBehavior.DenyGet);
        }

        [Route("SpendingToolTransactionsList")]
        [HttpPost]
        public JsonResult SpendingToolTransactionsList(SpendingToolTransactionsRequestModel request)
        {
            return Json(SpendingToolLogic.SpendingToolTransactionsList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("SpendingToolTransactionsExport")]
        [HttpPost]
        public JsonResult SpendingToolTransactionsExport(SpendingToolTransactionsRequestModel request)
        {
            return Json(SpendingToolLogic.ExportSpendingToolTransactionsList(request), JsonRequestBehavior.DenyGet);
        }

    }
}
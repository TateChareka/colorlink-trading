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
    [RoutePrefix("MonthlyTransactionsService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class TransactionMonthlyTransactionsServiceController : Controller
    {
        [Route("MonthlyTransactionSummaryList")]
        [HttpPost]
        public JsonResult MonthlyTransactionSummary(MonthlyTransactionSummaryRequestModel request)
        {
            return Json(MonthlyTransactionsLogic.MonthlyTransactionSummaryList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("MonthlyTransactionSummaryExport")]
        [HttpPost]
        public JsonResult MonthlyTransactionSummaryExport(MonthlyTransactionSummaryRequestModel request)
        {
            return Json(MonthlyTransactionsLogic.ExportMonthlyTransactionSummaryList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("MonthlyTransactionSummaryMonths")]
        [HttpPost]
        public JsonResult MonthlyTransactionSummaryMonths(GenericRequestModel request)
        {
            return Json(MonthlyTransactionsLogic.GetMonthlyTransactionSummaryMonths(request), JsonRequestBehavior.DenyGet);
        }

    }
}
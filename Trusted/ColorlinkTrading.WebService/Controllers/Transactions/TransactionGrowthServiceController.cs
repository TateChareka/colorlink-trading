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
    [RoutePrefix("TransactionGrowthService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class TransactionGrowthServiceController : Controller
    {
        [Route("GrowthTransactionsMonths")]
        [HttpPost]
        public JsonResult GrowthTransactionsMonths(GenericRequestModel request)
        {
            return Json(GrowthTransactionsLogic.GetGrowthTransactionsMonths(request), JsonRequestBehavior.DenyGet);
        }

        [Route("AccountGrowthTransactionsList")]
        [HttpPost]
        public JsonResult AccountFeesTransactions(AccountGrowthTransactionsRequestModel request)
        {
            return Json(GrowthTransactionsLogic.AccountGrowthTransactionsList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("AccountGrowthTransactionsExport")]
        [HttpPost]
        public JsonResult AccountFeesTransactionsExport(AccountGrowthTransactionsRequestModel request)
        {
            return Json(GrowthTransactionsLogic.ExportAccountGrowthTransactionsList(request), JsonRequestBehavior.DenyGet);
        }

    }
}
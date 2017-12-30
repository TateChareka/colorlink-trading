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
    [RoutePrefix("TransactionAccountFeesService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class TransactionAccountFeesServiceController : Controller
    {
        [Route("AccountSummaryBrandNames")]
        [HttpPost]
        public JsonResult AccountSummaryBrandNames(GenericRequestModel request)
        {
            return Json(AccountFeesLogic.AccountSummaryBrandNames(request), JsonRequestBehavior.DenyGet);
        }

        [Route("AccountBrandNamesMonths")]
        [HttpPost]
        public JsonResult BrandNamesMonths(GenericRequestModel request)
        {
            return Json(AccountFeesLogic.GetAccountSummaryMonths(request), JsonRequestBehavior.DenyGet);
        }

        [Route("AccountFeesSummaryList")]
        [HttpPost]
        public JsonResult AccountFeesSummary(AccountFeesSummaryRequestModel request)
        {
            return Json(AccountFeesLogic.AccountFeesSummaryList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("AccountFeesSummaryExport")]
        [HttpPost]
        public JsonResult AccountFeesSummaryExport(AccountFeesSummaryRequestModel request)
        {
            return Json(AccountFeesLogic.ExportAccountFeesSummaryList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("FeesTransactionsMonths")]
        [HttpPost]
        public JsonResult FeesTransactionsMonths(GenericRequestModel request)
        {
            return Json(AccountFeesLogic.GetFeesTransactionsMonths(request), JsonRequestBehavior.DenyGet);
        }

        [Route("AccountFeeTypes")]
        [HttpPost]
        public JsonResult AccountFeeTypes(GenericRequestModel request)
        {
            return Json(AccountFeesLogic.GetFeesTypes(request), JsonRequestBehavior.DenyGet);
        }

        [Route("AccountFeesTransactionsList")]
        [HttpPost]
        public JsonResult AccountFeesTransactions(AccountFeesTransactionsRequestModel request)
        {
            return Json(AccountFeesLogic.AccountFeesTransactionsList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("AccountFeesTransactionsExport")]
        [HttpPost]
        public JsonResult AccountFeesTransactionsExport(AccountFeesTransactionsRequestModel request)
        {
            return Json(AccountFeesLogic.ExportAccountFeesTransactionsList(request), JsonRequestBehavior.DenyGet);
        }

    }
}
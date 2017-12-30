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
    [RoutePrefix("TransactionGenerosityToolService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class TransactionGenerosityToolServiceController : Controller
    {
        [Route("GenerosityToolTransactionsList")]
        [HttpPost]
        public JsonResult GenerosityToolTransactionsList(GenerosityToolTransactionsRequestModel request)
        {
            return Json(GenerosityToolLogic.GenerosityToolTransactionsList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GenerosityToolTransactionsExport")]
        [HttpPost]
        public JsonResult GenerosityToolTransactionsExport(GenerosityToolTransactionsRequestModel request)
        {
            return Json(GenerosityToolLogic.ExportGenerosityToolTransactionsList(request), JsonRequestBehavior.DenyGet);
        }

    }
}
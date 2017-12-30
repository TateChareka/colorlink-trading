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
    [RoutePrefix("TransactionsValueToolService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class TransactionValueToolServiceController : Controller
    {       
        [Route("ValueToolTransactionsList")]
        [HttpPost]
        public JsonResult ValueToolTransactionsList(ValueToolTransactionsRequestModel request)
        {
            return Json(ValueToolLogic.ValueToolTransactionsList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("ValueToolTransactionsExport")]
        [HttpPost]
        public JsonResult ValueToolTransactionsExport(ValueToolTransactionsRequestModel request)
        {
            return Json(ValueToolLogic.ExportValueToolTransactionsList(request), JsonRequestBehavior.DenyGet);
        }

    }
}
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
    [RoutePrefix("TransactionAcceleratorToolService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class TransactionAcceleratorToolServiceController : Controller
    {
        [Route("AcceleratorToolTransactionsList")]
        [HttpPost]
        public JsonResult AcceleratorToolTransactionsList(AcceleratorToolTransactionsRequestModel request)
        {
            return Json(AcceleratorToolLogic.AcceleratorToolTransactionsList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("AcceleratorToolTransactionsExport")]
        [HttpPost]
        public JsonResult AcceleratorToolTransactionsExport(AcceleratorToolTransactionsRequestModel request)
        {
            return Json(AcceleratorToolLogic.ExportAcceleratorToolTransactionsList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("PrepareAcceleratorTool")]
        [HttpPost]
        public JsonResult PrepareAcceleratorTool(AcceleratorToolRequestModel request)
        {
            return Json(AcceleratorToolLogic.PrepareAcceleratorTool(request), JsonRequestBehavior.DenyGet);
        }

        [Route("ProcessAcceleratorTool")]
        [HttpPost]
        public JsonResult ProcessAcceleratorTool(AcceleratorToolRequestModel request)
        {
            return Json(AcceleratorToolLogic.ProcessAcceleratorTool(request), JsonRequestBehavior.DenyGet);
        }

    }
}
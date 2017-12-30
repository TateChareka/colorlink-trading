using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trusted.GENIE.Logic;
using Trusted.GENIE.Models;
using SofticeMailFetcher;
using Trusted.GENIE.WebService.ActionFilters;
using System.IO;

namespace Trusted.GENIE.WebService.Controllers
{
    [RoutePrefix("CommunicationsMessageLogService")]
    public class CommunicationsMessageLogServiceController : Controller
    {
        [Route("CommunicationMessageLogsSearch")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult CommunicationMessageLogsSearch(CommMessagesLogRequestModel request)
        {
            return Json(MessageLogLogic.SearchCommunicationMessageLogs(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetCommMessageLogsBrandName")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult GetCommMessageLogsBrandName(GenericRequestModel request)
        {
            return Json(MessageLogLogic.GetCommMessageLogsBrandName(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetCommMessageLogsMessageType")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult GetCommMessageLogsMessageType(GenericRequestModel request)
        {
            return Json(MessageLogLogic.GetCommMessageLogsMessageType(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetMessageContent")]
        [HttpGet]
        public string GetMessageContent(string identifier)
        {
            return MessageLogLogic.GetMessageContent(identifier);
        }
    }
}
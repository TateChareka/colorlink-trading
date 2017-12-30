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
    [RoutePrefix("CommunicationsService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class CommunicationsServiceController : Controller
    {
        

        [Route("GetEmails")]
        [HttpPost]
        public JsonResult GetEmails(GenericItemRequestModel request)
        {
            return Json(CommunicationsLogic.GetEmails(request), JsonRequestBehavior.DenyGet);
        }

        [Route("DeleteEmail")]
        [HttpPost]
        public JsonResult DeleteEmail(GenericItemRequestModel request)
        {
            return Json(CommunicationsLogic.DeleteEmail(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetHTMLBody")]
        [HttpPost]
        public JsonResult GetHTMLBody(GenericItemRequestModel request)
        {
            return Json(CommunicationsLogic.GetHTMLBodyAndReplaceImages(request), JsonRequestBehavior.DenyGet);
        }


        [Route("GetMessageTypes")]
        [HttpPost]
        public JsonResult GetMessageTypes(GenericItemRequestModel request)
        {
            return Json(CommunicationsLogic.GetMessageTypes(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetStatementDates")]
        [HttpPost]
        public JsonResult GetStatementDates(StatementDateRequestModel request)
        {
            return Json(CommunicationsLogic.GetStatementDates(request), JsonRequestBehavior.DenyGet);
        }
        
    }
}
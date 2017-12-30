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
    [RoutePrefix("CommunicationsMessageService")]
    public class CommunicationsMessageServiceController : Controller
    {
        [Route("CommunicationsMessageSearch")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult CommunicationsMessageSearch(GenericSearchRequestModel request)
        {
            return Json(CommunicationMessageLogic.SearchCommunicationMessages(request), JsonRequestBehavior.DenyGet);
        }

        [Route("CommunicationsFilterDataCount")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult CommunicationsFilterDataCount(GenericFilterDataRequestModel request)
        {
            return Json(CommunicationMessageLogic.CommunicationsFilterDataCount(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetCommunicationMessageItem")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult GetCommunicationMessageItem(GenericItemRequestModel request)
        {
            return Json(CommunicationMessageLogic.GetCommunicationMessageItem(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetImapEmailLinks")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult GetImapEmailLinks(GenericItemRequestModel request)
        {
            return Json(CommunicationMessageLogic.GetImapEmailLinks(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetTemplateEmailLinks")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult GetTemplateEmailLinks(GenericItemRequestModel request)
        {
            return Json(CommunicationMessageLogic.GetTemplateEmailLinks(request), JsonRequestBehavior.DenyGet);
        }

        [Route("Write")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult WriteCommunicationsMessage(CommunicationMessageItemRequestModel request)
        {
            return Json(CommunicationMessageLogic.SaveCommunicationMessage(request), JsonRequestBehavior.DenyGet);
        }

        [Route("SendTest")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult SendCommunicationMessageTest(CommunicationMessageRequestModel request)
        {
            return Json(CommunicationMessageLogic.SendCommunicationMessageTest(request), JsonRequestBehavior.DenyGet);
        }

        [Route("MultiSendTest")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult MultiSendCommunicationMessageTest(CommunicationMessageTestRequestModel request)
        {
            return Json(CommunicationMessageLogic.MultiSendCommunicationMessageTest(request), JsonRequestBehavior.DenyGet);
        }

        [Route("QueueMessage")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult QueueCommunicationMessage(CommunicationMessageRequestModel request)
        {
            return Json(CommunicationMessageLogic.QueueCommunicationMessage(request), JsonRequestBehavior.DenyGet);
        }

        [Route("RemoveMessage")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult RemoveCommunicationMessage(CommunicationMessageRequestModel request)
        {
            return Json(CommunicationMessageLogic.RemoveCommunicationMessage(request), JsonRequestBehavior.DenyGet);
        }

        [Route("CopyAndEdit")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult CopyAndEditCommunicationMessage(CommunicationMessageRequestModel request)
        {
            return Json(CommunicationMessageLogic.CopyAndEditCommunicationMessage(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetEmailHTML")]
        [HttpGet]
        [TraceFilter]
        public string GetEmailHTML(string type, int identifier)
        {
            return CommunicationMessageLogic.GetMessageHTML(type, identifier);
        }

    }
}
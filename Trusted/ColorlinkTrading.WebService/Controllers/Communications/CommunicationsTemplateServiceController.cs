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
    [RoutePrefix("CommunicationsTemplateService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class CommunicationsTemplateServiceController : Controller
    {
        [Route("WriteCommunicationTemplate")]
        [HttpPost]
        public JsonResult WriteCommunicationTemplate(CommTemplateRequestModel request)
        {
            return Json(CommunicationsTemplateLogic.WriteCommunicationTemplate(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetCommunicationTemplateBrandName")]
        [HttpPost]
        public JsonResult GetCommunicationTemplateBrandName(GenericRequestModel request)
        {
            return Json(CommunicationsTemplateLogic.GetCommunicationTemplateBrandName(request), JsonRequestBehavior.DenyGet);
        }

        [Route("DeleteCommunicationTemplate")]
        [HttpPost]
        public JsonResult DeleteCommunicationTemplate(GenericItemRequestModel request)
        {
            return Json(CommunicationsTemplateLogic.DeleteCommunicationTemplate(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetCommunicationTemplateItem")]
        [HttpPost]
        public JsonResult GetCommunicationTemplateItem(GenericItemRequestModel request)
        {
            return Json(CommunicationsTemplateLogic.GetCommunicationTemplateItem(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetCommunicationTemplates")]
        [HttpPost]
        public JsonResult GetCommunicationTemplates(GenericItemRequestModel request)
        {
            return Json(CommunicationsTemplateLogic.GetCommunicationTemplates(request), JsonRequestBehavior.DenyGet);
        }

        [Route("CommunicationsTemplateSearch")]
        [HttpPost]
        public JsonResult CommunicationsTemplateSearch(CommTemplateRequestModel request)
        {
            return Json(CommunicationsTemplateLogic.SearchCommunicationTemplate(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetCommunicationTypes")]
        [HttpPost]
        public JsonResult GetCommunicationTypes(CommTypeRequestModel request)
        {
            return Json(CommunicationsTemplateLogic.GetCommunicationTypes(request), JsonRequestBehavior.DenyGet);
        }


    }
}
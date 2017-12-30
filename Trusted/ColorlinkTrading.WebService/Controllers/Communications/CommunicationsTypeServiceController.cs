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
    [RoutePrefix("CommunicationsTypeService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class CommunicationsTypeServiceController : Controller
    {
        [Route("CommunicationsTypesSearch")]
        [HttpPost]
        public JsonResult CommunicationsTypesSearch(CommTypeRequestModel request)
        {
            return Json(CommunicationsTypeLogic.SearchCommunicationTypes(request), JsonRequestBehavior.DenyGet);
        }

        [Route("CommunicationTypeDelete")]
        [HttpPost]
        public JsonResult CommunicationTypeDelete(GenericItemRequestModel request)
        {
            return Json(CommunicationsTypeLogic.DeleteCommunicationType(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetCommunicationTypeItem")]
        [HttpPost]
        public JsonResult GetCommunicationTypeItem(GenericItemRequestModel request)
        {
            return Json(CommunicationsTypeLogic.GetCommunicationTypeItem(request), JsonRequestBehavior.DenyGet);
        }

        [Route("WriteCommunicationType")]
        [HttpPost]
        public JsonResult WriteCommunicationType(CommTypeRequestModel request)
        {
            return Json(CommunicationsTypeLogic.WriteCommunicationType(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetCommunicationTypesBrandName")]
        [HttpPost]
        public JsonResult GetCommunicationTypesBrandName(GenericRequestModel request)
        {
            return Json(CommunicationsTypeLogic.GetCommunicationTypesBrandName(request), JsonRequestBehavior.DenyGet);
        }

    }
}
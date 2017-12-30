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
    [RoutePrefix("EducationalInstitutionService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class EducationalInstitutionServiceController : Controller
    {
        [Route("SearchEducationalInstitutions")]
        [HttpPost]
        public JsonResult SearchEducationalInstitutions(GenericSearchRequestModel request)
        {
            return Json(EducationalInstitutionsLogic.SearchEducationalInstitutionsList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("WriteEducationalInstitution")]
        [HttpPost]
        public JsonResult WriteEducationalInstitution(EducationalInstitutionsItemRequestModel request)
        {
            return Json(EducationalInstitutionsLogic.WriteEducationalInstitution(request), JsonRequestBehavior.DenyGet);
        }

        [Route("DeleteEducationalInstitution")]
        [HttpPost]
        public JsonResult DeleteEducationalInstitution(GenericItemRequestModel request)
        {
            return Json(EducationalInstitutionsLogic.DeleteEducationalInstitution(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetEducationalInstitutionItem")]
        [HttpPost]
        public JsonResult GetEducationalInstitutionItem(GenericItemRequestModel request)
        {
            return Json(EducationalInstitutionsLogic.GetEducationalInstitutionItem(request), JsonRequestBehavior.DenyGet);
        }



    }
}
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
    [RoutePrefix("SystemUserService")]
    public class SystemUserServiceController : Controller
    {
        [Route("SignIn")]
        [HttpPost]
        [TraceFilter]
        public JsonResult SignAdminUserIn(MemberAuthenticationRequestModel request)
        {
            return Json(SystemUserLogic.SignUserIn(request), JsonRequestBehavior.DenyGet);
        }

        [Route("SetPassword")]
        [HttpPost]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult SetAdminUserPassword(MemberUserPasswordResetModel request)
        {
            return Json(SystemUserLogic.SetAdminUserPassword(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetUserGUID")]
        [HttpPost]
        [TraceFilter]
        public JsonResult GetUserGUID(MemberGUIDRequestModel request)
        {
            return Json(SystemUserLogic.GetUserGUID(request), JsonRequestBehavior.DenyGet);
        }

    }
}
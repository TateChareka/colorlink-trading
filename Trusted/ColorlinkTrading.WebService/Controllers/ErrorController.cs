using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trusted.GENIE.Models;

namespace Trusted.GENIE.WebService.Controllers
{
    public class ErrorController : Controller
    {
        public JsonResult Index()
        {
            string error = "Unknown Error.";
            if (Session["SystemError"] != null)
            {
                error = Session["SystemError"].ToString();
                Session["SystemError"] = null;
            }
            GenericResultModel result = new GenericResultModel() { HasError = true, IsValidationError = false, Feedback = error };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
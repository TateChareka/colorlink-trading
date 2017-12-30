using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Globalization;
using System.Text;
using Trusted.GENIE.Logic;
using Trusted.GENIE.Models;
using System.Web.Script.Serialization;

namespace Trusted.GENIE.WebService.ActionFilters
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class TraceFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                string IPAddress = filterContext.HttpContext.Request.UserHostAddress;
                string userAgent = filterContext.HttpContext.Request.UserAgent;
                string url = filterContext.HttpContext.Request.Url.AbsoluteUri;
                string queryString = filterContext.HttpContext.Request.QueryString.ToString();
                string httpMethod = filterContext.HttpContext.Request.HttpMethod;
                int totalBytes = filterContext.HttpContext.Request.TotalBytes;
                string parameter = new JavaScriptSerializer().Serialize(filterContext.ActionParameters).ToString();
                string userName = "";
                string userGUID = "";

                var prmList = filterContext.ActionParameters;
                foreach (var prm in prmList)
                {
                    var prmObj = prm.Value as GenericRequestModel;
                    if (prmObj != null)
                    {
                        userName = prmObj.SessionUserName;
                        userGUID = prmObj.SessionUserGUID;
                    }
                }
                GeneralLogic.WriteRequestLog(IPAddress, userAgent, url, queryString, totalBytes, httpMethod, parameter, userName, userGUID);
            }
            catch { }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using Trusted.GENIE.Models;
using Trusted.GENIE.Logic;

namespace Trusted.GENIE.WebService.ActionFilters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string headerIndex = "lpcUref";
            string environmentIndex = "SignInEnvironment";

            bool isAjax = true;
             
            if (!isAjax)
            {
               
            }
            else
            {
                string headerData = "";
                string userEnvironment = "";
                string urlBit = "";
                string feedBackMessage = "Invalid User Access.";
                bool isValid = true;
                try
                {
                    //urlBit = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Split('/').Last();
                    urlBit = (filterContext.RouteData.Route as System.Web.Routing.Route).Url;
                    if (HttpContext.Current.Request.Headers[headerIndex] != null)
                    {
                        headerData = HttpContext.Current.Request.Headers[headerIndex].ToString();
                    }
                    if (headerData.Trim() == "")
                    {
                        isValid = false;
                        feedBackMessage = "Invalid User Access.";
                    }
                    if (HttpContext.Current.Request.Headers[environmentIndex] != null)
                    {
                        userEnvironment = HttpContext.Current.Request.Headers[environmentIndex].ToString();
                    }
                    if (userEnvironment.Trim() == "")
                    {
                        isValid = false;
                        feedBackMessage = "Invalid User Environment.";
                    }
                    else
                    {
                        int userId = 0;
                        int personId = 0;
                        string userName = "";

                        userId = SystemUserLogic.GetUserIDFromHeaderToken(headerData);
                        personId = SystemUserLogic.GetPersonIdFromUserId(userId);
                        userName = SystemUserLogic.GetUserName(userId);

                        var prmList = filterContext.ActionParameters;
                        foreach (var prm in prmList)
                        {
                            var prmObj = prm.Value as GenericRequestModel;
                            if (prmObj != null)
                            {
                                prmObj.SessionUserName = userName;
                                prmObj.SessionUserId = userId;
                                prmObj.SessionPersonId = personId;
                                prmObj.SessionUserGUID = headerData;
                                prmObj.SessionUserEnvironment = userEnvironment;
                                prmObj.RootWebFolder = HttpContext.Current.Server.MapPath("~");

                                ////write the user device info
                                //AppUserLogic.WriteUserDevice(headerData, userName, prmObj.DeviceCordova, prmObj.DeviceModel, prmObj.DeviceUUID,
                                //    prmObj.DeviceVersion, prmObj.ApplicationVersion);
                            }
                        }
                        isValid = SystemUserLogic.UserHasAccessToLocation(userId, urlBit);
                    }
                }
                catch(Exception error)
                {
                    isValid = false;
                    feedBackMessage = error.Message;
                }

                if (!isValid)
                {
                    GenericResultModel result = new GenericResultModel() { HasError = true, Feedback = feedBackMessage, IsValidationError = false };
                    filterContext.Result = new JsonResult
                    {
                        Data = result , JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    base.OnActionExecuting(filterContext);
                } 
            }
        }
    }
}
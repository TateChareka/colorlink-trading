using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Trusted.GENIE.WebService
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (exception != null)
            {
                string errorMessage = exception.Message;
                Server.ClearError();
                Response.Clear();
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Session != null)
                    {
                        //Session["SystemError"] = errorMessage;
                        if (errorMessage != "Server cannot append header after HTTP headers have been sent.")
                        {
                            //Response.Redirect("~/Error");
                        }
                    }
                }
            }
        }

        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
            } 
        }
    }
}

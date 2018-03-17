using MSTest.OnlineTradingApp.Contract;
using MSTest.OnlineTradingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MSTest.OnlineTradingApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private ILoghandler _log = new LogHandler();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
        protected void Application_Error()
        {
            var error = Server.GetLastError();
            _log.LogError(error.Message);
        }

        protected void Application_EndRequest()
        {            
            switch (Context.Response.StatusCode)
            {
                case 500:
                    _log.LogError(Context.Response.StatusDescription);
                    Response.Clear();
                    Response.Redirect("~/Error");
                    break;
                case 404:
                    _log.LogError(Context.Response.StatusDescription);
                    Response.Clear();
                    Response.Redirect("~/Error");
                    break;
            }
        }
    }
}

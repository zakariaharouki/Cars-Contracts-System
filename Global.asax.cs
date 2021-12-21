using Cars_System.App_Start;
using System;
using System.Configuration;
using System.Web.Routing;

namespace Cars_System
{
    public class Global : System.Web.HttpApplication
    {
        public static string MyConn = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
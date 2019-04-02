using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ShopAroundWeb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
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

        protected void RegisterRoutes(RouteCollection routes)
        {
            /* Public Area */
            routes.MapPageRoute("Default", "", "~/Default.aspx");
            routes.MapPageRoute("Register", "Register", "~/Register.aspx");
            routes.MapPageRoute("Login", "Login", "~/Login.aspx");

            /* Private Area */
            routes.MapPageRoute("Dashboard", "Dashboard", "~/Dashboard.aspx");
            routes.MapPageRoute("Profile", "Profile", "~/Profile.aspx");
            routes.MapPageRoute("AddProduct", "AddProduct", "~/AddProduct.aspx");
        }
    }
}
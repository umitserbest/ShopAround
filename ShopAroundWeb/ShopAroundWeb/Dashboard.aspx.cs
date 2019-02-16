using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopAroundWeb
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.DoesExistUserCookie())
            {
                Response.Redirect("/Login");
            }
        }

        [WebMethod]
        public static string SignOut()
        {
            try
            {
                Utilities.RemoveCookie();
                return "true";
            }
            catch
            {
                return "false";
            }
        }
    }
}
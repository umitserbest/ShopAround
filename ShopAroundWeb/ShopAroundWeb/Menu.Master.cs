using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopAroundWeb
{
    public partial class Menu1 : System.Web.UI.MasterPage
    {
        public string userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpCookie UserCookies = HttpContext.Current.Request.Cookies["User"];
                userID = UserCookies["UserID"];
            }
            catch
            {
                userID = "";
            }
        }
    }
}
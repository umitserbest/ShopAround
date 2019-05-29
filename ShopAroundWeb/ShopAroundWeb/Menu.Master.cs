using ShopAroundWeb.Database;
using ShopAroundWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopAroundWeb
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        public string shopName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {                
                string shopID = HttpContext.Current.Request.Cookies["Shop"]["ShopID"];
                shopName = DatabaseForShop.GetShopInfo(shopID).Name;
            }
            catch
            {       
                
            }
        }

        protected void lbSignOut_Click(object sender, EventArgs e)
        {
            Utilities.RemoveCookie();

            Response.Redirect("/Login");
        }
    }
}
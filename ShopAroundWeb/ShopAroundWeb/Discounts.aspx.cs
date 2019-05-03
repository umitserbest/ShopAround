using ShopAroundWeb.Database;
using ShopAroundWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopAroundWeb
{
    public partial class Discounts : Page
    {
        public List<DiscountModel> discounts;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.DoesExistShopCookie())
            {
                Response.Redirect("/Login");
            }

            if (!IsPostBack)
            {
                string shopID = HttpContext.Current.Request.Cookies["Shop"]["ShopID"];
                discounts = DatabaseForShop.GetDiscounts(int.Parse(shopID));
            }           
        }
    }
}
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
    public partial class Products : Page
    {
        public List<ProductModel> products = new List<ProductModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.DoesExistShopCookie())
            {
                Response.Redirect("/Login");
            }

            if (!IsPostBack)
            {
                try
                {
                    string shopID = HttpContext.Current.Request.Cookies["Shop"]["ShopID"];
                    products = DatabaseForShop.GetProducts(int.Parse(shopID));
                }
                catch (Exception)
                {

                }
            }           
        }
    }
}
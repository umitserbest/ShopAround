using ShopAroundWeb.Database;
using ShopAroundWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopAroundWeb
{
    public partial class AddDiscount : System.Web.UI.Page
    {
        private static int shopID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.DoesExistShopCookie())
            {
                Response.Redirect("/Login");
            }

            if (!IsPostBack)
            {
                shopID = int.Parse(HttpContext.Current.Request.Cookies["Shop"]["ShopID"]);

                List<ProductModel> products = DatabaseForShop.GetProducts(shopID);

                foreach (ProductModel product in products)
                {
                    ddlProduct.Items.Add(new ListItem(product.Name, product.ProductID.ToString()));
                }
                
                pnlError.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DiscountModel discount = new DiscountModel();

                discount.ShopID = shopID;
                discount.ProductID = int.Parse(ddlProduct.SelectedValue);
                discount.Code = txtDiscountCode.Text;
                discount.Details = txtDetails.Text;

                DateTime dateTime = clndrExpiry.SelectedDate;
                dateTime = dateTime.AddHours(double.Parse(txtTime.Text));

                discount.Date = dateTime;

                DatabaseForShop.AddDiscount(discount);

                Response.Redirect("/Discounts");
            }
            catch (Exception)
            {
                pnlError.Visible = true;
            }
        }
    }
}
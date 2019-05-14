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
    public partial class EditDiscount : System.Web.UI.Page
    {
        private static int shopID;
        private static DiscountModel discount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.DoesExistShopCookie())
            {
                Response.Redirect("/Login");
            }

            int discountID = 0;

            try
            {
                discountID = int.Parse(Request.QueryString["DiscountID"]);
            }
            catch (Exception)
            {
                Response.Redirect("/Discounts");
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

                List<DiscountModel> discounts = DatabaseForShop.GetDiscounts(shopID);

                foreach (var item in discounts)
                {
                    if (item.DiscountID == discountID)
                    {
                        discount = item;
                    }
                }

                ddlProduct.SelectedValue = discount.ProductID.ToString();                
                txtDetails.Text = discount.Details;
                clndrExpiry.SelectedDate = discount.Date;
                txtTime.Text = discount.Date.Hour.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DiscountModel editedDiscount = discount;

                editedDiscount.ShopID = shopID;
                editedDiscount.ProductID = int.Parse(ddlProduct.SelectedValue);
                editedDiscount.Details = txtDetails.Text;

                DateTime dateTime = clndrExpiry.SelectedDate;
                dateTime = dateTime.AddHours(double.Parse(txtTime.Text));

                editedDiscount.Date = dateTime;

                DatabaseForShop.EditDiscount(editedDiscount);

                Response.Redirect("/Discounts");
            }
            catch (Exception)
            {
                pnlError.Visible = true;
            }
        }
    }
}
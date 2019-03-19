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
    public partial class Profile : System.Web.UI.Page
    {
        public static ShopModel shop;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.DoesExistShopCookie())
            {
                Response.Redirect("/Login");
            }

            if (!IsPostBack)
            {
                ddlCity.Items.Add(new ListItem("City", ""));
                ddlCity.Items.Add(new ListItem("Ankara", "1"));
                ddlCity.Items.Add(new ListItem("Eskişehir", "26"));
                ddlCity.Items.Add(new ListItem("İstanbul", "34"));

                string shopID = HttpContext.Current.Request.Cookies["Shop"]["ShopID"];
                shop = DatabaseForShop.GetShopInfo(shopID);

                txtShopName.Text = shop.Name;
                txtEmail.Text = shop.Email;
                txtPhone.Text = shop.Phone;
                txtAddress.Text = shop.Address;
                txtAbout.Text = shop.About;
                ddlCity.SelectedValue = shop.City.ToString();

                pnlSuccessful.Visible = false;
                pnlError.Visible = false;
            }            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ShopModel shopModel = shop;

                if (txtPassword.Text.Length > 0)
                {
                    shopModel.Password = txtPassword.Text;
                }

                shopModel.Name = txtShopName.Text;
                shopModel.Phone = txtPhone.Text;
                shopModel.Address = txtAddress.Text;
                shopModel.About = txtAbout.Text;
                shopModel.City = byte.Parse(ddlCity.SelectedValue);

                if (DatabaseForShop.SaveShopInfo(shopModel))
                {
                    pnlSuccessful.Visible = true;
                }
                else
                {
                    pnlError.Visible = true;
                }
            }
            catch (Exception)
            {
                pnlError.Visible = true;
            }
        }
    }
}
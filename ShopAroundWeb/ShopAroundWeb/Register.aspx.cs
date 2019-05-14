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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utilities.DoesExistShopCookie())
            {
                Response.Redirect("/Dashboard");
            }

            if (!IsPostBack)
            {
                ddlCity.Items.Add(new ListItem("City"));
                ddlCity.Items.Add(new ListItem("Ankara"));
                ddlCity.Items.Add(new ListItem("Eskişehir"));
                ddlCity.Items.Add(new ListItem("İstanbul"));
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (ddlCity.SelectedItem.ToString() != "City")
            {
                if (DatabaseForShop.SignUp(new ShopSignUpModel(txtShopName.Text, txtEmail.Text, txtPassword.Text, txtPhone.Text, ddlCity.SelectedItem.ToString())))
                {
                    Response.Redirect("/Login");
                }
            }            
        }
    }
}
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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utilities.DoesExistShopCookie())
            {
                Response.Redirect("/Dashboard");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string shopID = DatabaseForShop.SignIn(new ShopSignInModel(txtEmail.Text, txtPassword.Text));

            if (shopID != null)
            {
                Utilities.CreateCookie(shopID);

                Response.Redirect("/Dashboard");
            }
        }
    }
}
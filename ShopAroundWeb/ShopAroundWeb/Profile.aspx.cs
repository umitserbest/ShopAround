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
            //try
            //{
                ShopModel shopModel = shop;

                if (txtPassword.Text.Length > 0)
                {
                    shopModel.Password = txtPassword.Text;
                }

                string shopLogo = UploadLogo(fuLogo);

                if (shopLogo != null)
                {
                    shopModel.Name = txtShopName.Text;
                    shopModel.Phone = txtPhone.Text;
                    shopModel.Address = txtAddress.Text;
                    shopModel.About = txtAbout.Text;
                    shopModel.City = byte.Parse(ddlCity.SelectedValue);
                    shopModel.Logo = shopLogo;

                    if (DatabaseForShop.UpdateShopInfo(shopModel))
                    {
                        pnlSuccessful.Visible = true;
                    }
                    else
                    {
                        pnlError.Visible = true;
                    }
                }
                else
                {
                    pnlError.Visible = true;
                }                
            //}
            //catch (Exception)
            //{
            //    pnlError.Visible = true;
            //}
        }

        private string UploadLogo(FileUpload fileUpload)
        {
            //try
            //{
                if (fileUpload.ID.Contains("fu") && fileUpload.HasFile && fileUpload.PostedFile.ContentLength <= 3145728) //3 MB
                {
                    string fileName = Path.GetFileNameWithoutExtension(fileUpload.FileName).ToLower();
                    string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();

                    if (fileExtension == ".gif" || fileExtension == ".png" || fileExtension == ".jpeg" || fileExtension == ".jpg")
                    {
                        string imageName = Guid.NewGuid().ToString() + fileExtension;

                        fileUpload.PostedFile.SaveAs(Server.MapPath(@"~/ShopAssets/Logo/" + imageName));

                        return imageName;
                    }
                }

                return null;
            //}
            //catch
            //{
            //    return null;
            //}
        }
    }
}
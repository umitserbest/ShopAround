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
    public partial class AddProduct : System.Web.UI.Page
    {
        private static string shopID;
        private ProductModel product;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.DoesExistShopCookie())
            {
                Response.Redirect("/Login");
            }

            if (!IsPostBack)
            {
                shopID = HttpContext.Current.Request.Cookies["Shop"]["ShopID"];

                List<ProductTypeModel> productTypes = DatabaseForShop.GetProductTypes();

                foreach (ProductTypeModel productType in productTypes)
                {
                    ddlCategory.Items.Add(new ListItem(productType.Name, productType.ProductTypeID.ToString()));
                }
            }
        }

        private bool UploadImages()
        {
            try
            {
                foreach (FileUpload fileUpload in GetControlsOfType<FileUpload>(Page))
                {
                    if (fileUpload.ID.Contains("fu") && fileUpload.HasFile && fileUpload.PostedFile.ContentLength <= 3145728) //3 MB
                    {
                        string fileName = Path.GetFileNameWithoutExtension(fileUpload.FileName).ToLower();
                        string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();

                        if (fileExtension == ".gif" || fileExtension == ".png" || fileExtension == ".jpeg" || fileExtension == ".jpg")
                        {
                            string imageName = new Guid().ToString() + fileExtension;

                            fileUpload.PostedFile.SaveAs(Server.MapPath(@"~/ShopAssets/Products/" + imageName));                            
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IEnumerable<T> GetControlsOfType<T>(Control root) where T : Control
        {
            var t = root as T;
            if (t != null)
                yield return t;

            var container = root as Control;
            if (container != null)
                foreach (Control c in container.Controls)
                    foreach (var i in GetControlsOfType<T>(c))
                        yield return i;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (UploadImages())
            {

            }
        }
    }
}










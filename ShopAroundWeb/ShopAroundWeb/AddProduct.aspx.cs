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

                List<ProductTypeModel> productTypes = DatabaseForShop.GetProductTypes();

                foreach (ProductTypeModel productType in productTypes)
                {
                    ddlCategory.Items.Add(new ListItem(productType.Name, productType.ProductTypeID.ToString()));
                }

                //pnlSuccessful.Visible = false;
                pnlError.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string combineImageName = UploadImage(fuCombineImage);
            string coverImageName = UploadImage(fuCoverImage);
            string image1Name = UploadImage(fuImage1);
            string image2Name = UploadImage(fuImage2);
            string image3Name = UploadImage(fuImage3);

            if (combineImageName != null && coverImageName!= null && image1Name!= null && image2Name != null && image3Name != null)
            {
                ProductModel product = new ProductModel();
                product.ShopID = shopID;
                product.ProductTypeID = int.Parse(ddlCategory.SelectedValue);
                product.Code = txtProductCode.Text;
                product.Name = txtProductName.Text;
                product.Brand = txtBrand.Text;
                product.Color = txtColor.Text;
                product.Size = txtSize.Text;
                product.Material = txtMaterial.Text;
                product.Details = txtDetails.Text;
                product.CombineImage = combineImageName;
                product.CoverImage = coverImageName;
                product.Image1 = image1Name;
                product.Image2 = image2Name;
                product.Image3 = image3Name;
                product.Price = int.Parse(txtPrice.Text);
                product.PurchaseLink = txtPurchaseLink.Text;

                DatabaseForShop.AddProduct(product);

                Response.Redirect("/Products");

                //pnlSuccessful.Visible = true;
            }
            else
            {
                //Error
                pnlError.Visible = true;
            }
        }

        private string UploadImage(FileUpload fileUpload)
        {
            try
            {
                if (fileUpload.ID.Contains("fu") && fileUpload.HasFile && fileUpload.PostedFile.ContentLength <= 3145728) //3 MB
                {
                    string fileName = Path.GetFileNameWithoutExtension(fileUpload.FileName).ToLower();
                    string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();

                    if (fileExtension == ".gif" || fileExtension == ".png" || fileExtension == ".jpeg" || fileExtension == ".jpg")
                    {
                        string imageName = Guid.NewGuid().ToString() + fileExtension;

                        fileUpload.PostedFile.SaveAs(Server.MapPath(@"~/ShopAssets/Products/" + imageName));

                        return imageName;
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
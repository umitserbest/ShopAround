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
    public partial class EditProduct : System.Web.UI.Page
    {        
        private static int shopID;

        private static ProductModel product;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utilities.DoesExistShopCookie())
            {
                Response.Redirect("/Login");
            }

            int productID = 0;

            try
            {
                productID = int.Parse(Request.QueryString["ProductID"]);
            }
            catch (Exception)
            {
                Response.Redirect("/Products");
            }

            if (!IsPostBack)
            {
                shopID = int.Parse(HttpContext.Current.Request.Cookies["Shop"]["ShopID"]);

                List<ProductModel> products = DatabaseForShop.GetProducts(shopID);

                foreach (var item in products)
                {
                    if (item.ProductID == productID)
                    {
                        product = item;
                    }
                }

                List<ProductTypeModel> productTypes = DatabaseForShop.GetProductTypes();

                foreach (ProductTypeModel productType in productTypes)
                {
                    ddlCategory.Items.Add(new ListItem(productType.Name, productType.ProductTypeID.ToString()));
                }

                //pnlSuccessful.Visible = false;
                pnlError.Visible = false;

                ddlCategory.SelectedValue = product.ProductTypeID.ToString();
                txtProductCode.Text = product.Code;
                txtProductName.Text = product.Name;
                txtBrand.Text = product.Brand;
                txtColor.Text = product.Color;
                txtSize.Text = product.Size;
                txtMaterial.Text = product.Material;
                txtDetails.Text = product.Details;
                txtPrice.Text = product.Price.ToString();
                txtPurchaseLink.Text = product.PurchaseLink;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string combineImageName = UploadImage(fuCombineImage);
                string coverImageName = UploadImage(fuCoverImage);
                string image1Name = UploadImage(fuImage1);
                string image2Name = UploadImage(fuImage2);
                string image3Name = UploadImage(fuImage3);

                ProductModel editedProduct = product;

                if (combineImageName != null)
                {
                    editedProduct.CombineImage = combineImageName;
                }

                if (coverImageName != null)
                {
                    editedProduct.CoverImage = coverImageName;
                }

                if (image1Name != null)
                {
                    editedProduct.Image1 = image1Name;
                }

                if (image2Name != null)
                {
                    editedProduct.Image2 = image2Name;
                }

                if (image3Name != null)
                {
                    editedProduct.Image3 = image3Name;
                }

                editedProduct.ProductTypeID = int.Parse(ddlCategory.SelectedValue);
                editedProduct.Code = txtProductCode.Text;
                editedProduct.Name = txtProductName.Text;
                editedProduct.Brand = txtBrand.Text;
                editedProduct.Color = txtColor.Text;
                editedProduct.Size = txtSize.Text;
                editedProduct.Material = txtMaterial.Text;
                editedProduct.Details = txtDetails.Text;
                editedProduct.Price = float.Parse(txtPrice.Text);
                editedProduct.PurchaseLink = txtPurchaseLink.Text;

                DatabaseForShop.EditProduct(editedProduct);

                Response.Redirect("/Products");
            }
            catch (Exception)
            {
                pnlError.Visible = true;
            }

            //pnlSuccessful.Visible = true;

            //Error
            //pnlError.Visible = true;

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
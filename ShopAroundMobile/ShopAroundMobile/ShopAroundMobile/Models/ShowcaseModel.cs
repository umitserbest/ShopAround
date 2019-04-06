using ShopAroundWeb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAroundMobile.Models
{
    public class ShowcaseModel
    {
        public int ProductID { get; set; }
        
        public int ProductTypeID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public string Details { get; set; }
        public string CombineImage { get; set; }
        public string CoverImage { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }

        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string ShopLogo { get; set; }

        public ShowcaseModel(ProductModel productModel, ShopModel shopModel)
        {
            this.ProductID = productModel.ProductID;
            this.ProductTypeID = productModel.ProductTypeID;
            this.Code = productModel.Code;
            this.Name = productModel.Name;
            this.Brand = productModel.Brand;
            this.Color = productModel.Color;
            this.Size = productModel.Size;
            this.Material = productModel.Material;
            this.Details = productModel.Details;
            this.CombineImage = productModel.CombineImage;
            this.CoverImage = productModel.CoverImage;
            this.Image1 = productModel.Image1;
            this.Image2 = productModel.Image2;
            this.Image3 = productModel.Image3;
            this.ShopID = shopModel.ShopID;
            this.ShopName = shopModel.Name;
            this.ShopLogo = shopModel.Logo;
        }
    }
}

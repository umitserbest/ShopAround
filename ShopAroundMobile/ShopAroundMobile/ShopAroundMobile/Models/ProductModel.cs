using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAroundMobile.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public int ShopID { get; set; }
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
        public float Price { get; set; }
        public string PurchaseLink { get; set; }
        public ProductModel()
        {

        }
    }
}
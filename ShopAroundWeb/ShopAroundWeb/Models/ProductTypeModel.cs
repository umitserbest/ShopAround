using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAroundWeb.Models
{
    public class ProductTypeModel
    {
        public int ProductTypeID { get; set; }
        public string Name { get; set; }

        public ProductTypeModel()
        {

        }

        public ProductTypeModel(int productTypeID, string name)
        {
            ProductTypeID = productTypeID;
            Name = name;
        }
    }
}
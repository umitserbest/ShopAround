using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAroundWeb.Models
{
    public class DiscountModel
    {       
        public int DiscountID { get; set; }
        public int ShopID { get; set; }
        public int ProductID { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public string Code { get; set; }
        public string ShopName { get; set; }
        public string ShopLogo { get; set; }

        public DiscountModel()
        {

        }
    }
}
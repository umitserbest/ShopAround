using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAroundMobile.Models
{
    public class DiscountModel
    {
        public int DiscountID { get; set; }
        public int ShopID { get; set; }
        public int ProductID { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public string ShopName { get; set; }
        public string ShopLogo { get; set; }
        public string Code { get; set; }

        public DiscountModel()
        {

        }

    }
}

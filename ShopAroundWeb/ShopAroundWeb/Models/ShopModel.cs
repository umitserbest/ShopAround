using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAroundWeb.Models
{
    public class ShopModel
    {
        public int ShopID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }        
        public string City { get; set; }
        public string About { get; set; }
        public string Logo { get; set; }

        public ShopModel()
        {
            
        }
    }
}
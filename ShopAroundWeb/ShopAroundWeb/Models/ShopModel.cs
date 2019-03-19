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
        public byte City { get; set; }
        public string About { get; set; }

        public ShopModel()
        {
            
        }

        public ShopModel(string name, string email, string password, string phone, string address, byte city, string about)
        {
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            Address = address;
            City = city;
            About = about;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAroundWeb.Models
{
    public class ShopSignUpModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public byte City { get; set; }

        public ShopSignUpModel(string name, string email, string password, string phone, byte city)
        {
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            City = city;
        }
    }
}
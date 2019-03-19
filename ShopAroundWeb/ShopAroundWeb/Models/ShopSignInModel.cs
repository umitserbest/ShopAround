using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAroundWeb.Models
{
    public class ShopSignInModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public ShopSignInModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
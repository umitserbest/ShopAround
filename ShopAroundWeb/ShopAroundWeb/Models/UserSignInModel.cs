using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAroundWeb.Models
{
    public class UserSignInModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserSignInModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
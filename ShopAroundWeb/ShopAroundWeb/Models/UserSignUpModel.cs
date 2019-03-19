using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAroundWeb.Models
{
    public class UserSignUpModel
    {        
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserSignUpModel(string username, string password, string email)
        {
            Username = username;            
            Password = password;
            Email = email;
        }
    }
}
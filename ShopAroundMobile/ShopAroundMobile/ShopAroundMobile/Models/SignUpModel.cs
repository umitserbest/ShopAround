using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAroundMobile.Models
{
    public class SignUpModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public SignUpModel(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
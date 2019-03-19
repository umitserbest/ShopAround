﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAroundMobile.Models
{
    public class SignInModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public SignInModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
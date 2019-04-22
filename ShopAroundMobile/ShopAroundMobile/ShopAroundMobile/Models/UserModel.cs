using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAroundMobile.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string About { get; set; }
       // public string Image { get; set; }

        public UserModel()
        {

        }
    }
}
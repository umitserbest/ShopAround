using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAroundMobile.Models
{
    public class LocalUserModel
    {
        [PrimaryKey, AutoIncrement]
        private int ID { get; set; }

        [Unique]
        public int UserID { get; set; }

        [Unique]
        public string Username { get; set; }

        public string Password { get; set; }


        public LocalUserModel()
        {

        }

        public LocalUserModel(int userID)
        {
            UserID = userID;
        }
    }
}
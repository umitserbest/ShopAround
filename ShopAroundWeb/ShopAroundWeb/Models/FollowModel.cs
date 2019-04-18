using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAroundWeb.Models
{
    public class FollowModel
    {
        public int ShopID { get; set; }
        public int UserID { get; set; }
        
        public FollowModel(int shopID, int userID)
        {
            ShopID = shopID;
            UserID = userID;
        }
    }
}
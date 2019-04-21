using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAroundMobile.Models
{
    public class FollowsModel
    {
        public int ShopID { get; set; }
        public int UserID { get; set; }

        public FollowsModel(int shopId, int userId)
        {
            ShopID = shopId;
            UserID = userId;
        }
    }
}

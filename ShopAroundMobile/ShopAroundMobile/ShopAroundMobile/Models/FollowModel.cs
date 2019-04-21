using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace ShopAroundMobile.Models
{
   
    public class FollowModel
    {
        public int ShopID { get; set; }
        public int UserID { get; set; }

        
        public FollowModel(int shopId, int userId)
        {
            ShopID = shopId;
            UserID = userId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAroundWeb.Models
{
    public class NotificationModel
    {
        public int NotificationID { get; set; }
        public int SenderID { get; set; }
        public string SenderUsername { get; set; }
        public int ReceiverID { get; set; }

        public NotificationModel()
        {

        }

        public NotificationModel(int notificationID, int senderID, string senderUsername, int receiverID)
        {
            NotificationID = notificationID;
            SenderID = senderID;
            SenderUsername = senderUsername;
            ReceiverID = receiverID;
        }
    }
}
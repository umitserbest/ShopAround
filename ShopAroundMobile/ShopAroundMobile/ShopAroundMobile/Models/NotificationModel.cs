using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAroundMobile.Models
{
    public class NotificationModel
    {
        public int NoficationID { get; set; }
        public int SenderID { get; set; }
        public string SenderUsername { get; set; }
        public int ReceiverID { get; set; }

        public NotificationModel()
        {

        }

        public NotificationModel(int noficationID, int senderID, string senderUsername, int receiverID)
        {
            NoficationID = noficationID;
            SenderID = senderID;
            SenderUsername = senderUsername;
            ReceiverID = receiverID;
        }
    }
}

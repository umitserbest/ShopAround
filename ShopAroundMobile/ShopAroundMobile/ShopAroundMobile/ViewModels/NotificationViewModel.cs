using ShopAroundMobile.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShopAroundMobile.ViewModels
{
    public class NotificationViewModel
    {
        public ObservableCollection<Notifications> Notifications { get; set; }

        public NotificationViewModel()
        {
            Notifications = new ObservableCollection<Notifications>();

            Notifications.Add(new Notifications
            {
                NoticeText = "Serq26 followed you.",
                NoticeImage = "explore",
                NoticeDate=DateTime.Now
            });
            Notifications.Add(new Notifications
            {
                NoticeText = "sad123c followed you.",
                NoticeImage = "home",
                NoticeDate = DateTime.Now
            });
            Notifications.Add(new Notifications
            {
                NoticeText = "Sersers212 followed you.",
                NoticeImage = "explore",
                NoticeDate = DateTime.Now
            });
        }

    }
}

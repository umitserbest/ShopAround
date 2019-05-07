using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ShopAroundMobile.ViewModels;
namespace ShopAroundMobile.TabbedPages
{
    public class NotificationTabControl : TabbedPage 
    {
        public static Notifications tabbedNotifications;
        public static Discounts tabbedDiscounts;

        public NotificationTabControl()
        {
           
            Title = "Notification";
            Icon = "notice";
            BarBackgroundColor = Color.White;
            BarTextColor = Color.Gray;

            tabbedNotifications = new Notifications();
            tabbedDiscounts = new Discounts();
            
            Children.Add(tabbedNotifications);
            Children.Add(tabbedDiscounts);

        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            
        }
    }
}

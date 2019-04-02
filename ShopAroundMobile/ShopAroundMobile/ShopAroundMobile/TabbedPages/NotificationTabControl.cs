using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ShopAroundMobile.TabbedPages;
namespace ShopAroundMobile.TabbedPages
{
    public class NotificationTabControl : TabbedPage 
    {
       
        public NotificationTabControl()
        {
            Title = "Notification";
            Icon = "combnye";
            BarBackgroundColor = Color.White;
            BarTextColor = Color.Gray;
            
            Children.Add(new Notifications());
            Children.Add(new Discounts());

        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            
        }
    }
}

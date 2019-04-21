using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;


namespace ShopAroundMobile.TabbedPages
{
    public class TabPageControl : Xamarin.Forms.TabbedPage
    {

        public TabPageControl()
        {
          
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            Children.Add(new Showcase());
            Children.Add(new Explore());
            Children.Add(new NotificationTabControl());
            Children.Add(new Profile());
            Children.Add(new ShopProfile(4));
            

            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}

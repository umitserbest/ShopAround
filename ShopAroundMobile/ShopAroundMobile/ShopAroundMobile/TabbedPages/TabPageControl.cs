using System;
using System.Collections.Generic;
using System.Text;
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
            Children.Add(new Notifications());
            Children.Add(new Profile());
            
            
        }
    }
}

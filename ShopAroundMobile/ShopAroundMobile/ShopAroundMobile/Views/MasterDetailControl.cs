using ShopAroundMobile.TabbedPages;
using ShopAroundMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ShopAroundMobile.Views
{
    public class MasterDetailControl : MasterDetailPage
    {
        public MasterDetailControl()
        {
            //var md = new MasterDetailControl();
            //md.MasterBehavior = MasterBehavior.Popover;

            
            Master = new SettingsMenu();
            //Detail = new NavigationPage(new ShopProfile());

            var nav = new NavigationPage(new ShopProfile());
            //nav.BarBackgroundColor = Color.Green;
            Detail = nav;




        }
    }
}

using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Plugin.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.TabbedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profile : ContentPage
	{
       
        public Profile ()
		{
			InitializeComponent ();
            
            //var tabView = new TabViewControl(new List<TabItem>()
            //  {
            //         new TabItem( 

            //              "Profile",
            //              new StackLayout()
            //              {
            //                  Children =
            //                  {
            //                     UserImages
            //                  },
            //                  BackgroundColor = Color.LightGray,
            //                  Padding = 10
            //              }),
            //           new TabItem(
            //                  "WishList",
            //                  new StackLayout()
            //                  {
            //                      Children =
            //                      {
            //                         WishList
            //                      },
            //                      BackgroundColor = Color.LightSalmon,
            //                      Padding = 10
            //                        })
            //                   });


            //tabView.VerticalOptions = LayoutOptions.End;
            //tabView.HeaderBackgroundColor = Color.White;
            //tabView.HeaderTabTextColor = Color.Gray;
            ////tabView.HeightRequest = 300;

            //MainGrid.Children.Add(tabView,0,3);



            //var mainLayout = new StackLayout();
            //mainLayout.Children.Add(layout);
            //mainLayout.Children.Add(tabView);
            //Content = mainLayout;
        }

       
    }
}
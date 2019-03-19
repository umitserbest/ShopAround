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


            var layout = new StackLayout();
            var image = new Image
            {
                Source="profile",
                HeightRequest= 100,
                HorizontalOptions=LayoutOptions.Center
            };
            var label = new Label
            {
                Text = "Serhat Çolak",
                TextColor = Color.Gray,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center
            };
           
            layout.Children.Add(image);
            layout.Children.Add(label);
           
            layout.VerticalOptions = LayoutOptions.Start;
            layout.BackgroundColor = Color.LightGray;
            
            layout.HeightRequest = 250;
            layout.Spacing = 10;
            

            var tabView = new TabViewControl(new List<TabItem>()
              {
                     new TabItem( 
                         
                          "Profile",
                          new StackLayout()
                          {
                              Children =
                              {
                                  new Label(){
                                      FontSize = 18,
                                      Text = "This page is a profile page.",
                                      TextColor = Color.Green,
                                  }
                              },
                              BackgroundColor = Color.LightGray,
                              Padding = 10
                          }),
                       new TabItem(
                              "WishList",
                              new StackLayout()
                              {
                                  Children =
                                  {
                                      new ListView(){
                                          ItemsSource = new string[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6" }
                                      }
                                  },
                                  BackgroundColor = Color.LightSalmon,
                                  Padding = 10
                                    })
                               });
            tabView.VerticalOptions = LayoutOptions.End;
            tabView.HeaderBackgroundColor = Color.White;
            tabView.HeaderTabTextColor = Color.Gray;
            tabView.HeightRequest = 300;
            

            var mainLayout = new StackLayout();
            mainLayout.Children.Add(layout);
            mainLayout.Children.Add(tabView);
            Content = mainLayout;
        }
    }
}
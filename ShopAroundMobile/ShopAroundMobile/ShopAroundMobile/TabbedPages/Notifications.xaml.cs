using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Plugin.TabView;
using Xamarin.Forms;


namespace ShopAroundMobile.TabbedPages
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Notifications : ContentPage
	{
        TabViewControl tabView;

        public Notifications()
        {
            InitializeComponent();

            tabView = new TabViewControl(new List<TabItem>()
            {
                new TabItem("Tab 1", new Label{Text = "Tab 1", HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Red}),
                new TabItem("Tab 2", new Label{Text = "Tab 2", HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Green}),
              
            });
            tabView.VerticalOptions = LayoutOptions.FillAndExpand;
            theS1.Children.Add(tabView);

            tabView.PositionChanged += TabView_PositionChanged;
            tabView.PositionChanging += TabView_PositionChanging; ;


        }
        private void TabView_PositionChanging(object sender, PositionChangingEventArgs e)
        {

        }

        private void TabView_PositionChanged(object sender, PositionChangedEventArgs e)
        {

        }


    }
}
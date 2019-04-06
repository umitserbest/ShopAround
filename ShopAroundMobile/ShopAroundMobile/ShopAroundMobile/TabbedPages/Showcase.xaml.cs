using ShopAroundMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.TabbedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Showcase : ContentPage
	{


        public Showcase()
        {
            InitializeComponent();
            
            
           // BindingContext = new ShowcaseViewModel();

            ShowcaseViewModel showcase = new ShowcaseViewModel(listView);


            //var ProductInfo = new Frame();

            //var frameXaml = $"Frame x:Name=\"ProductInfo\" Margin=\"0,-15,0,0\" Grid.Row=\"1\" Opacity=\"0.8\" BackgroundColor=\"Black\">" +
            //    $"<Label Text =\"Size : M Color: Red\" TextColor=\"White\" FontSize=\"14\"></Label></Frame>";


        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var ImageTapped = (Image)sender;

            //Grid ParentFrameLayout = (Grid)ImageTapped.Parent;

            //Frame ProductInfoFrame = (Frame)ParentFrameLayout.Children[2];

            //ProductInfoFrame.IsVisible = true;

            //bool ProductInfoVisible = ProductInfoFrame.IsVisible;
            
            


        }
    }
}
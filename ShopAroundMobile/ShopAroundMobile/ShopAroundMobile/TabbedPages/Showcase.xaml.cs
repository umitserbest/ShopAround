using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using ShopAroundMobile.ViewModels;
using ShopAroundMobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
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
            //BindingContext = new ShowcaseViewModel(listView);
            //tryButton.IsVisible = false;
            Reload();

            //ShowcaseViewModel showcase = new ShowcaseViewModel(listView);
            
        }

        public void Reload()
        {
            BindingContext = new ShowcaseViewModel(listView);
            
            if(ShowcaseViewModel.isLoading == false)
            {                
               // TryStacklayout.IsVisible = true;
                //MainGrid.Children.Add(TryStacklayout);
                //tryButton.IsVisible = true;
                //activity.IsVisible = true;
                //activity.IsRunning = true;

            }
            else
            {                
               // TryStacklayout.IsVisible = false;
                //MainGrid.Children.Remove(TryStacklayout);
               // MainGrid.RowDefinitions.RemoveAt(2);
                

            }
            
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var ImageTapped = (Image)sender;

            var showcase = ImageTapped?.BindingContext as ShowcaseModel;

            var vm = BindingContext as ShowcaseViewModel;


            await PopupNavigation.Instance.PushAsync(new PopupView(showcase));
          
            
        }
        
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var Image = sender as Image;

            var showcase = Image?.BindingContext as ShowcaseModel;

            var vm = BindingContext as ShowcaseViewModel;

            vm.AddWishList.Execute(showcase);

            //Image.Source = "Wishedlist";

            TabPageControl.profileTabbed.Reload();
        }
                              
        private async void Label_Tapped(object sender, EventArgs e)
        {
            var LabelTapped = (Label)sender;

            var showcase = LabelTapped?.BindingContext as ShowcaseModel;

            var vm = BindingContext as ShowcaseViewModel;

            await Navigation.PushAsync(new ShopProfile(showcase.ShopID));
        }

        private async void Frame_Tapped(object sender, EventArgs e)
        {
            var frame = sender as Frame;

            var showcase = frame?.BindingContext as ShowcaseModel;

            var vm = BindingContext as ShowcaseViewModel;

            await Browser.OpenAsync(showcase.PurchaseLink, BrowserLaunchMode.SystemPreferred);
        }

        private void TryAgain_Clicked(object sender, EventArgs e)
        {
            Reload(); 
        }

        private void ShopAround_Tapped(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
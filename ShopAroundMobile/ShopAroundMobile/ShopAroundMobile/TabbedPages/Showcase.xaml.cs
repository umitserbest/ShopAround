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
            Reload();            
        }

        public void Reload()
        {
            BindingContext = new ShowcaseViewModel(listView);
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                var ImageTapped = (Image)sender;

                var showcase = ImageTapped?.BindingContext as ShowcaseModel;

                var vm = BindingContext as ShowcaseViewModel;

                await PopupNavigation.Instance.PushAsync(new PopupView(showcase));
            }
            catch (Exception)
            {

                //throw;
            }  
            
        }
        
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            try
            {
                var Image = sender as Image;

                var showcase = Image?.BindingContext as ShowcaseModel;

                var vm = BindingContext as ShowcaseViewModel;

                vm.AddWishList.Execute(showcase);

                TabPageControl.profileTabbed.Reload();
            }
            catch (Exception)
            {

               // throw;
            }
        }
                              
        private async void Label_Tapped(object sender, EventArgs e)
        {
            try
            {
                var LabelTapped = (Label)sender;

                var showcase = LabelTapped?.BindingContext as ShowcaseModel;

                var vm = BindingContext as ShowcaseViewModel;

                await Navigation.PushAsync(new ShopProfile(showcase.ShopID));
            }
            catch (Exception)
            {

               // throw;
            }
        }

        private async void Frame_Tapped(object sender, EventArgs e)
        {
            try
            {
                var frame = sender as Frame;

                var showcase = frame?.BindingContext as ShowcaseModel;

                var vm = BindingContext as ShowcaseViewModel;

                await Browser.OpenAsync(showcase.PurchaseLink, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception)
            {

               // throw;
            }
        }       

        private void ShopAround_Tapped(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
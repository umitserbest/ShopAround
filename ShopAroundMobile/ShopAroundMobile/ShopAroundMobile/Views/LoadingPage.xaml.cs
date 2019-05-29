using ShopAroundMobile.TabbedPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            DelayedNaviagition();
        }

        private async void DelayedNaviagition()
        {
            try
            {
                await Task.Delay(2000);

                await Navigation.PushAsync(new TabPageControl());
            }
            catch (Exception)
            {
               // throw;
            }
        }
    }
}
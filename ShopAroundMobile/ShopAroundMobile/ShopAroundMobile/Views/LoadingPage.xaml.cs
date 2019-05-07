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

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    // Waiting some time
        //    await Task.Delay(2000);

        //    // Start animation
        //    await Task.WhenAll(
        //        SplashGrid.FadeTo(0, 2000),
        //        Logo.ScaleTo(10, 2000)
        //        );

        //    DelayedNaviagition();
        //}

        private async void DelayedNaviagition()
        {
            await Task.Delay(2000);

            await Navigation.PushAsync(new TabPageControl());
        }
    }
}
using ShopAroundMobile.LoginPages;
using ShopAroundMobile.TabbedPages;
using ShopAroundMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ShopAroundMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new CustomNavigationPage(new ShopProfile());
             MainPage = new TabPageControl();
            //MainPage = new CarouselTest();

#if DEBUG
            LiveReload.Init();
#endif
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

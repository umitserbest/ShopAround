
using ShopAroundMobile.TabbedPages;
using ShopAroundMobile.ViewModels;
using ShopAroundMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ShopAroundMobile
{
    public partial class App : Application
    {
        public static int UserdId { get; set; }

       // public static int ShopId { get; set; } = 4;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Login());
            //MainPage = new CustomNavigationPage(new ShopProfile());
            //MainPage = new NavigationPage(new ShopProfile(4));
           // MainPage = new FriendProfile();
           

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

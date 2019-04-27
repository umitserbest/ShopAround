
using ShopAroundMobile.TabbedPages;
using ShopAroundMobile.ViewModels;
using ShopAroundMobile.Views;
using ShopAroundMobile.Helpers;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShopAroundMobile.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ShopAroundMobile
{
    public partial class App : Application
    {        
        public static LocalUserModel AppUser { get; set; }

        public App()
        {
            InitializeComponent();

            Database.Connect();

            AppUser = Database.GetUser();

            if (AppUser == null)
            {
                MainPage = new NavigationPage(new Login());
            }
            else
            {
                MainPage = new NavigationPage(new TabPageControl());
            }

            //MainPage = new NavigationPage(new Login());
            //MainPage = new CustomNavigationPage(new ShopProfile());
            //MainPage = new NavigationPage(new ShopProfile(4));
            //MainPage = new FriendProfile();

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
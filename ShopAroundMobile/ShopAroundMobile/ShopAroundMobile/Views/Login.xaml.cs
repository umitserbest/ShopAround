using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using ShopAroundMobile.TabbedPages;
using ShopAroundMobile.Views;
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
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void SignInAsync(object sender, EventArgs e)
        {
            SignInModel signInModel = new SignInModel(username.Text, password.Text);
            try
            {
                string signInObject = JsonConvert.SerializeObject(signInModel);

                string result = await WebService.SendDataAsync("SignIn", "userSignIn=" + signInObject);

                if (result != "false")// User is existed
                {
                    Database.AddUser(new LocalUserModel(int.Parse(result)));

                    var log = Database.GetLog();

                    if (log != null)
                    {
                        App.AppUser = Database.GetUser();
                        await Navigation.PushAsync(new TabPageControl());
                    }
                    else
                    {
                        App.AppUser = Database.GetUser();

                        Database.AddLog(new LocalLogModel());
                        await Navigation.PushAsync(new ProfileSettings());
                    }

                }
                else
                {
                    await DisplayAlert("Error", "UserName or Password is not correct.", "OK");
                }
            }
            catch (Exception)
            {
               // throw;
            }
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new SignUp());
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new SignUp());
            }
            catch (Exception)
            {
                //throw;
            }
        }
    }
}
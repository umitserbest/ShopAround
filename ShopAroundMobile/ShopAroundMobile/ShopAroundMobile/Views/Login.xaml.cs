using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
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
            string signInObject = JsonConvert.SerializeObject(signInModel);

            string result = await WebService.SendDataAsync("SignIn", "userSignIn=" + signInObject);

            if (result != "false")
            {
                Database.AddUser(new LocalUserModel(int.Parse(result)));

                App.AppUser = Database.GetUser();

                await Navigation.PushAsync(new ProfileSettings());
            }
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }
    }
}
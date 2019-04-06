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
		}

        private async void SignInAsync(object sender, EventArgs e)
        {
            SignInModel signInModel = new SignInModel(username.Text, password.Text);
            string signInObject = JsonConvert.SerializeObject(signInModel);

            string result = await WebService.SendDataAsync("SignIn", "userSignIn=" + signInObject);

            if(result != "false")
            {
                App.UserdId = int.Parse(result);
                await Navigation.PushAsync(new ProfileSettings());
            }

        }
    }
}
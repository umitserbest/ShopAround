using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.LoginPages
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

            ((Button)sender).Text = await WebService.SendDataAsync("SignIn", "userSignIn=" + signInObject);


        }
    }
}
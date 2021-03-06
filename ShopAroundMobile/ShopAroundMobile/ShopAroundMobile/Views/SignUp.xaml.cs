﻿using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
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
	public partial class SignUp : ContentPage
	{
		public SignUp ()
		{
			InitializeComponent ();
		}

        private async void SignUpAsync(object sender, EventArgs e)
        {
            try
            {
                SignUpModel signUpModel = new SignUpModel(username.Text, password.Text, email.Text);
                string signUpObject = JsonConvert.SerializeObject(signUpModel);

                string result = await WebService.SendDataAsync("SignUp", "userSignUp=" + signUpObject);

                if (result == "true")
                {
                    Database.DeleteLog();
                    bool dialogResult = await DisplayAlert("ShopAround", "You have been registered!", "OK", "Cancel");
                    if (dialogResult == true)
                    {
                        await Navigation.PushAsync(new Login());
                    }

                }
            }
            catch (Exception)
            {
               //throw;
            }
            
        }

    }
}
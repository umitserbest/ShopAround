using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.TabbedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Explore : ContentPage
	{
      
        public Explore ()
		{
			InitializeComponent ();

            BindingContext = new ExploreViewModel();

            GetProductImages();
        }

        private async void GetProductImages(object sender, EventArgs e)
        {
            SignUpModel signUpModel = new SignUpModel(username.Text, password.Text, email.Text);
            string signUpObject = JsonConvert.SerializeObject(signUpModel);

            string result = await WebService.SendDataAsync("GetProducts", null);

            if (result == "true")
            {
                await DisplayAlert("ShopAround", "You have been registered!", "OK", "Cancel");
                // sayfa geçişi
            }

        }

    }
}
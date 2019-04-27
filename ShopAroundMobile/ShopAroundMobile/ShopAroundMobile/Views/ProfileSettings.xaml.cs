using Newtonsoft.Json;
using Plugin.Media;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfileSettings : ContentPage
	{ 
        public ProfileSettings ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            user.UserID = App.AppUser.UserID;
            user.Name = EntryName.Text;
            user.Surname = EntrySurname.Text;
            user.Phone = EntryPhone.Text;
            user.About = EntryAbout.Text;

            string userObject = JsonConvert.SerializeObject(user);

            string result = await WebService.SendDataAsync("AddProfileInfo", "user=" + userObject);

            if (result == "true")
            {
                //DependencyService.Get<IMessage>().Message("You have been registered.");
                await Navigation.PushAsync(new SuggestShop());
            }
            else
            {
                DependencyService.Get<IMessage>().Message("Error!");
            }
        }
    }
}
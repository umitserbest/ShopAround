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
        Stream imgStr;        

        public ProfileSettings ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                UserModel user = new UserModel();

                user.UserID = App.AppUser.UserID;
                user.Name = EntryName.Text;
                user.Surname = EntrySurname.Text;
                user.City = picker.SelectedItem.ToString();

                string userObject = JsonConvert.SerializeObject(user);

                string result = await WebService.SendDataAsync("UpdateProfile", "user=" + userObject);

                if (result == "true")
                {
                    await Navigation.PushAsync(new SuggestShop());
                }
                else
                {
                    DependencyService.Get<IMessage>().Message("Error!");
                }
            }
            catch (Exception)
            {
               // throw;
            }
        }
    }
}
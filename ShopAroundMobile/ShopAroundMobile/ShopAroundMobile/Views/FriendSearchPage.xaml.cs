using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using ShopAroundMobile.TabbedPages;
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
	public partial class FriendSearchPage : ContentPage
	{
        string Logopath = "https://shoparound.umitserbest.com/shopassets/logo/";

        public FriendSearchPage ()
		{
			InitializeComponent ();
		}

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            string result = await WebService.SendDataAsync("GetUsersByName", "name=" + searchBar.Text);

            if (result != "Error" && result != null && result.Length > 6)
            {

                List<UserModel> users = JsonConvert.DeserializeObject<List<UserModel>>(result);

                foreach (var user in users)
                {
                    if (user.UserID == App.AppUser.UserID)
                    {
                        users.Remove(user);
                        break;
                    }
                }

                listView.ItemsSource = users;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = (int)btn.CommandParameter;

            await Navigation.PushAsync(new FriendProfile(id));
        }
    }
}
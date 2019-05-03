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
            UserModel user = new UserModel();
            user.UserID = App.AppUser.UserID;
            user.Name = EntryName.Text;
            user.Surname = EntrySurname.Text;
            user.Phone = EntryPhone.Text;
            user.About = EntryAbout.Text;
            //user.Image = Image.Source.ToString();

            string userObject = JsonConvert.SerializeObject(user);

            string result = await WebService.SendDataAsync("AddProfileInfo", "user=" + userObject);

            if (result == "true")
            {
                DependencyService.Get<IMessage>().Message("You have been registered.");
                await Navigation.PushAsync(new SuggestShop());
            }
            else
            {
                DependencyService.Get<IMessage>().Message("Error!");
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            var imgData = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions());

            if (imgData != null)
            {
                Image.Source = ImageSource.FromStream(() => imgStr);
                imgStr = imgData.GetStream();
            }

            
            Image.Source = ImageSource.FromStream(imgData.GetStream);

            
            
            Add_Image.IsVisible = false;
            Add_Img_Text.IsVisible = false;
        }
    }
}
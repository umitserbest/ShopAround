using Newtonsoft.Json;
using Plugin.Media;
using ShopAroundMobile.Helpers;
using ShopAroundWeb.Models;
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
        public string ImageName;

        public ProfileSettings ()
		{
			InitializeComponent ();
		}


        //public static byte[] ReadFully(Stream input)
        //{
        //    byte[] buffer = new byte[16 * 1024];
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        int read;
        //        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        //        {
        //            ms.Write(buffer, 0, read);
        //        }
        //        return ms.ToArray();
        //    }
        //}

        //async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    await CrossMedia.Current.Initialize();

        //    var imgData = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions());

        //    if (imgData != null)
        //    {
        //        imgStr = imgData.GetStream();
        //        Image.Source = ImageSource.FromStream(() => imgStr);

        //        ImageName = Image.Source.ToString();
        //        byte[] data = ReadFully(imgStr);
        //        Image.Source = ImageSource.FromStream(imgData.GetStream);

        //        string dataObject = JsonConvert.SerializeObject(new Tuple<string, byte[]>(ImageName, data));

        //        string result = await WebService.SendDataAsync("UploadProfileImage", "image=" + dataObject);
        //    }

          

        //    Add_Image.IsVisible = false;
        //    Add_Img_Text.IsVisible = false;
        //}

        private async void Save_Clicked(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            user.UserID = App.UserdId;
            user.Name = EntryName.Text;
            user.Surname = EntrySurname.Text;
            user.Phone = EntryPhone.Text;
            user.About = EntryAbout.Text;
           // user.Image = ImageName;



            string userObject = JsonConvert.SerializeObject(user);

            string result = await WebService.SendDataAsync("AddProfileInfo", "user=" + userObject);

            if (result == "true")
            {
                await DisplayAlert("ShopAround", "You have been registered!", "OK", "Cancel");
                await Navigation.PushAsync(new SuggestShop());
            }
            else
            {
                await DisplayAlert("ShopAround", "Error", "OK", "Cancel");
            }
        }
    }
}
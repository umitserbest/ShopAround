using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using ShopAroundMobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Plugin.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.TabbedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profile : ContentPage
	{
        bool WishlistReloaded;
        bool UserReloaded;

        string Productpath = "https://shoparound.umitserbest.com/shopassets/products/";
        public Profile ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, true);         
           
        }

        public async void Reload()
        {           
            if (!WishlistReloaded)
            {
                await GetWishList();
            }
            if (!UserReloaded)
            {
                await GetUserInfo();
            }
        }

        public async void Trigger()
        {
            await GetUserInfo();
            await GetWishList();
            await GetFriendList();
        }

        async Task GetFriendList()
        {
            try
            {
                List<int> friend = new List<int>();
                List<UserModel> user = new List<UserModel>();

                string friendresult = await WebService.SendDataAsync("GetFriends", "userID=" + App.AppUser.UserID);

                if (friendresult != "Error" && friendresult != null && friendresult.Length > 0 && friendresult != "null")
                {
                    friend = JsonConvert.DeserializeObject<List<int>>(friendresult);
                    foreach (int item in friend)
                    {
                        string userresult = await WebService.SendDataAsync("GetUserProfile", "userID=" + item);

                        if (userresult != "Error" && userresult != null && userresult.Length > 6)
                        {
                            UserModel listUser = JsonConvert.DeserializeObject<UserModel>(userresult);
                            user.Add(listUser);                            
                        }
                    }
                    listView.ItemsSource = user;
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        async Task GetWishList()
        {
            try
            {
                UserImages.Children.Clear();
                List<ProductModel> products = new List<ProductModel>();

                string wishlistresult = await WebService.SendDataAsync("GetWishlist", "userID=" + App.AppUser.UserID);

                if (wishlistresult != "Error" && wishlistresult != null && wishlistresult.Length > 6)
                {
                    products = JsonConvert.DeserializeObject<List<ProductModel>>(wishlistresult);
                    WishlistReloaded = true;

                    activity.IsVisible = false;
                    activity.IsRunning = false;
                    activity.IsEnabled = false;

                    tryButton.IsVisible = false;
                }
                else
                {
                    tryButton.IsVisible = true;
                    activity.IsVisible = true;
                    activity.IsRunning = true;
                    activity.IsEnabled = true;
                }
                for (int i = 0; i < products.Count + 1 / 2; i++)
                {
                    UserImages.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
                }

                int counter = 0;

                for (int j = 0; j < products.Count + 1 / 2; j++)
                {

                    for (int k = 0; k < 2; k++)
                    {
                        if (counter == products.Count)
                        {
                            j = products.Count + 1;
                            break;
                        }

                        Image image = new Image();
                        image.Source = Productpath + products[counter].CoverImage;
                        image.Aspect = Aspect.AspectFill;
                        image.WidthRequest = 400;

                        ProductModel product = products[counter];

                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (s, e) =>
                        {
                            tapGestureRecognizer.NumberOfTapsRequired = 1;

                            Navigation.PushAsync(new PhotoDetailPage(product,true,"Profile"));
                        };
                        image.GestureRecognizers.Add(tapGestureRecognizer);
                        UserImages.Children.Add(image, k, j);
                        counter++;
                        
                        
                    }
                }
            }
            catch (Exception)
            {

               // throw;
            }
        }
       
        async Task GetUserInfo()
        {
            try
            {
                UserModel user = new UserModel();
                
                WebService web = new WebService();
                string userresult = await web.SendDataNoStaticAsync("GetUserProfile", "userID=" + App.AppUser.UserID);

                 if (userresult != "Error" && userresult != null && userresult.Length > 6)
                {
                    user = JsonConvert.DeserializeObject<UserModel>(userresult);
                    UserReloaded = true;

                    activity.IsVisible = false;
                    activity.IsRunning = false;
                    activity.IsEnabled = false;

                    tryButton.IsVisible = false;
                }
                else
                {
                    tryButton.IsVisible = true;
                    activity.IsVisible = true;
                    activity.IsRunning = true;
                    activity.IsEnabled = true;
                }

                UserName.Text ="@" + user.Username;
                Name.Text = user.Name + " " + user.Surname;
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int id = (int)btn.CommandParameter;

                Tuple<int, int> friend = new Tuple<int, int>(App.AppUser.UserID, id);

                string userresult = await WebService.SendDataAsync("UnfollowUser", "follow=" + JsonConvert.SerializeObject(friend));

                if (userresult == "true")
                {
                    await DisplayAlert("Delete Friend", "Friend deleted.", "OK");
                    await GetFriendList();
                }
            }
            catch (Exception)
            {

               // throw;
            }     
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var answer = await DisplayAlert("Logout", "Are you sure you want to Logout ?", "No", "Yes");

                if (!answer)
                {
                    Database.DeleteUser();
                    await Navigation.PushAsync(new Login());
                }
            }
            catch (Exception)
            {

                //throw;
            }      
        }

        private async void TryAgain_Clicked(object sender, EventArgs e)
        {
            try
            {
                activity.IsVisible = true;
                activity.IsRunning = true;
                activity.IsEnabled = true;
                await GetWishList();
                await GetUserInfo();
                await GetFriendList();
            }
            catch (Exception)
            {

               // throw;
            }
        }
    }
}
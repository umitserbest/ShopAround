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

namespace ShopAroundMobile.TabbedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FriendProfile : ContentPage
	{
        bool WishlistReloaded;
        bool userReload;
        bool followerReload;
        string Productpath = "https://shoparound.umitserbest.com/shopassets/products/";

        int UserID = 0;

        public FriendProfile (int UserId)
		{
			InitializeComponent ();
            UserID = UserId;

            if (!userReload)
            {
                GetUserInfo();
            }
            if(!followerReload)
            {
                FollowedUsers(UserID);
            }
            if(!WishlistReloaded)
            {
                GetWishList();
            }
        }

        async Task GetUserInfo()
        {
            try
            {
                UserModel user = new UserModel();
                WebService web = new WebService();
                
                string userresult = await web.SendDataNoStaticAsync("GetUserProfile", "userID=" + UserID);
                
                if (userresult != "Error" && userresult != null && userresult.Length > 6)
                {
                    user = JsonConvert.DeserializeObject<UserModel>(userresult);
                    UserName.Text = user.Name + " " + user.Surname;
                    User.Text = "@" + user.Username;
                    userReload = true;
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
            }
            catch (Exception ex)
            {
                // throw;
            }
        }

        async Task GetWishList()
        {
            try
            {
                UserImages.Children.Clear();
                List<ProductModel> products = new List<ProductModel>();

                string wishlistresult = await WebService.SendDataAsync("GetWishlist", "userID=" + UserID);

                if (wishlistresult != "Error" && wishlistresult != null && wishlistresult.Length > 6)
                {
                    products = JsonConvert.DeserializeObject<List<ProductModel>>(wishlistresult);
                    WishlistReloaded = true;

                    activity.IsVisible = false;
                    activity.IsRunning = false;
                    activity.IsEnabled = false;

                    tryButton.IsVisible = false;
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

                            Navigation.PushAsync(new PhotoDetailPage(product, true, "Profile"));
                        };
                        image.GestureRecognizers.Add(tapGestureRecognizer);
                        UserImages.Children.Add(image, k, j);
                        counter++;
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }
        
        async Task FollowedUsers(int shopId)
        {
            try
            {
                List<int> users = new List<int>();

                string userresult = await WebService.SendDataAsync("GetFriends", "userID=" + App.AppUser.UserID);

                if (userresult != "Error" && userresult != null && userresult.Length > 0 && userresult != "null")
                {
                    users = JsonConvert.DeserializeObject<List<int>>(userresult);
                    followerReload = true;
                }

                bool followed = false;

                if (users.Count > 0)
                {
                    foreach (int user in users)
                    {
                        if (user == UserID)
                        {
                            followed = true;
                            break;
                        }

                    }
                }

                if (followed)
                {
                    FollowBtn.Text = "Unfollow";
                    FollowBtn.BackgroundColor = Color.LightGray;
                    FollowBtn.TextColor = Color.Black;
                }
                else
                {
                    FollowBtn.Text = "Follow";
                    FollowBtn.BackgroundColor = Color.Orange;
                    FollowBtn.TextColor = Color.White;
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }

        public async void AddNotification()
        {
            try
            {
                NotificationModel notice = new NotificationModel();

                notice.SenderID = App.AppUser.UserID;
                notice.ReceiverID = UserID;

                string friendresult = await WebService.SendDataAsync("AddNotification","notification=" + JsonConvert.SerializeObject(notice));
                
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        private async void FollowButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (FollowBtn.Text == "Follow")
                {
                    Tuple<int, int> friendModel = new Tuple<int, int>(App.AppUser.UserID, UserID);


                    string followObject = JsonConvert.SerializeObject(friendModel);

                    string result = await WebService.SendDataAsync("FollowUser", "follow=" + followObject);

                    if (result == "true")
                    {
                        FollowBtn.Text = "Unfollow";
                        FollowBtn.BackgroundColor = Color.LightGray;
                        FollowBtn.TextColor = Color.Black;

                        AddNotification();
                        TabPageControl.profileTabbed.Trigger();
                    }
                }
                else if (FollowBtn.Text == "Unfollow")
                {
                    Tuple<int, int> friendModel2 = new Tuple<int, int>(App.AppUser.UserID, UserID);
                    string followObject2 = JsonConvert.SerializeObject(friendModel2);


                    string result2 = await WebService.SendDataAsync("UnfollowUser", "follow=" + followObject2);


                    if (result2 == "true")
                    {
                        FollowBtn.Text = "Follow";
                        FollowBtn.BackgroundColor = Color.Orange;
                        FollowBtn.TextColor = Color.White;

                        TabPageControl.profileTabbed.Trigger();
                    }
                }
            }
            catch (Exception)
            {

               // throw;
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
                await FollowedUsers(UserID);
                await GetUserInfo();
            }
            catch (Exception)
            {

               // throw;
            }
        }
    }
}
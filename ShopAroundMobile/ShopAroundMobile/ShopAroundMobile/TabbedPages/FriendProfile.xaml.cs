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

namespace ShopAroundMobile.TabbedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FriendProfile : ContentPage
	{
        int UserID = 0;
        public FriendProfile (int UserId)
		{
			InitializeComponent ();
            UserID = UserId;
            GetUserInfo();
            FollowedUsers(UserID);
            

        }

        async void GetUserInfo()
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
                }
                
               
                
            }
            catch (Exception ex)
            {
                 throw;
            }


        }

       
        async void FollowedUsers(int shopId)
        {
            try
            {

                List<int> users = new List<int>();

                string userresult = await WebService.SendDataAsync("GetFriends", "userID=" + App.AppUser.UserID);

                if (userresult != "Error" && userresult != null && userresult.Length > 0 && userresult != "null")
                {
                    users = JsonConvert.DeserializeObject<List<int>>(userresult);
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

                throw;
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
                throw;
            }


        }

        private async void FollowButton_Clicked(object sender, EventArgs e)
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
                    TabPageControl.noticeTabbed.GetNotification();
                    TabPageControl.profileTabbed.Reload();
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
                }
            }

        }
    }
}
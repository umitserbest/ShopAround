using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
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
        string Productpath = "https://shoparound.umitserbest.com/shopassets/products/";
        public Profile ()
		{
			InitializeComponent ();
            GetUserInfo();
            GetWishList();
            GetFriendList();
            //var tabView = new TabViewControl(new List<TabItem>()
            //  {
            //         new TabItem( 

            //              "Profile",
            //              new StackLayout()
            //              {
            //                  Children =
            //                  {
            //                     UserImages
            //                  },
            //                  BackgroundColor = Color.LightGray,
            //                  Padding = 10
            //              }),
            //           new TabItem(
            //                  "WishList",
            //                  new StackLayout()
            //                  {
            //                      Children =
            //                      {
            //                         WishList
            //                      },
            //                      BackgroundColor = Color.LightSalmon,
            //                      Padding = 10
            //                        })
            //                   });


            //tabView.VerticalOptions = LayoutOptions.End;
            //tabView.HeaderBackgroundColor = Color.White;
            //tabView.HeaderTabTextColor = Color.Gray;
            ////tabView.HeightRequest = 300;

            //MainGrid.Children.Add(tabView,0,3);



            //var mainLayout = new StackLayout();
            //mainLayout.Children.Add(layout);
            //mainLayout.Children.Add(tabView);
            //Content = mainLayout;
        }

        async void GetFriendList()
        {

            try
            {
                List<int> friend = new List<int>();
                List<UserModel> user = new List<UserModel>();

                string friendresult = await WebService.SendDataAsync("GetFriends", "userID=" + App.AppUser.UserID);

                if (friendresult != "Error" && friendresult != null && friendresult.Length > 0)
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
                throw;
            }


        }

        async void GetWishList()
        {
            try
            {
                List<ProductModel> products = new List<ProductModel>();

                string wishlistresult = await WebService.SendDataAsync("GetWishlist", "userID=" + App.AppUser.UserID);

                if (wishlistresult != "Error" && wishlistresult != null && wishlistresult.Length > 6)
                {
                    products = JsonConvert.DeserializeObject<List<ProductModel>>(wishlistresult);

                }
                for (int i = 0; i < products.Count + 1 / 2; i++)
                {
                    UserImages.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

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
                        UserImages.Children.Add(image, k, j);
                        counter++;


                        //var tapGestureRecognizer = new TapGestureRecognizer();
                        //tapGestureRecognizer.Tapped += (s, e) =>
                        //{
                        //    tapGestureRecognizer.NumberOfTapsRequired = 1;

                        //    var Image = s as Image;

                        //    var productDetail = Image?.BindingContext as ProductModel;

                        //    var vm = BindingContext as ShowcaseViewModel;

                        //    Navigation.PushAsync(new PhotoDetailPage(image.Source, productDetail, shop));
                        //    //Navigation.PushAsync(new PhotoDetailPage(image2.Source,shop,products));
                        //};
                        //image.GestureRecognizers.Add(tapGestureRecognizer);

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        async void GetUserInfo()
        {

            try
            {
                UserModel user = new UserModel();
                
                WebService web = new WebService();
                string userresult = await web.SendDataNoStaticAsync("GetUserProfile", "userID=" + App.AppUser.UserID);

                 if (userresult != "Error" && userresult != null && userresult.Length > 6)
                {
                    user = JsonConvert.DeserializeObject<UserModel>(userresult);
                }

                UserName.Text ="@" + user.Username;
                Name.Text = user.Name + " " + user.Surname;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = (int)btn.CommandParameter;

            Tuple<int,int> friend = new Tuple<int,int>(App.AppUser.UserID,id);
            
            string userresult = await WebService.SendDataAsync("UnfollowUser", "follow=" + JsonConvert.SerializeObject(friend));

            if (userresult == "true")
            {
               await DisplayAlert("Delete Friend", "Friend deleted.", "OK");
                GetFriendList();
            }

            
        }

    }
}
using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using ShopAroundMobile.ViewModels;
using ShopAroundMobile.Views;
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
    public partial class ShopProfile : ContentPage
    {
        string Logopath = "https://shoparound.umitserbest.com/shopassets/logo/";
        string Productpath = "https://shoparound.umitserbest.com/shopassets/products/";
        int shopID = 0;
        bool followedReload;
        bool shopReload;
        bool productReload;
        ShopModel shop;
        List<ProductModel> products;

        public ShopProfile(int shopId)
        {
            shopID = shopId;
            InitializeComponent();

            if(!followedReload)
            {
                FollowedShops(shopId);
            }

            if(!shopReload || !productReload)
            {
                GetShopInfo(shopId);
            }
        }
        
        async Task FollowedShops(int shopId)
        {
            List<ShopModel> shops = new List<ShopModel>();

            string shopresult = await WebService.SendDataAsync("GetShopsForTheFlow", "userID=" + App.AppUser.UserID); 

            if (shopresult != "Error" && shopresult != null && shopresult.Length > 6)
            {
                shops = JsonConvert.DeserializeObject<List<ShopModel>>(shopresult);
                followedReload = true;
            }

            bool followed = false;

            if(shops.Count > 0)
            {
                foreach (ShopModel shop in shops)
                {
                    if(shop.ShopID == shopId)
                    {
                        followed = true;
                        break;
                    }

                }
            }

            if(followed)
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

        async Task GetShopInfo(int shopId)
        {
            try
            {               
                WebService web = new WebService();

                if (!shopReload)
                {

                    shop = new ShopModel();

                    string shopresult = await web.SendDataNoStaticAsync("GetShopProfile", "shopID=" + shopId);

                    if (shopresult != "Error" && shopresult != null && shopresult.Length > 6)
                    {
                        shop = JsonConvert.DeserializeObject<ShopModel>(shopresult);
                        shopReload = true;
                    }

                }
                if (!productReload)
                {

                    products = new List<ProductModel>();

                    string productresult = await WebService.SendDataAsync("GetProductsOfShop", "shopID=" + shopId);


                    if (productresult != "Error" && productresult != null && productresult.Length > 6)
                    {
                        products = JsonConvert.DeserializeObject<List<ProductModel>>(productresult);
                        productReload = true;
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

                shopname.Text = shop.Name;
                ShopImg.Source = Logopath + shop.Logo;

                for (int i = 0; i < products.Count + 1 / 2; i++)
                {
                    ProductsGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });

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
                        ProductModel product = products[counter];
                        image.WidthRequest = 400;
                        image.Aspect = Aspect.AspectFill;



                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (s, e) =>
                        {
                            tapGestureRecognizer.NumberOfTapsRequired = 1;
                            

                             Navigation.PushAsync(new PhotoDetailPage(product,false,null));
                        };
                        image.GestureRecognizers.Add(tapGestureRecognizer);
                        ProductsGrid.Children.Add(image, k, j);
                        counter++;
                    }
                }
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
                string shopresult = await WebService.SendDataAsync("GetShopProfile", "shopID=" + shopID);
                ShopModel shop = new ShopModel();
                if (shopresult != null)
                {
                    shop = JsonConvert.DeserializeObject<ShopModel>(shopresult);
                }
                await DisplayAlert("Shop Information", "Shop :" + shop.Name + "\n" + "Phone :" + shop.Phone + "\n" + "City :" + shop.City + "\n" + "Adress :" + shop.Address, "OK");
            }
            catch (Exception)
            {

               // throw;
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {

            try
            {
                if (FollowBtn.Text == "Follow")
                {
                    FollowModel followModel = new FollowModel(shopID, App.AppUser.UserID);


                    string followObject = JsonConvert.SerializeObject(followModel);

                    string result = await WebService.SendDataAsync("FollowShop", "follow=" + followObject);

                    if (result == "true")
                    {
                        FollowBtn.Text = "Unfollow";
                        FollowBtn.BackgroundColor = Color.LightGray;
                        FollowBtn.TextColor = Color.Black;

                        TabPageControl.showcaseTabbed.Reload();
                    }
                }
                else if (FollowBtn.Text == "Unfollow")
                {
                    FollowModel followmodel2 = new FollowModel(shopID, App.AppUser.UserID);
                    string followObject2 = JsonConvert.SerializeObject(followmodel2);


                    string result2 = await WebService.SendDataAsync("UnfollowShop", "follow=" + followObject2);


                    if (result2 == "true")
                    {
                        FollowBtn.Text = "Follow";
                        FollowBtn.BackgroundColor = Color.Orange;
                        FollowBtn.TextColor = Color.White;

                        TabPageControl.showcaseTabbed.Reload();

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

                await GetShopInfo(shopID);
                await FollowedShops(shopID);
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}
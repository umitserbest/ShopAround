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
      
        public ShopProfile(int shopId)
        {
            shopID = shopId;
            InitializeComponent();
            GetShopInfo(shopId);
            FollowedShops(shopId);
        
        }
        
        async void FollowedShops(int shopId)
        {
            List<ShopModel> shops = new List<ShopModel>();

            string shopresult = await WebService.SendDataAsync("GetShopsForTheFlow", "userID=" + App.AppUser.UserID); // 2 yerine App.UserID; 

            if (shopresult != "Error" && shopresult != null && shopresult.Length > 6)
            {
                shops = JsonConvert.DeserializeObject<List<ShopModel>>(shopresult);
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

        async void GetShopInfo(int shopId)
        {

            try
            {
                ShopModel shop = new ShopModel();
                List<ProductModel> products = new List<ProductModel>();
               
                WebService web = new WebService();
                string shopresult = await web.SendDataNoStaticAsync("GetShopProfile", "shopID=" + shopId);

                string productresult = await WebService.SendDataAsync("GetProductsOfShop", "shopID=" + shopId);



                if (shopresult != "Error" && shopresult != null && shopresult.Length > 6)
                {
                    shop = JsonConvert.DeserializeObject<ShopModel>(shopresult);
                }

                if (productresult != "Error" && productresult != null && productresult.Length > 6)
                {
                    products = JsonConvert.DeserializeObject<List<ProductModel>>(productresult);
                  
                }

                shopname.Text = shop.Name;
                ShopImg.Source = Logopath + shop.Logo;
                //MainImg.Source = Logopath + shop.Logo;

                for (int i = 0; i < products.Count + 1 / 2; i++)
                {
                    ProductsGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

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
                
                throw;
            }


        }
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            string shopresult = await WebService.SendDataAsync("GetShopProfile", "shopID=" +4);
            ShopModel shop = new ShopModel();
            if (shopresult != null)
            {
                shop = JsonConvert.DeserializeObject<ShopModel>(shopresult);
            }
            await DisplayAlert("Shop Information","Shop :" + shop.Name + "\n" +"Phone :" + shop.Phone + "\n" +"City :" + shop.City + "\n" +"Adress :" + shop.Address, "OK");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            
            if (FollowBtn.Text == "Follow")
            {
                FollowModel followModel = new FollowModel(shopID, App.AppUser.UserID);
               // 2 yerine App.UserID; 

                string followObject = JsonConvert.SerializeObject(followModel);

                string result = await WebService.SendDataAsync("FollowShop", "follow=" + followObject);

                if (result == "true")
                {
                    FollowBtn.Text = "Unfollow";
                    FollowBtn.BackgroundColor = Color.LightGray;
                    FollowBtn.TextColor = Color.Black;
                }                
            }
            else if (FollowBtn.Text == "Unfollow")
            {
                FollowModel followmodel2 = new FollowModel(shopID, App.AppUser.UserID);// 2 yerine App.UserID; 
                string followObject2 = JsonConvert.SerializeObject(followmodel2);


                string result2 = await WebService.SendDataAsync("UnfollowShop", "follow=" + followObject2);


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
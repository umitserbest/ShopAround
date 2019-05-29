using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using ShopAroundMobile.TabbedPages;
using ShopAroundMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PhotoDetailPage : ContentPage
	{
        ShopModel shop;
        List<ProductModel> wishlistProducts = new List<ProductModel>();
        int productId;
        string Logopath = "https://shoparound.umitserbest.com/shopassets/logo/";
        string Productpath = "https://shoparound.umitserbest.com/shopassets/products/";
        string Link;

        public PhotoDetailPage (ProductModel products, bool wishlistVisible, string pageName)
		{
            InitializeComponent();
            GetWishlistInfo();
            if (wishlistVisible == false && pageName == "Explore")
            {
                Wishlist.IsVisible = true;
                Delete_Wishlist.IsVisible = false;
            }

            else if(wishlistVisible == true && pageName == "Profile")
            {
                Wishlist.IsVisible = false;
            }

            productId = products.ProductID;
            GetShop(products);
			
            Img.Source = Productpath + products.CoverImage;
            name.Text = products.Name;
            size.Text = products.Size;
            colour.Text = products.Color;
            Price.Text = products.Price.ToString();
            material.Text = products.Material;
            Link = products.PurchaseLink;
            
        }
        
        async void GetShop(ProductModel product)
        {
            try
            {
                string shopresult = await WebService.SendDataAsync("GetShopProfile", "shopID=" + product.ShopID);

                if (shopresult != "Error" && shopresult != null && shopresult.Length > 6 && shopresult != "null")
                {
                    shop = JsonConvert.DeserializeObject<ShopModel>(shopresult);
                    Brand.Text = shop.Name;
                    Logo.Source = Logopath + shop.Logo;
                }
            }
            catch (Exception)
            {
               // throw;
            }
        }

        private async void Delete_Wishlist_Clicked(object sender, EventArgs e)
        {
            try
            {
                Tuple<int, int> tuple = new Tuple<int, int>(App.AppUser.UserID, productId);
                
                string wishlist = await WebService.SendDataAsync("RemoveProductFromWishlist", "wishlist=" + JsonConvert.SerializeObject(tuple));

                if (wishlist != "Error" && wishlist != null && wishlist.Length > 3)
                {
                    if (wishlist == "true")
                    {
                        await DisplayAlert("Delete Wislist", "Product deleted in your wishlist.", "OK");
                        Wishlist.IsVisible = false;
                        TabPageControl.profileTabbed.Trigger();
                    }

                }
            }
            catch (Exception)
            {
               // throw;
            }  
        }

        private async void GetWishlistInfo()
        {
            try
            {
                string wishresult = await WebService.SendDataAsync("GetWishlist", "userID=" + App.AppUser.UserID);

                if (wishresult != "Error" && wishresult != null && wishresult.Length > 6)
                {
                    wishlistProducts = JsonConvert.DeserializeObject<List<ProductModel>>(wishresult);
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private async void Addd_Wishlist_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool isExistWishlist = false;

                foreach (var item in wishlistProducts)
                {
                    if (item.ProductID == productId)
                    {
                        isExistWishlist = true;
                    }
                }

                if (!isExistWishlist)
                {
                    string userObject = JsonConvert.SerializeObject(new Tuple<int, int>(productId, App.AppUser.UserID));
                    string result = await WebService.SendDataAsync("AddProductWishlist", "wishlist=" + userObject);

                    if (result == "true")
                    {
                        wishlistProducts.Add(new ProductModel() { ProductID = productId });
                        DependencyService.Get<IMessage>().Message("This product added to your Wishlist.");
                        TabPageControl.profileTabbed.Trigger();
                    }
                }
                else
                {
                    DependencyService.Get<IMessage>().Message("This product already in your wishlist.");
                }
            }
            catch (Exception)
            {
               // throw;
            }
        }
      
        private async void Brand_Clicked(object sender, EventArgs e)
        {          
            await Navigation.PushAsync(new ShopProfile(shop.ShopID));
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync(Link, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception)
            {
                //throw;
            }
        }
    }
}
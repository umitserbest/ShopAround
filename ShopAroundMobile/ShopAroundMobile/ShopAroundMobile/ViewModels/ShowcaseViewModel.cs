using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Model;
using ShopAroundMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShopAroundMobile.ViewModels
{
    public class ShowcaseViewModel : INotifyPropertyChanged
    {
        List<Tuple<int, int, int>> wishlist = new List<Tuple<int, int, int>>();
        string Logopath = "https://shoparound.umitserbest.com/shopassets/logo/";
        string Productpath = "https://shoparound.umitserbest.com/shopassets/products/";

        ListView list = new ListView();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }


        public ICommand RefreshCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsRefreshing = true;

                    GetFlowInfo(list);

                    IsRefreshing = false;
                });
            }
        }


        private async void GetFlowInfo(ListView listView)
        {
            List<ShowcaseModel> showcases = new List<ShowcaseModel>();
            List<ProductModel> products = new List<ProductModel>();
            List<ShopModel> shops = new List<ShopModel>();

            string productResult = await WebService.SendDataAsync("GetTheFlow", "userID=" + App.AppUser.UserID);

            string shopResult = await WebService.SendDataAsync("GetShopsForTheFlow", "userID=" + App.AppUser.UserID);

            
            if (productResult != "Error" && productResult != null && productResult.Length > 6)
            {
                try
                {

                    products = JsonConvert.DeserializeObject<List<ProductModel>>(productResult);
                    foreach (ProductModel product in products)
                    {
                        product.CoverImage = Productpath + product.CoverImage;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                
            }

            if (shopResult != "Error" && shopResult != null && shopResult.Length > 6)
            {
                try
                {
                    shops = JsonConvert.DeserializeObject<List<ShopModel>>(shopResult);
                    foreach (ShopModel shop in shops)
                    {
                        shop.Logo = Logopath + shop.Logo;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            if (products.Count > 0 && shops.Count > 0)
            {
                foreach (ProductModel product in products)
                {
                    foreach (ShopModel shop in shops)
                    {
                        if (product.ShopID == shop.ShopID && !showcases.Contains(new ShowcaseModel(product, shop)))
                        {
                            showcases.Add(new ShowcaseModel(product, shop));
                            break;
                        }
                    }
                }

                listView.ItemsSource = showcases;

                list = listView;
            }

        }

        public Command<ShowcaseModel> AddWishList
        {
            get
            {
                return new Command<ShowcaseModel>((showcase) =>
                {
                    AddWishListAsync(showcase.ProductID);
                    
                });
            }
        }

     
        private async void AddWishListAsync(int productID)
        {
            //bool addedProduct = false;
            //foreach (var item in wishlist)
            //{
            //    if (item.Item3 != productID)
            //    {
            //        string userObject = JsonConvert.SerializeObject(new Tuple<int, int>(productID, App.UserdId));
            //        string result = await WebService.SendDataAsync("AddProductWishlist", "wishlist=" + userObject);
            //        addedProduct = true;
            //    }
            //}
            //if (addedProduct)
            //{
            //    DependencyService.Get<IMessage>().Message("This product added to your Wishlist.");
            //}
            string userObject = JsonConvert.SerializeObject(new Tuple<int, int>(productID, App.AppUser.UserID));
            string result = await WebService.SendDataAsync("AddProductWishlist", "wishlist=" + userObject);
            DependencyService.Get<IMessage>().Message("This product added to your Wishlist.");
        }

        private async void GetWishlistInfo()
        {
            wishlist = new List<Tuple<int, int, int>>();

            string wishresult = await WebService.SendDataAsync("GetWishlist", "userID=" + App.AppUser.UserID); // 2 yerine App.UserID; 

            if (wishresult != "Error" && wishresult != null && wishresult.Length > 6)
            {
                wishlist = JsonConvert.DeserializeObject<List<Tuple<int, int, int>>>(wishresult);

            }

        }

        public ShowcaseViewModel()
        {

        }

        public ShowcaseViewModel(ListView listview)
        {
            GetWishlistInfo();
            GetFlowInfo(listview);
        }
        
    }
}

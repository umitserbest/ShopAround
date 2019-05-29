using Newtonsoft.Json;
using Plugin.Connectivity;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Model;
using ShopAroundMobile.Models;
using ShopAroundMobile.TabbedPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShopAroundMobile.ViewModels
{
    public class ShowcaseViewModel : INotifyPropertyChanged
    {
        bool IsConnected = CrossConnectivity.Current.IsConnected;
        List<ProductModel> wishlistProducts = new List<ProductModel>();

        string Logopath = "https://shoparound.umitserbest.com/shopassets/logo/";
        string Productpath = "https://shoparound.umitserbest.com/shopassets/products/";

        public static bool isLoading = false;
        public ListView list;
        public List<ShowcaseModel> Item = new List<ShowcaseModel>();

#region ListviewRefresh
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
#endregion

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;
                OnPropertyChanged("IsBusy");
                
            }
        }

        public async void LoadData(ListView LoadListview)
        {
            if (IsConnected == true)
            {
                if (IsBusy)
                    return;

                try
                {
                    IsBusy = true;

                    await GetWishlistInfo();
                    await GetFlowInfo(LoadListview);
                    
                    IsBusy = false;
                }
                catch (Exception e)
                {
                    DependencyService.Get<IMessage>().Message("No connection, please try again.");
                }
                finally
                {
                    IsBusy = false;
                }
            }
            else
            {
                DependencyService.Get<IMessage>().Message("No connection, please try again.");
            }
        }

        private async Task GetFlowInfo(ListView listView)
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
                    isLoading = true;

                }
                catch (Exception)
                {
                    //throw;
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
                    isLoading = true;

                }
                catch (Exception)
                {
                    //throw;
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
            try
            {
                bool isExistWishlist = false;

                foreach (var item in wishlistProducts)
                {
                    if (item.ProductID == productID)
                    {
                        isExistWishlist = true;
                    }
                }

                if (!isExistWishlist)
                {
                    string userObject = JsonConvert.SerializeObject(new Tuple<int, int>(productID, App.AppUser.UserID));
                    string result = await WebService.SendDataAsync("AddProductWishlist", "wishlist=" + userObject);

                    if (result == "true")
                    {
                        wishlistProducts.Add(new ProductModel() { ProductID = productID });
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

        private async Task GetWishlistInfo()
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
               // throw;
            }
        }        

        public ShowcaseViewModel(ListView listview)
        {
            LoadData(listview);            
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}

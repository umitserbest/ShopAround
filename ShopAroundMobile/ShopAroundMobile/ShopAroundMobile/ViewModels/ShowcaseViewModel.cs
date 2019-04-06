using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Model;
using ShopAroundMobile.Models;
using ShopAroundWeb.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ShopAroundMobile.ViewModels
{
    public class ShowcaseViewModel
    {
        private bool _productInfoVisible;
        public bool ProductInfoVisible
        {

            get
            {
                return _productInfoVisible;
            }
            set
            {
                _productInfoVisible = value;

                if(_productInfoVisible == true)
                {
                    // Show frame
                }
                else
                {
                    // Hide frame
                }
            }
        }

        string Logopath = "https://shoparound.umitserbest.com/shopassets/logo/";
        string Productpath = "https://shoparound.umitserbest.com/shopassets/products/";

        private async void GetFlowInfo(ListView listView)
        {
            string productResult = await WebService.SendDataAsync("GetTheFlow", "userID=" + App.UserdId);

            string shopResult = await WebService.SendDataAsync("GetShopsForTheFlow", "userID=" + App.UserdId);


            List<ShowcaseModel> showcases = new List<ShowcaseModel>();
            List<ProductModel> products = new List<ProductModel>();
            List<ShopModel> shops = new List<ShopModel>();


            if (productResult != null)
            {
                products = JsonConvert.DeserializeObject<List<ProductModel>>(productResult);
                foreach (ProductModel product in products)
                {
                    product.CoverImage = Productpath + product.CoverImage;
                }                
            }

            if (shopResult != null)
            {
                shops = JsonConvert.DeserializeObject<List<ShopModel>>(shopResult);
                foreach (ShopModel shop in shops)
                {
                    shop.Logo = Logopath + shop.Logo;  
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
            }

        }



        public ShowcaseViewModel()
        {

        }

        public ShowcaseViewModel(ListView listview)
        {
            GetFlowInfo(listview);
        }

        //public ObservableCollection<ShowcaseModel> Posts { get; set; }

        //public ShowcaseViewModel()
        //{
        //    Posts = new ObservableCollection<ShowcaseModel>();

        //    Posts.Add(new ShowcaseModel
        //    {
        //        ShopName="Mavi",
        //        Image = "https://upload.wikimedia.org/wikipedia/commons/2/28/Logo_of_Mavi.png"
        //    });

        //    Posts.Add(new ShowcaseModel
        //    {
        //        ShopName = "Zara",
        //        Image = "https://static.dezeen.com/uploads/2019/02/new-zara-logo-col-2-852x352.jpg"
        //    });

        //    Posts.Add(new ShowcaseModel
        //    {
        //        ShopName = "Adidas",
        //        Image = "https://i.ebayimg.com/images/g/LJYAAOSwjXRXbI-N/s-l300.jpg"
        //    });

        //    Posts.Add(new ShowcaseModel
        //    {
        //        ShopName = "Pull and Bear",
        //        Image = "https://upload.wikimedia.org/wikipedia/commons/4/4e/Pull_and_bear_logo_antiguo.jpg"
        //    });



        //}
    }
}

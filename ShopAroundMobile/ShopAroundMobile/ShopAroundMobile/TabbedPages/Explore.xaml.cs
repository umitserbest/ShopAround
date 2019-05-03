using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using ShopAroundMobile.Views;
using ShopAroundMobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShopAroundMobile.ViewModels;
using FFImageLoading.Forms;

namespace ShopAroundMobile.TabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Explore : ContentPage
    {
        int productPosition = 0;
        bool reloaded;

        public Explore()
        {
            InitializeComponent();
            //GetProductImagesAync(0);
        }


        private async void SearchBar_Focused(object sender, FocusEventArgs e)
        {
            await Navigation.PushAsync(new SearchTabControl());
        }

        List<ProductModel> Products = new List<ProductModel>();
        string Logopath = "https://shoparound.umitserbest.com/shopassets/logo/";
        string Productpath = "https://shoparound.umitserbest.com/shopassets/products/";

        public void Reload()
        {
            //productPosition = 0;

            //int rowCount = ProductsGrid.RowDefinitions.Count;

            //for (int i = 0; i < rowCount; i++)
            //{
            //    ProductsGrid.RowDefinitions.RemoveAt(i);

            //}

            if (!reloaded)
            {
                GetProductImagesAync(0);
                reloaded = true;
            }

          

        }

        private async void GetProductImagesAync(int StartRowPosition)
        {

            try
            {
                Tuple<int, int, int> tuple = new Tuple<int, int, int>(App.AppUser.UserID, 9, productPosition);

               

                string tupleJson = JsonConvert.SerializeObject(tuple);

                string result = await WebService.SendDataAsync("GetTheExplore", "explore=" + tupleJson);

                if (result != "Error" && result != null && result.Length > 6)
                {

                    Products = JsonConvert.DeserializeObject<List<ProductModel>>(result);

                    productPosition += 9;

                    for (int i = 0; i < (Products.Count + 2) / 3; i++)
                    {
                        ProductsGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(150) });                        
                    }

                    int counter = 0;

                    for (int j = StartRowPosition; j < ((Products.Count + 2) / 3) + StartRowPosition; j++)
                    {

                        for (int k = 0; k < 3; k++)
                        {
                            if (counter == Products.Count)
                            {
                                j = Products.Count + 1;
                                break;
                            }
                            //Image image = new Image();
                            CachedImage image = new CachedImage();
                            image.Source = Productpath + Products[counter].CoverImage;
                            image.Aspect = Aspect.AspectFill;
                            ProductModel product = Products[counter];

                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.Tapped += (s, e) =>
                            {
                                tapGestureRecognizer.NumberOfTapsRequired = 1;

                                Navigation.PushAsync(new PhotoDetailPage(product, false, "Explore"));
                               
                            };
                            image.GestureRecognizers.Add(tapGestureRecognizer);
                            ProductsGrid.Children.Add(image, k, j);
                            counter++;
                            
                        }
                        
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private async void CategoryTapped(int id)
        {
            try
            {
                ProductsGrid.Children.Clear();

                Tuple<int, int> tuple = new Tuple<int, int>(App.AppUser.UserID, id);

                string signUpObject = JsonConvert.SerializeObject(tuple);

                string result = await WebService.SendDataAsync("GetTheExploreByProductType", "items=" + signUpObject);


                if (result != "Error" && result != null && result.Length > 6)
                {

                    Products = JsonConvert.DeserializeObject<List<ProductModel>>(result);

                    for (int i = 0; i < (Products.Count + 2) / 3; i++)
                    {
                        ProductsGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(150) });
                    }

                    int counter = 0;

                    for (int j = 0; j < (Products.Count + 2) / 3; j++)
                    {

                        for (int k = 0; k < 3; k++)
                        {
                            if (counter == Products.Count)
                            {
                                j = Products.Count + 1;
                                break;
                            }
                            //Image image = new Image();
                            CachedImage image = new CachedImage();
                            image.Source = Productpath + Products[counter].CoverImage;
                            image.Aspect = Aspect.AspectFill;


                            ProductModel product = Products[counter];
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.Tapped += (s, e) =>
                            {
                                tapGestureRecognizer.NumberOfTapsRequired = 1;

                                Navigation.PushAsync(new PhotoDetailPage(product, true, "Explore"));
                            };
                            image.GestureRecognizers.Add(tapGestureRecognizer);
                            ProductsGrid.Children.Add(image, k, j);
                            counter++;
                        }


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void Location_Tapped(object sender, EventArgs e)
        {
           // CategoryTapped();
        }

        private void Pants_Tapped(object sender, EventArgs e)
        {
          
            CategoryTapped(4);
            
        }

        private void Accessories_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(8);
        }

        private void Shoes_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(1);
        }

        private void Bags_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(2);
        }

        private void Tshirts_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(1008);
        }

        private void Skirts_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(3);
        }

        private void Jackets_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(6);
        }

        private void Dress_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(7);
        }

        private void Others_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(9);
        }

        private void LoadMore_Clicked(object sender, EventArgs e)
        {
            GetProductImagesAync(ProductsGrid.RowDefinitions.Count);
        }
    }
}
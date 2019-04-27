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

namespace ShopAroundMobile.TabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Explore : ContentPage
    {
        public Explore()
        {
            InitializeComponent();
            GetProductImagesAync();
           //BindingContext = new ExploreViewModel();
        }

        private async void SearchBar_Focused(object sender, FocusEventArgs e)
        {
            await Navigation.PushAsync(new SearchTabControl());
        }

        List<ProductModel> Products = new List<ProductModel>();
        string Logopath = "https://shoparound.umitserbest.com/shopassets/logo/";
        string Productpath = "https://shoparound.umitserbest.com/shopassets/products/";
       

        private async void GetProductImagesAync()
        {
            ProductModel signUpModel = new ProductModel();
            string signUpObject = JsonConvert.SerializeObject(signUpModel);

            string result = await WebService.SendDataAsync("GetTheExplore", null);

            if (result != "Error" && result != null && result.Length > 6)
            {

                Products = JsonConvert.DeserializeObject<List<ProductModel>>(result);

                for (int i = 0; i < Products.Count + 1 / 2; i++)
                {
                    ProductsGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(150) });


                }

                int counter = 0;

                for (int j = 0; j < Products.Count + 1 / 2; j++)
                {

                    for (int k = 0; k < 3; k++)
                    {
                        if (counter == Products.Count)
                        {
                            j = Products.Count + 1;
                            break;
                        }
                        Image image = new Image();
                        image.Source = Productpath + Products[counter].CoverImage;
                        image.Aspect = Aspect.AspectFill;
                        ProductsGrid.Children.Add(image, k, j);
                        counter++;


                    }


                }
            }


        }

        private async void CategoryTapped(int id)
        {
            ProductsGrid.Children.Clear();

            Tuple<int, int> tuple = new Tuple<int, int>(App.AppUser.UserID,id);

            string signUpObject = JsonConvert.SerializeObject(tuple);

            string result = await WebService.SendDataAsync("GetTheExploreByProductType", "items=" + signUpObject);


            if (result != "Error" && result != null && result.Length > 6)
            {

                Products = JsonConvert.DeserializeObject<List<ProductModel>>(result);

                for (int i = 0; i < Products.Count + 1 / 2; i++)
                {
                    ProductsGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(150) });
                }

                int counter = 0;

                for (int j = 0; j < Products.Count + 1 / 2; j++)
                {

                    for (int k = 0; k < 3; k++)
                    {
                        if (counter == Products.Count)
                        {
                            j = Products.Count + 1;
                            break;
                        }
                        Image image = new Image();
                        
                        image.Source = Productpath + Products[counter].CoverImage;
                        image.Aspect = Aspect.AspectFill;
                        ProductsGrid.Children.Add(image, k, j);
                        counter++;


                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (s, e) =>
                        {
                            tapGestureRecognizer.NumberOfTapsRequired = 1;

                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "imageTapped");

                            //Navigation.PushAsync(new PhotoDetailPage(image.Source,));
                            
                        };
                        image.GestureRecognizers.Add(tapGestureRecognizer);

                    }


                }
            }


        }

        private void Location_Tapped(object sender, EventArgs e)
        {
           // CategoryTapped();
        }

        private void Pants_Tapped(object sender, EventArgs e)
        {
          
            CategoryTapped(1);
            
        }

        private void Accessories_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(2);
        }

        private void Shoes_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(3);
        }

        private void Bags_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(4);
        }

        private void Tshirts_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(5);
        }

        private void Skirts_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(6);
        }

        private void Jackets_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(7);
        }

        private void Dress_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(8);
        }

        private void Others_Tapped(object sender, EventArgs e)
        {
            CategoryTapped(9);
        }
    }
}
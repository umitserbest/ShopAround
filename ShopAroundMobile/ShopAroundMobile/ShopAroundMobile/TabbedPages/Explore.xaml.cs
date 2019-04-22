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

namespace ShopAroundMobile.TabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Explore : ContentPage
    {
        public Explore()
        {
            InitializeComponent();
            GetProductImagesAync();
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
    }
}
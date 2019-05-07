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
using Plugin.Connectivity;

namespace ShopAroundMobile.TabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Explore : ContentPage
    {
        int productPosition = 0;
        int StartRowPosition = 0;
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

        bool IsConnected = CrossConnectivity.Current.IsConnected;

        List<ProductModel> Products = new List<ProductModel>();
        //string Logopath = "https://shoparound.umitserbest.com/shopassets/logo/";
        string Productpath = "https://shoparound.umitserbest.com/shopassets/products/";

        public async void Reload()
        {  
            if (!reloaded)
            {
                await GetProductImagesAync();
                
            }   
        }

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

        //public async Task LoadData()
        //{
        //    if (IsConnected == true)
        //    {

        //        if (IsBusy)
        //            return;

        //        try
        //        {
        //            IsBusy = true;

        //            await GetProductImagesAync();
                   

        //            IsBusy = false;
        //        }
        //        catch (Exception e)
        //        {
        //            DependencyService.Get<IMessage>().Message("No connection, please try again.");
        //        }
        //        finally
        //        {
        //            IsBusy = false;
        //        }

        //    }

        //    else
        //    {
        //        DependencyService.Get<IMessage>().Message("No connection, please try again.");

        //    }
        //}

        private async Task GetProductImagesAync()
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
                            image.WidthRequest = 150;
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
                    LoadBtn.IsVisible = true;
                    activity.IsVisible = false;
                    reloaded = true;
                }
                else
                {
                    LoadBtn.IsVisible = false;
                    tryButton.IsVisible = true;
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
                ProductsGrid.RowDefinitions.Clear();
                List<RowDefinition> rows = new List<RowDefinition>();

                foreach (var row in ProductsGrid.RowDefinitions)
                {
                    rows.Add(row);

                }

                foreach (var row in rows)
                {
                    ProductsGrid.RowDefinitions.Remove(row);
                }

                Tuple<int, int> tuple = new Tuple<int, int>(App.AppUser.UserID, id);

                string signUpObject = JsonConvert.SerializeObject(tuple);

                string result = await WebService.SendDataAsync("GetTheExploreByProductType", "items=" + signUpObject);


                if (result != "Error" && result != null && result.Length > 6)
                {

                    Products = JsonConvert.DeserializeObject<List<ProductModel>>(result);

                    StartRowPosition = Products.Count;                    

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

                                Navigation.PushAsync(new PhotoDetailPage(product, false, "Explore"));
                            };
                            image.GestureRecognizers.Add(tapGestureRecognizer);
                            ProductsGrid.Children.Add(image, k, j);
                            counter++;

                        }


                    }
                    LoadBtn.IsVisible = true;
                    activity.IsVisible = false;                    
                }
                else
                {
                    //tryButton.IsVisible = true;
                }
            }
            catch (Exception)
            {

                //throw;
            }


        }


        private async void LocationTapped()
        {
            try
            {
                ProductsGrid.RowDefinitions.Clear();
                List<RowDefinition> rows = new List<RowDefinition>();

                foreach (var row in ProductsGrid.RowDefinitions)
                {
                    rows.Add(row);

                }

                foreach (var row in rows)
                {
                    ProductsGrid.RowDefinitions.Remove(row);
                }

                

                string result = await WebService.SendDataAsync("GetTheExploreByCity", "userID=" + App.AppUser.UserID);


                if (result != "Error" && result != null && result.Length > 6)
                {

                    Products = JsonConvert.DeserializeObject<List<ProductModel>>(result);

                    StartRowPosition = Products.Count;

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

                                Navigation.PushAsync(new PhotoDetailPage(product, false, "Explore"));
                            };
                            image.GestureRecognizers.Add(tapGestureRecognizer);
                            ProductsGrid.Children.Add(image, k, j);
                            counter++;

                        }


                    }
                    LoadBtn.IsVisible = true;
                    activity.IsVisible = false;
                }
                else
                {
                    //tryButton.IsVisible = true;
                }
            }
            catch (Exception)
            {

                //throw;
            }


        }

        private void Location_Tapped(object sender, EventArgs e)
        {
           LocationTapped();
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

        private async void LoadMore_Clicked(object sender, EventArgs e)
        {
            LoadBtn.IsVisible = false;
            activity.IsEnabled = true;
            activity.IsRunning = true;
            activity.IsVisible = true;

            StartRowPosition = ProductsGrid.RowDefinitions.Count;
            await GetProductImagesAync();

            //LoadBtn.IsVisible = true;
            //activity.IsEnabled = false;
            //activity.IsRunning = false;
            //activity.IsVisible = false;
        }

        private async void TryAgain_Clicked(object sender, EventArgs e)
        {
            StartRowPosition = 0;
            await GetProductImagesAync();
        }
    }
}
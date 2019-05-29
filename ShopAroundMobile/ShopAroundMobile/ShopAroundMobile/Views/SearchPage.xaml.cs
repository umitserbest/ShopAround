using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using ShopAroundMobile.TabbedPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        string Logopath = "https://shoparound.umitserbest.com/shopassets/logo/";

        public SearchPage()
        {
            InitializeComponent();
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string result = await WebService.SendDataAsync("GetShopsByName", "name=" + searchBar.Text);

                if (result != "Error" && result != null && result.Length > 6)
                {

                    List<ShopModel> shops = JsonConvert.DeserializeObject<List<ShopModel>>(result);
                    foreach (var item in shops)
                    {
                        item.Logo = Logopath + item.Logo;
                    }
                    listView.ItemsSource = shops;
                }
            }
            catch (Exception)
            {
               // throw;
            }
        }
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int id = (int)btn.CommandParameter;

                await Navigation.PushAsync(new ShopProfile(id));
            }
            catch (Exception)
            {
               // throw;
            }
        }
    }
}
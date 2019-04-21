using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Model;
using ShopAroundMobile.Models;
using ShopAroundWeb.Models;
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
    public class SuggestShopViewModel : INotifyPropertyChanged
    {
        
        public static List<FollowModel> checkedShopId = new List<FollowModel>();
        

        string path = "https://shoparound.umitserbest.com/shopassets/logo/";

        private async void GetShops(ListView listView)
        {
            string result = await WebService.SendDataAsync("GetShopsForFollow", null);

            if (result != null)
            {
                List<ShopModel> shops = JsonConvert.DeserializeObject<List<ShopModel>>(result);
                foreach (ShopModel shop in shops)
                {
                    shop.Logo = path + shop.Logo;
                    
                }
                listView.ItemsSource = shops;
            }            
        }
        
        public SuggestShopViewModel()
        {
            
        }
      
        public SuggestShopViewModel(ListView listView)
        {
            GetShops(listView);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}

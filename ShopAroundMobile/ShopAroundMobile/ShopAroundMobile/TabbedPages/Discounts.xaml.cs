using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using ShopAroundMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.TabbedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Discounts : ContentPage
	{
        bool reloaded;
        string Logopath = "https://shoparound.umitserbest.com/shopassets/logo/";
        public Discounts ()
		{
			InitializeComponent (); 
        }

        public async void Reload()
        {
            if (!reloaded)
            {
               await GetDiscount();

                listView.RefreshCommand = new Command(async() =>
                {
                    await GetDiscount();
                    listView.IsRefreshing = false;

                });
            }
        }
        
        
      

        public async Task GetDiscount()
        {
            try
            {
                List<DiscountModel> discounts = new List<DiscountModel>();

                string discountresult = await WebService.SendDataAsync("GetDiscounts", "userID=" + App.AppUser.UserID);
                
                if (discountresult != "Error" && discountresult != null && discountresult.Length > 0 && discountresult != "null")
                {
                    discounts = JsonConvert.DeserializeObject<List<DiscountModel>>(discountresult);

                    foreach (var item in discounts)
                    {
                        item.ShopLogo = Logopath + item.ShopLogo;
                    }
                    
                    reloaded = true;
                }
                listView.ItemsSource = discounts;
            }

            catch (Exception ex)
            {
               // throw;
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listview = sender as ListView;

            if (e.SelectedItem is DiscountModel discount)
            {
                listView.SelectedItem = null;
                Navigation.PushAsync(new DiscountsDetail(discount));                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
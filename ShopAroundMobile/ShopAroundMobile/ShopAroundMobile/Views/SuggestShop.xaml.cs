using Newtonsoft.Json;
using Plugin.InputKit.Shared.Controls;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using ShopAroundMobile.TabbedPages;
using ShopAroundMobile.ViewModels;
using ShopAroundMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuggestShop : ContentPage, INotifyPropertyChanged
    {
        public SuggestShop()
        {           
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //DependencyService.Get<IMessage>().Message("You need to choose at least 5 shops.");
            SuggestShopViewModel suggest = new SuggestShopViewModel(listView);
        }

        private void Checkbox_CheckChanged(object sender, EventArgs e)
        {

            CheckBox shopId = (CheckBox)sender;

            if (shopId.IsChecked)
            {
                SuggestShopViewModel.checkedShopId.Add(new FollowModel(int.Parse(shopId.Text),App.AppUser.UserID));
                counterlbl.Text = SuggestShopViewModel.checkedShopId.Count.ToString();
                OnPropertyChanged("CheckedShops");
                //if(SuggestShopViewModel.checkedShopId.Count > 5)
                //{
                //    //menuItem.IsEnabled = true;
                //    NextBtn.IsEnabled = true;
                //}

                //else
                //{
                //    //menuItem.IsEnabled = false;
                //    NextBtn.IsEnabled = false;
                //}


            }
            else
            {
                SuggestShopViewModel.checkedShopId.RemoveAll(r => r.ShopID == int.Parse(shopId.Text));
                counterlbl.Text = SuggestShopViewModel.checkedShopId.Count.ToString();
                OnPropertyChanged("CheckedShops");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                // List<Tuple<int, int>> checkedShops = SuggestShopViewModel.checkedShopId;

                List<FollowModel> checkedShops = SuggestShopViewModel.checkedShopId;
                string userObject = JsonConvert.SerializeObject(checkedShops);

                string result = await WebService.SendDataAsync("FollowShops", "follows=" + userObject);

                if (result == "true")
                {
                    await Navigation.PushAsync(new TabPageControl());
                    //await Navigation.PushAsync(new Showcase());
                    //await Navigation.PushAsync(new ShopProfile(4));
                }
                else
                {
                    await DisplayAlert("ShopAround", "Error", "OK");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("error",ex.Message,"ok");
            }
        }
    }
}
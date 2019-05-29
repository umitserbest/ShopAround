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
            DependencyService.Get<IMessage>().Message("You need to choose at least 3 shops.");
            SuggestShopViewModel suggest = new SuggestShopViewModel(listView);
        }

        private void Checkbox_CheckChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox shopId = (CheckBox)sender;

                if (shopId.IsChecked)
                {
                    SuggestShopViewModel.checkedShopId.Add(new FollowModel(int.Parse(shopId.Text), App.AppUser.UserID));
                    counterlbl.Text = SuggestShopViewModel.checkedShopId.Count.ToString();
                    OnPropertyChanged("CheckedShops");
                }
                else
                {
                    SuggestShopViewModel.checkedShopId.RemoveAll(r => r.ShopID == int.Parse(shopId.Text));
                    counterlbl.Text = SuggestShopViewModel.checkedShopId.Count.ToString();
                    OnPropertyChanged("CheckedShops");
                }
                if (SuggestShopViewModel.checkedShopId.Count > 2)
                {
                    NextBtn.IsVisible = true;
                }

            }
            catch (Exception)
            {
               // throw;
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
                if (SuggestShopViewModel.checkedShopId.Count > 2)
                {
                    NextBtn.IsVisible = true;


                    List<FollowModel> checkedShops = SuggestShopViewModel.checkedShopId;
                    string userObject = JsonConvert.SerializeObject(checkedShops);

                    string result = await WebService.SendDataAsync("FollowShops", "follows=" + userObject);

                    if (result == "true")
                    {
                        await Navigation.PushAsync(new TabPageControl());
                    }
                    else
                    {
                        await DisplayAlert("ShopAround", "Error", "OK");
                    }
                }
                else
                {
                    DependencyService.Get<IMessage>().Message("You need to choose at least 3 shops.");
                }
            }
            catch(Exception ex)
            {
                //await DisplayAlert("error",ex.Message,"ok");
            }
        }
    }
}
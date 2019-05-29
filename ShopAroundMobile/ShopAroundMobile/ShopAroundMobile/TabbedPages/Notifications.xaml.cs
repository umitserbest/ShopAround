using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using ShopAroundMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xam.Plugin.TabView;
using Xamarin.Forms;


namespace ShopAroundMobile.TabbedPages
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Notifications : ContentPage , INotifyPropertyChanged
	{
        bool reloaded;

        public Notifications()
        {
            InitializeComponent();
        }

        public async void Reload()
        {
            if (!reloaded)
            {
                await GetNotification();
                listView.RefreshCommand = new Command(async () =>
                {
                    await GetNotification();
                    listView.IsRefreshing = false;

                });
            }
        }
        

        public async Task GetNotification()
        {
            try
            {             
                List<NotificationModel> user = new List<NotificationModel>();

                string friendresult = await WebService.SendDataAsync("GetNotifications", "userID=" + App.AppUser.UserID);

                if (friendresult != "Error" && friendresult != null && friendresult.Length > 0 && friendresult != "null")
                {
                    user = JsonConvert.DeserializeObject<List<NotificationModel>>(friendresult);
                   
                    reloaded = true;
                }
               

                listView.ItemsSource = user;                
            }
            catch (Exception ex)
            {
                //throw;
            }            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }        

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var listview = sender as ListView;

                if (e.SelectedItem is NotificationModel user)
                {
                    listView.SelectedItem = null;
                    Navigation.PushAsync(new FriendProfile(user.SenderID));

                }
            }
            catch (Exception)
            {
               // throw;
            }
        }
      
    }
}
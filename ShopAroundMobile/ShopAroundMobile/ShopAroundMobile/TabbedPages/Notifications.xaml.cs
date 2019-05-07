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

        public void Reload()
        {
            if (!reloaded)
            {
                GetNotification();               
            }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
        
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsRefreshing = true;

                    GetNotification();

                    IsRefreshing = false;
                });
            }
        }

        public async void GetNotification()
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
                throw;
            }            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
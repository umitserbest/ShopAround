using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.TabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiscountsDetail : ContentPage
    {
        bool IsFinished = false;
        public int hour;
        public int counter;
        public int mins;
        public int isTimerCancel;
        public int DiscountID;
        public DiscountsDetail(DiscountModel discount)
        {
            InitializeComponent();
            Countdown(discount);
            image.Source = discount.ShopLogo;
            ShopName.Text = discount.ShopName;
            DiscountID = discount.DiscountID;
            Detail.Text = discount.Details;
            GetCodeButton.IsVisible = false;
        }

        private void Countdown(DiscountModel discount)
        {
            TimeSpan value = discount.Date.Subtract(DateTime.Now);
            
            hour = value.Hours;
            counter = 0;
            mins = value.Minutes;
            isTimerCancel = 0;
            StartTimer(hour, mins, counter);
        }
        

        public void StartTimer(int h, int m, int sec)
        {
            hour = h;
            mins = m;
            counter = sec;
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                if (isTimerCancel == 1)
                {
                    return false;
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        counter = counter - 1;
                        if (counter < 0)
                        {
                            counter = 59;
                            mins = mins - 1;
                            if (mins < 0)
                            {
                                mins = 59;
                                hour = hour - 1;
                                if (hour < 0)
                                {
                                    hour = 0;
                                    mins = 0;
                                    counter = 0;
                                }
                            }
                        }

                        lblTime.Text = string.Format("{0:00}:{1:00}:{2:00}", hour, mins, counter);
                    });
                    if (hour == 0 && mins == 0 && counter == 0)
                    {
                        IsFinished = true;
                        return false;
                    }
                    else
                    {
                        GetCodeButton.IsVisible = true;
                        return true;
                    }
                }
            });
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(IsFinished == true)
            {
                DependencyService.Get<IMessage>().Message("You are late, the discount finished.");
                GetCodeButton.IsVisible = false;
            }
            else
            {
                Tuple<int, int> discount = new Tuple<int, int>(App.AppUser.UserID, DiscountID);

                string code = await WebService.SendDataAsync("GetDiscountCode", "discountCode=" + JsonConvert.SerializeObject(discount));
                                
                if(code != null && code != "Error" && code.Length == 8)
                {
                    await DisplayAlert("Discount Code", code, "OK");

                }
            }
        }
    }
}
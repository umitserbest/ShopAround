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
        
        public int hour;
        public int counter;
        public int mins;
        public int isTimerCancel;
        public string code;
        public DiscountsDetail(DiscountModel discount)
        {
            InitializeComponent();
            Countdown(discount);
            image.Source = discount.ShopLogo;
            ShopName.Text = discount.ShopName;
            code = discount.Code;
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
                        
                       //DisplayAlert("Exam", "Exam Time Over", "Close");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            });
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
             await DisplayAlert("Discount Code",code, "OK");
        }
    }
}
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
		public DiscountsDetail ()
		{
			InitializeComponent ();
            timer(20);
		}

        private void timer(double time)
        {

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {

                time -= 1;

                lblTime.Text = String.Format("{0}", time);

                if (time == 0.00)

                {

                    DisplayAlert("Süre Doldu", "Geri sayım süresi bitti!", "Ok");

                    return false;

                }

                return true;

            });
        }
        //Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        //{

        //    Device.BeginInvokeOnMainThread(() =>
        //    lblTime.Text = DateTime.Now.ToString("HH:mm:ss")
        //    );

        //    return true;
        //});

    }
}
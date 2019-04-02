using ShopAroundMobile.Carousel;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarouselTest : ContentPage 
	{
        myItemSource _vm;

        public CarouselTest ()
		{
			InitializeComponent ();

            Title = "Carouselview";

            //BindingContext = _vm = new myItemSource();

            BindingContext = new carouselVm();
           
        }

        void Handle_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            Debug.WriteLine("Position " + e.NewValue + " selected.");
        }

        void Handle_Scrolled(object sender, CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs e)
        {
            Debug.WriteLine("Scrolled to " + e.NewValue + " percent.");
            Debug.WriteLine("Direction = " + e.Direction);
        }

    }
}
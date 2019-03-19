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
    public partial class ShopProfile : ContentPage
    {
        public ShopProfile()
        {
            InitializeComponent();

            //var titleView = new Slider { HeightRequest = 44, WidthRequest = 300 };
            //NavigationPage.SetTitleView(this, BackgroundColor);
        }
    }
}
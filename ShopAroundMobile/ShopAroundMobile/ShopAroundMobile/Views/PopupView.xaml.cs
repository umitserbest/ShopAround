using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using ShopAroundMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupView : PopupPage
	{
        ProductModel product = new ProductModel();
        string Productpath = "https://shoparound.umitserbest.com/shopassets/products/";

        public PopupView (Models.ShowcaseModel showcase)
		{
			InitializeComponent ();

            name.Text = showcase.Name;
            material.Text = showcase.Material;
            brand.Text = showcase.Brand;
            color.Text = showcase.Color;
            size.Text = showcase.Size;
            price.Text = showcase.Price.ToString();

            LargeImage.Source = showcase.CoverImage;
            Image1.Source = Productpath + showcase.Image1;
            Image2.Source = Productpath + showcase.Image2;
            Image3.Source = Productpath + showcase.Image3;
        }

        private void CloseTheInfo_Tapped(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(true);
        }

        private void Image1_Tapped(object sender, EventArgs e)
        {
            LargeImage.Source = Image1.Source;
        }

        private void Image2_Tapped(object sender, EventArgs e)
        {
            LargeImage.Source = Image2.Source;
        }

        private void Image3_Tapped(object sender, EventArgs e)
        {
            LargeImage.Source = Image3.Source;
        }
    }
}
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
	public partial class PhotoDetailPage : ContentPage
	{
        string Logopath = "https://shoparound.umitserbest.com/shopassets/logo/";

        public PhotoDetailPage (ImageSource image, ProductModel products, ShopModel shop)
		{
			InitializeComponent ();
            Img.Source = image;
            //name.Text = products.Name;
            //size.Text = products.Size;
            //Logo.Source = Logopath + shop.Logo;
            // Brand.Text = shop.Name;
            
            //foreach (ProductModel product in products)
            //{
            //    name.Text = product.Name;
            //    size.Text = product.Size;
            //    material.Text = product.Material;
            //}
            
        }
	}
}
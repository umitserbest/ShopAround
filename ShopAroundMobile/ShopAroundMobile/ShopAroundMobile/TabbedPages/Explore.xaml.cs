using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Model;
using ShopAroundWeb.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.TabbedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Explore : ContentPage
	{
      

        public Explore ()
		{
           
          
            InitializeComponent();
            BindingContext = new ExploreViewModel();
        }


    }
}
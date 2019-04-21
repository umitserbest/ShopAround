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
	public partial class FriendProfile : ContentPage
	{
        int shopID = 4;
        public FriendProfile ()
		{
			InitializeComponent ();
		}

        private async void FollowButton_Clicked(object sender, EventArgs e)
        {
            FollowsModel followmodel = new FollowsModel(shopID, App.UserdId);// 2 yerine App.UserID; 
            string followObject = JsonConvert.SerializeObject(followmodel);


            string result = await WebService.SendDataAsync("UnfollowShop", "follow=" + followObject);

        }
    }
}
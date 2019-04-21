using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ShopAroundMobile.Droid.Renderers;

[assembly: Xamarin.Forms.Dependency(typeof(MeesageAndroid))]
namespace ShopAroundMobile.Droid.Renderers
{
    public class MeesageAndroid : IMessage
    {
        public void Message(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}
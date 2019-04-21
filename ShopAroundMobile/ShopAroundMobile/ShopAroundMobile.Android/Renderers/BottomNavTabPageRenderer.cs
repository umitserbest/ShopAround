using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using ShopAroundMobile;
using ShopAroundMobile.Droid;
using ShopAroundMobile.Droid.Renderers;
using ShopAroundMobile.TabbedPages;
using ShopAroundMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(TabPageControl), typeof(BottomNavTabPageRenderer))]
namespace ShopAroundMobile.Droid.Renderers
{
    public class BottomNavTabPageRenderer : TabbedPageRenderer
    {
        private bool _isShiftModeSet;

        public BottomNavTabPageRenderer(Context context)
            : base(context)
        {

        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            try
            {
                if (!_isShiftModeSet)
                {
                    var children = GetAllChildViews(ViewGroup);

                    if (children.SingleOrDefault(x => x is BottomNavigationView) is BottomNavigationView bottomNav)
                    {
                        bottomNav.SetShiftMode(false, false);
                        _isShiftModeSet = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error setting ShiftMode: {e}");
            }
        }

        private List<View> GetAllChildViews(View view)
        {
            if (!(view is ViewGroup group))
            {
                return new List<View> { view };
            }

            var result = new List<View>();

            for (int i = 0; i < group.ChildCount; i++)
            {
                var child = group.GetChildAt(i);

                var childList = new List<View> { child };
                childList.AddRange(GetAllChildViews(child));

                result.AddRange(childList);
            }

            return result.Distinct().ToList();
        }
    }
}
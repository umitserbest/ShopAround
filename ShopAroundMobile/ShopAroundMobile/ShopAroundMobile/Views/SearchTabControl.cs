using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ShopAroundMobile.Views
{
    public class SearchTabControl : TabbedPage
    {
        public SearchTabControl()
        {
            BarBackgroundColor = Color.White;
            BarTextColor = Color.Gray;

            Children.Add(new SearchPage());
            Children.Add(new FriendSearchPage());
        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

        }
    }
}

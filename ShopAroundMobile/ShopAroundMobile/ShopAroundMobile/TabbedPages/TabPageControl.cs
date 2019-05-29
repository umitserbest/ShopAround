using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;


namespace ShopAroundMobile.TabbedPages
{
    public class TabPageControl : Xamarin.Forms.TabbedPage
    {
        public static Showcase showcaseTabbed;
        public static Explore exploreTabbed;
        public static NotificationTabControl notificationTabbed;
        public static Profile profileTabbed;
        public static Notifications noticeTabbed;

        public TabPageControl()
        {          
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            showcaseTabbed = new Showcase();
            exploreTabbed = new Explore();
            notificationTabbed = new NotificationTabControl();
            profileTabbed = new Profile();

            Children.Add(showcaseTabbed);
            Children.Add(exploreTabbed);
            Children.Add(notificationTabbed);
            Children.Add(profileTabbed);
            
            BarTextColor = Color.Coral;
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetBarSelectedItemColor(this, Color.Coral);

            CurrentPageChanged += (object sender, EventArgs e) =>
            {
                int i = Children.IndexOf(this.CurrentPage);
                switch (i)
                {
                    case 0:
                        Showcase showcase = (Showcase)CurrentPage;
                        showcase.Reload();
                        break;
                    case 1:
                        Explore explore = (Explore)CurrentPage;
                        explore.Reload();
                        break;
                    case 2:
                      
                        NotificationTabControl.tabbedNotifications.Reload();
                        NotificationTabControl.tabbedDiscounts.Reload();
                        break;
                    case 3:
                        Profile profile = (Profile)CurrentPage;
                        profile.Reload();               
                        break;
                }
            };
           
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var rootPage = Navigation.NavigationStack[0];
            if (typeof(TabPageControl) == rootPage.GetType()) return;
            Navigation.RemovePage(rootPage);
        }

    }
}

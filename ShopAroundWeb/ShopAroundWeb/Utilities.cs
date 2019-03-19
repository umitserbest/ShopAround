using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAroundWeb
{
    public static class Utilities
    {
        public static void CreateCookie(string shopID)
        {
            HttpCookie ShopCookies = new HttpCookie("Shop");

            ShopCookies["ShopID"] = shopID;

            ShopCookies.Expires = DateTime.Now.AddDays(1);

            HttpContext.Current.Response.Cookies.Add(ShopCookies);
        }

        public static bool DoesExistShopCookie()
        {
            HttpCookie ShopCookies = HttpContext.Current.Request.Cookies["Shop"];

            if (ShopCookies != null)
            {
                return true; //there is a cookie
            }
            else
            {
                return false; //no cookie
            }
        }

        public static void RemoveCookie()
        {
            HttpCookie ShopCookies = new HttpCookie("Shop");

            //Adding Expire Time of cookies before existing cookies time
            ShopCookies.Expires = DateTime.Now.AddDays(-1);

            //Adding cookies to current web response
            HttpContext.Current.Response.Cookies.Add(ShopCookies);
        }
    }
}
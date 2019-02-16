using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAroundWeb
{
    public class Utilities
    {
        public static void CreateCookie(string userID)
        {
            HttpCookie UserCookies = new HttpCookie("User");

            UserCookies["UserID"] = userID;

            UserCookies.Expires = DateTime.Now.AddDays(1);

            HttpContext.Current.Response.Cookies.Add(UserCookies);
        }

        public static bool DoesExistUserCookie()
        {
            HttpCookie UserCookies = HttpContext.Current.Request.Cookies["User"];

            if (UserCookies != null)
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
            HttpCookie UserCookies = new HttpCookie("User");

            //Adding Expire Time of cookies before existing cookies time
            UserCookies.Expires = DateTime.Now.AddDays(-1);

            //Adding cookies to current web response
            HttpContext.Current.Response.Cookies.Add(UserCookies);
        }
    }
}
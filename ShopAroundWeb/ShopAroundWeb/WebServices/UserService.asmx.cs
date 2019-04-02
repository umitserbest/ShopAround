using Newtonsoft.Json;
using ShopAroundWeb.Database;
using ShopAroundWeb.Models;
using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;

namespace ShopAroundWeb.WebServices
{
    /// <summary>
    /// Summary description for UserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserService : WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void SignUp(string userSignUp)
        {
            try
            {
                UserSignUpModel userSignUpModel = JsonConvert.DeserializeObject<UserSignUpModel>(userSignUp);

                if (DatabaseForUser.IsAvailableUsername(userSignUpModel.Username) && DatabaseForUser.IsAvailableEmail(userSignUpModel.Email))
                {
                    if (DatabaseForUser.SignUp(userSignUpModel))
                    {
                        Context.Response.Write("true");
                    }
                    else
                    {
                        Context.Response.Write("false");
                    }
                }
                else
                {
                    Context.Response.Write("false");
                }                
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void SignIn(string userSignIn)
        {
            try
            {
                UserSignInModel userSignInModel = JsonConvert.DeserializeObject<UserSignInModel>(userSignIn);
               
                string userID = DatabaseForUser.SignIn(userSignInModel);

                if (userID != null)
                {
                    Context.Response.Write(userID);
                }
                else
                {
                    Context.Response.Write("false");
                }
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UpdateProfile(string user)
        {
            try
            {
                UserModel userModel = JsonConvert.DeserializeObject<UserModel>(user);

                if (DatabaseForUser.UpdateUserInfo(userModel))
                {
                    Context.Response.Write("true");
                }
                else
                {
                    Context.Response.Write("false");
                }
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetShopsForFollow()
        {
            try
            {               
                List<ShopModel> shops = DatabaseForUser.GetShops(5);
                List<Tuple<int, string, string>> shopsForFollow = new List<Tuple<int, string, string>>();

                foreach (ShopModel shop in shops)
                {
                    var temp = Tuple.Create(shop.ShopID, shop.Name, shop.Logo);
                    shopsForFollow.Add(temp);
                }

                Context.Response.Write(JsonConvert.SerializeObject(shopsForFollow));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void FollowShops(string follows)
        {
            try
            {
                List<Tuple<int, int>> listOfFollow = JsonConvert.DeserializeObject<List<Tuple<int, int>>>(follows); //UserID, ShopID

                foreach (Tuple<int, int> follow in listOfFollow)
                {
                    DatabaseForUser.FollowAShop(follow);
                }

                Context.Response.Write("true");
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetTheFlow(string userID)
        {
            try
            {
                int intUserID = JsonConvert.DeserializeObject<int>(userID);

                List<ProductModel> products = DatabaseForUser.GetProductsForTheFlow(50, intUserID);

                Context.Response.Write(JsonConvert.SerializeObject(products));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetProducts()
        {
            try
            {
                //int intUserID = JsonConvert.DeserializeObject<int>(userID);

                List<ProductModel> products = DatabaseForUser.GetProductsForExplore();

                Context.Response.Write(JsonConvert.SerializeObject(products));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

    }
}
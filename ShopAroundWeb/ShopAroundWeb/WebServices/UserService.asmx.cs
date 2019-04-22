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
        public bool UploadProfileImage(string image)
        {
            try
            {
                Tuple<string, byte[]> data = JsonConvert.DeserializeObject<Tuple<string, byte[]>>(image); //filename, filecontent
                string filesDirectory = Server.MapPath(@"~/UserAssets/ProfileImages/");
                System.IO.File.WriteAllBytes(string.Format("{0}{1}", filesDirectory, data.Item1), data.Item2);

                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddProfileInfo(string user)
        {
            try
            {
                UserModel userModel = JsonConvert.DeserializeObject<UserModel>(user);

                if (DatabaseForUser.AddUserInfo(userModel))
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
                Context.Response.Write(JsonConvert.SerializeObject(shops));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void FollowShop(string follow)
        {
            try
            {
                FollowModel followModel = JsonConvert.DeserializeObject<FollowModel>(follow);

                if (DatabaseForUser.FollowShop(followModel))
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
        public void FollowShops(string follows)
        {
            try
            {
                bool error = false;

                List<FollowModel> followModels = JsonConvert.DeserializeObject<List<FollowModel>>(follows);

                foreach (FollowModel follow in followModels)
                {
                    if (!DatabaseForUser.FollowShop(follow))
                    {
                        error = true;                       
                        break;
                    }
                }

                if (error)
                {
                    Context.Response.Write("false");
                }
                else
                {
                    Context.Response.Write("true");
                }
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UnfollowShop(string follow)
        {
            try
            {
                FollowModel followModel = JsonConvert.DeserializeObject<FollowModel>(follow);
            
                if (DatabaseForUser.UnfollowShop(followModel))
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
        public void GetTheExplore(string userID)
        {
            try
            {
                List<ProductModel> products = DatabaseForUser.GetAllProducts();
                Context.Response.Write(JsonConvert.SerializeObject(products));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddProductWishlist(string wishlist)
        {
            try
            {
                Tuple<int, int> data = JsonConvert.DeserializeObject<Tuple<int,int>>(wishlist); //productID, userID

                if (DatabaseForUser.AddProductToWishlist(data))
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
        public void GetShopsForTheFlow(string userID)
        {
            try
            {
                int intUserID = JsonConvert.DeserializeObject<int>(userID);

                List<ShopModel> shops = DatabaseForUser.GetFollowedShopsInfo(intUserID);

                Context.Response.Write(JsonConvert.SerializeObject(shops));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetShopProfile(string shopID)
        {
            try
            {
                int intshopID = JsonConvert.DeserializeObject<int>(shopID);

                ShopModel shop = DatabaseForUser.GetShop(intshopID);

                Context.Response.Write(JsonConvert.SerializeObject(shop));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetProductsOfShop(string shopID)
        {
            try
            {
                int intshopID = JsonConvert.DeserializeObject<int>(shopID);

                List<ProductModel> products = DatabaseForUser.GetProductsOfShop(intshopID);

                Context.Response.Write(JsonConvert.SerializeObject(products));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetWishlist(string userID)
        {
            try
            {
                int intUserID = JsonConvert.DeserializeObject<int>(userID);

                List<Tuple<int, int, int>> wishlist = DatabaseForUser.GetWishlist(intUserID);

                Context.Response.Write(JsonConvert.SerializeObject(wishlist));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

    }
}
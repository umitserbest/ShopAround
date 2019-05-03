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
    [WebService(Namespace = "http://shoparound.umitserbest.com/WebServices/UserService.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserService : WebService
    {
        #region User

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
        public void GetUserProfile(string userID)
        {
            try
            {
                int intUserID = JsonConvert.DeserializeObject<int>(userID);
                UserModel user = DatabaseForUser.GetUser(intUserID);
                Context.Response.Write(JsonConvert.SerializeObject(user));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetAllUsers()
        {
            try
            {
                List<UserModel> users = DatabaseForUser.GetAllUsers();
                Context.Response.Write(JsonConvert.SerializeObject(users));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetUsersByName(string name)
        {
            try
            {
                List<UserModel> users = DatabaseForUser.GetUsers(name);
                Context.Response.Write(JsonConvert.SerializeObject(users));
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

                List<ProductModel> wishlist = DatabaseForUser.GetWishlist(intUserID);

                Context.Response.Write(JsonConvert.SerializeObject(wishlist));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetFriends(string userID)
        {
            try
            {
                int intUserID = JsonConvert.DeserializeObject<int>(userID);

                List<int> friends = DatabaseForUser.GetFriends(intUserID);
                Context.Response.Write(JsonConvert.SerializeObject(friends));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void FollowUser(string follow)
        {
            try
            {
                Tuple<int, int> followModel = JsonConvert.DeserializeObject<Tuple<int, int>>(follow); //UserID, FriendID

                if (DatabaseForUser.FollowUser(followModel))
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
        public void UnfollowUser(string follow)
        {
            try
            {
                Tuple<int, int> followModel = JsonConvert.DeserializeObject<Tuple<int, int>>(follow); //UserID, FriendID

                if (DatabaseForUser.UnfollowUser(followModel))
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
        public void RemoveProductFromWishlist(string wishlist)
        {
            try
            {
                Tuple<int, int> wishlistModel = JsonConvert.DeserializeObject<Tuple<int, int>>(wishlist); //UserID, ProductID

                if (DatabaseForUser.DeleteProductFromWishlist(wishlistModel))
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
        public void GetNotifications(string userID)
        {
            try
            {
                int intUserID = JsonConvert.DeserializeObject<int>(userID);

                List<NotificationModel> notifications = DatabaseForUser.GetNotifications(intUserID);

                Context.Response.Write(JsonConvert.SerializeObject(notifications));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddNotification(string notification)
        {
            try
            {
                NotificationModel notificationModel = JsonConvert.DeserializeObject<NotificationModel>(notification);

                if (DatabaseForUser.AddNotification(notificationModel))
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
        public void GetDiscounts(string userID)
        {
            try
            {
                int intUserID = JsonConvert.DeserializeObject<int>(userID);

                List<DiscountModel> discounts = DatabaseForUser.GetDiscounts(intUserID);

                Context.Response.Write(JsonConvert.SerializeObject(discounts));
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
        public void GetTheExplore(string explore)
        {
            try
            {
                Tuple<int, int, int> tuple = JsonConvert.DeserializeObject<Tuple<int, int, int>>(explore); //userID, count, startPoint

                List<ProductModel> products = DatabaseForUser.GetAllProducts(tuple);
                Context.Response.Write(JsonConvert.SerializeObject(products));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetTheExploreTEST()
        {
            try
            {
                Tuple<int, int, int> tuple = new Tuple<int, int, int>(2, 9, 9);
                //Tuple<int, int, int> tuple = JsonConvert.DeserializeObject<Tuple<int, int, int>>(explore); //userID, count, startPoint

                List<ProductModel> products = DatabaseForUser.GetAllProducts(tuple);
                Context.Response.Write(JsonConvert.SerializeObject(products));
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        #endregion

        #region Shop

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
        public void GetShopsByName(string name)
        {
            try
            {
                List<ShopModel> shops = DatabaseForUser.GetShops(name);
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
        public void GetTheExploreByProductType(string items)
        {
            try
            {
                Tuple<int, int> tuple = JsonConvert.DeserializeObject<Tuple<int, int>>(items);
                List<ProductModel> products = DatabaseForUser.GetAllProducts(tuple.Item2);
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
                Tuple<int, int> data = JsonConvert.DeserializeObject<Tuple<int, int>>(wishlist); //productID, userID

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

        #endregion
        
    }
}
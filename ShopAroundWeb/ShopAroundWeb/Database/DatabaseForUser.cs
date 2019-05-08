using ShopAroundWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopAroundWeb.Database
{
    public static class DatabaseForUser
    {

        #region User

        public static bool IsAvailableUsername(string username)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT UserID FROM [User] WHERE Username=@Username";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static bool IsAvailableEmail(string email)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT UserID FROM [User] WHERE Email=@Email";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static bool SignUp(UserSignUpModel signUpModel)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "INSERT INTO [User] (Username, Password, Email) VALUES (@Username, @Password, @Email)";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = signUpModel.Username;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = signUpModel.Password;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = signUpModel.Email;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static string SignIn(UserSignInModel signInModel)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT UserID FROM [User] WHERE Username=@Username AND Password=@Password";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = signInModel.Username;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = signInModel.Password;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return reader[0].ToString(); //UserID  
                        }

                        return null;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<UserModel> GetAllUsers()
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT * FROM [User]";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<UserModel> users = new List<UserModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserModel user = new UserModel
                            {
                                UserID = int.Parse(reader[0].ToString()),
                                Username = reader[1].ToString(),
                                Email = reader[3].ToString(),
                                Name = reader[4].ToString(),
                                Surname = reader[5].ToString(),
                                Phone = reader[6].ToString(),
                                City = reader[7].ToString(),
                                About = reader[8].ToString()
                            };

                            users.Add(user);
                        }

                        return users;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<UserModel> GetUsers(string name)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT * FROM [User] WHERE Username LIKE @Username";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.AddWithValue("@Username", "%" + name + "%");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<UserModel> users = new List<UserModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserModel user = new UserModel
                            {
                                UserID = int.Parse(reader[0].ToString()),
                                Username = reader[1].ToString(),
                                Email = reader[3].ToString(),
                                Name = reader[4].ToString(),
                                Surname = reader[5].ToString(),
                                Phone = reader[6].ToString(),
                                City = reader[7].ToString(),
                                About = reader[8].ToString()
                            };

                            users.Add(user);
                        }

                        return users;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static UserModel GetUser(int userID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT * FROM [User] WHERE UserID=@UserID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserModel user = new UserModel
                            {
                                UserID = int.Parse(reader[0].ToString()),
                                Username = reader[1].ToString(),
                                Email = reader[3].ToString(),
                                Name = reader[4].ToString(),
                                Surname = reader[5].ToString(),
                                Phone = reader[6].ToString(),
                                City = reader[7].ToString(),
                                About = reader[8].ToString()
                            };

                            return user;
                        }

                        return null;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static bool AddUserInfo(UserModel userModel)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "UPDATE [User] SET Name=@Name, Surname=@Surname, Phone=@Phone, About=@About WHERE UserID=@UserID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = userModel.Name;
                cmd.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = userModel.Surname;
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = userModel.Phone;
                cmd.Parameters.Add("@About", SqlDbType.NVarChar).Value = userModel.About;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userModel.UserID;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static bool UpdateUserInfo(UserModel userModel)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "UPDATE [User] SET Name=@Name, Surname=@Surname, City=@City WHERE UserID=@UserID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = userModel.Name;
                cmd.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = userModel.Surname;
                cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = userModel.City;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userModel.UserID;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<ProductModel> GetWishlist(int userID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT dbo.Product.* FROM dbo.Product INNER JOIN"
                  + " dbo.Wishlist ON dbo.Product.ProductID = dbo.Wishlist.ProductID WHERE(dbo.Wishlist.UserID = @UserID)";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ProductModel> products = new List<ProductModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductModel product = new ProductModel
                            {
                                ProductID = int.Parse(reader[0].ToString()),
                                ShopID = int.Parse(reader[1].ToString()),
                                ProductTypeID = int.Parse(reader[2].ToString()),
                                Code = reader[3].ToString(),
                                Name = reader[4].ToString(),
                                Brand = reader[5].ToString(),
                                Color = reader[6].ToString(),
                                Size = reader[7].ToString(),
                                Material = reader[8].ToString(),
                                Details = reader[9].ToString(),
                                CombineImage = reader[10].ToString(),
                                CoverImage = reader[11].ToString(),
                                Image1 = reader[12].ToString(),
                                Image2 = reader[13].ToString(),
                                Image3 = reader[14].ToString(),
                                Price = float.Parse(reader[15].ToString()),
                                PurchaseLink = reader[16].ToString()
                            };

                            products.Add(product);
                        }

                        return products;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static bool AddProductToWishlist(Tuple<int, int> data)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "INSERT INTO [Wishlist] (UserID, ProductID) VALUES (@UserID, @ProductID)";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = data.Item2;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = data.Item1;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<int> GetFriends(int userID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT FriendUserID FROM [Friend] WHERE UserID=@UserID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<int> friends = new List<int>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            friends.Add(int.Parse(reader[0].ToString()));
                        }

                        return friends;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static bool FollowUser(Tuple<int, int> followModel)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "INSERT INTO [Friend] (UserID, FriendUserID) VALUES (@UserID, @FriendUserID)";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = followModel.Item1;
                cmd.Parameters.Add("@FriendUserID", SqlDbType.Int).Value = followModel.Item2;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static bool UnfollowUser(Tuple<int, int> follow)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "DELETE FROM [Friend] WHERE UserID=@UserID AND FriendUserID=@FriendUserID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = follow.Item1;
                cmd.Parameters.Add("@FriendUserID", SqlDbType.Int).Value = follow.Item2;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static bool DeleteProductFromWishlist(Tuple<int, int> tuple)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "DELETE FROM [Wishlist] WHERE UserID=@UserID AND ProductID=@ProductID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = tuple.Item1;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = tuple.Item2;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<NotificationModel> GetNotifications(int userID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT dbo.[User].UserID, dbo.[User].Username FROM dbo.[User] INNER JOIN"
                + " dbo.Notification ON dbo.[User].UserID = dbo.[Notification].SenderID"
                + " WHERE dbo.[Notification].ReceiverID=@ReceiverID ORDER BY dbo.[Notification].CreationDate";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@ReceiverID", SqlDbType.Int).Value = userID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<NotificationModel> notifications = new List<NotificationModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            NotificationModel notification = new NotificationModel
                            {
                                SenderID = int.Parse(reader[0].ToString()),
                                SenderUsername = reader[1].ToString(),
                                ReceiverID = userID
                            };

                            notifications.Add(notification);
                        }

                        return notifications;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static bool AddNotification(NotificationModel notification)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "INSERT INTO [Notification] (SenderID, ReceiverID) VALUES (@SenderID, @ReceiverID)";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@SenderID", SqlDbType.Int).Value = notification.SenderID;
                cmd.Parameters.Add("@ReceiverID", SqlDbType.Int).Value = notification.ReceiverID;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static bool AddDiscountCode(Tuple<int, int, string> tuple)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "INSERT INTO [DiscountCode] (DiscountID, UserID, Code) VALUES (@DiscountID, @UserID, @Code)";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@DiscountID", SqlDbType.Int).Value = tuple.Item2;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = tuple.Item1;
                cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = tuple.Item3;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static string GetDiscountCode(Tuple<int, int> tuple)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT Code FROM [DiscountCode] WHERE DiscountID=@DiscountID AND UserID=UserID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@DiscountID", SqlDbType.Int).Value = tuple.Item2;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = tuple.Item1;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {    
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return reader[0].ToString();
                        }

                        return null;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<DiscountModel> GetDiscounts(int userID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT dbo.Shop.ShopID, dbo.Discount.DiscountID, dbo.Discount.ProductID, dbo.Discount.Date, dbo.Discount.Details,"
                  + " dbo.Discount.Code, dbo.Follow.UserID, dbo.Shop.Name, dbo.Shop.Logo FROM dbo.Discount INNER JOIN"
                  + " dbo.Shop ON dbo.Discount.ShopID = dbo.Shop.ShopID INNER JOIN"
                  + " dbo.Follow ON dbo.Shop.ShopID = dbo.Follow.ShopID GROUP BY dbo.Shop.ShopID,"
                  + " dbo.Discount.DiscountID, dbo.Discount.ProductID, dbo.Discount.Date, dbo.Discount.Details, dbo.Discount.Code, dbo.Follow.UserID, dbo.Shop.Name, dbo.Shop.Logo"
                  + " HAVING(dbo.Follow.UserID = @UserID)";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<DiscountModel> discounts = new List<DiscountModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DiscountModel discount = new DiscountModel
                            {
                                ShopID = int.Parse(reader[0].ToString()),
                                DiscountID = int.Parse(reader[1].ToString()),
                                ProductID = int.Parse(reader[2].ToString()),
                                Date = DateTime.Parse(reader[3].ToString()),
                                Details = reader[4].ToString(),
                                Code = reader[5].ToString(),
                                ShopName = reader[7].ToString(),
                                ShopLogo = reader[8].ToString()
                            };

                            discounts.Add(discount);
                        }

                        return discounts;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        #endregion

        #region Shop

        public static ShopModel GetShop(int shopID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT * FROM [Shop] WHERE ShopID=@ShopID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@ShopID", SqlDbType.Int).Value = shopID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ShopModel shop = new ShopModel
                            {
                                ShopID = int.Parse(reader[0].ToString()),
                                Email = reader[1].ToString(),
                                Name = reader[3].ToString(),
                                Phone = reader[4].ToString(),
                                Address = reader[5].ToString(),
                                City = reader[6].ToString(),
                                About = reader[7].ToString(),
                                Logo = reader[8].ToString()
                            };

                            return shop;
                        }

                        return null;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<ShopModel> GetShops(int numberOfRecords)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT TOP " + numberOfRecords + " * FROM [Shop]";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ShopModel> shops = new List<ShopModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ShopModel shop = new ShopModel
                            {
                                ShopID = int.Parse(reader[0].ToString()),
                                Email = reader[1].ToString(),
                                Name = reader[3].ToString(),
                                Phone = reader[4].ToString(),
                                Address = reader[5].ToString(),
                                City = reader[6].ToString(),
                                About = reader[7].ToString(),
                                Logo = reader[8].ToString()
                            };

                            shops.Add(shop);
                        }

                        return shops;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<ShopModel> GetShopsForFollow(int userID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT * FROM Shop WHERE (ShopID NOT IN (SELECT ShopID FROM dbo.Follow WHERE(UserID = @UserID)))";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ShopModel> shops = new List<ShopModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ShopModel shop = new ShopModel
                            {
                                ShopID = int.Parse(reader[0].ToString()),
                                Email = reader[1].ToString(),
                                Name = reader[3].ToString(),
                                Phone = reader[4].ToString(),
                                Address = reader[5].ToString(),
                                City = reader[6].ToString(),
                                About = reader[7].ToString(),
                                Logo = reader[8].ToString()
                            };

                            shops.Add(shop);
                        }

                        return shops;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<ShopModel> GetShops(string name)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT * FROM [Shop] WHERE Name LIKE @Name";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.AddWithValue("@Name", "%" + name + "%");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ShopModel> shops = new List<ShopModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ShopModel shop = new ShopModel
                            {
                                ShopID = int.Parse(reader[0].ToString()),
                                Email = reader[1].ToString(),
                                Name = reader[3].ToString(),
                                Phone = reader[4].ToString(),
                                Address = reader[5].ToString(),
                                City = reader[6].ToString(),
                                About = reader[7].ToString(),
                                Logo = reader[8].ToString()
                            };

                            shops.Add(shop);
                        }

                        return shops;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static bool FollowShop(FollowModel followModel)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "INSERT INTO [Follow] (UserID, ShopID) VALUES (@UserID, @ShopID)";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = followModel.UserID;
                cmd.Parameters.Add("@ShopID", SqlDbType.Int).Value = followModel.ShopID;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static bool UnfollowShop(FollowModel follow)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "DELETE FROM [Follow] WHERE UserID=@UserID AND ShopID=@ShopID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = follow.UserID;
                cmd.Parameters.Add("@ShopID", SqlDbType.Int).Value = follow.ShopID;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<ProductModel> GetProductsForTheFlow(int count, int userID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT TOP " + count + " dbo.Product.* FROM dbo.Product INNER JOIN dbo.Shop ON dbo.Product.ShopID = dbo.Shop.ShopID INNER JOIN "
                 + "dbo.Follow ON dbo.Shop.ShopID = dbo.Follow.ShopID WHERE dbo.Follow.UserID=@UserID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ProductModel> products = new List<ProductModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductModel product = new ProductModel
                            {
                                ProductID = int.Parse(reader[0].ToString()),
                                ShopID = int.Parse(reader[1].ToString()),
                                ProductTypeID = int.Parse(reader[2].ToString()),
                                Code = reader[3].ToString(),
                                Name = reader[4].ToString(),
                                Brand = reader[5].ToString(),
                                Color = reader[6].ToString(),
                                Size = reader[7].ToString(),
                                Material = reader[8].ToString(),
                                Details = reader[9].ToString(),
                                CombineImage = reader[10].ToString(),
                                CoverImage = reader[11].ToString(),
                                Image1 = reader[12].ToString(),
                                Image2 = reader[13].ToString(),
                                Image3 = reader[14].ToString(),
                                Price = float.Parse(reader[15].ToString()),
                                PurchaseLink = reader[16].ToString()
                            };

                            products.Add(product);
                        }

                        return products;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<ProductModel> GetProductsOfShop(int shopID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT * FROM [Product] WHERE ShopID=@ShopID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@ShopID", SqlDbType.Int).Value = shopID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ProductModel> products = new List<ProductModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductModel product = new ProductModel
                            {
                                ProductID = int.Parse(reader[0].ToString()),
                                ShopID = int.Parse(reader[1].ToString()),
                                ProductTypeID = int.Parse(reader[2].ToString()),
                                Code = reader[3].ToString(),
                                Name = reader[4].ToString(),
                                Brand = reader[5].ToString(),
                                Color = reader[6].ToString(),
                                Size = reader[7].ToString(),
                                Material = reader[8].ToString(),
                                Details = reader[9].ToString(),
                                CombineImage = reader[10].ToString(),
                                CoverImage = reader[11].ToString(),
                                Image1 = reader[12].ToString(),
                                Image2 = reader[13].ToString(),
                                Image3 = reader[14].ToString(),
                                Price = float.Parse(reader[15].ToString()),
                                PurchaseLink = reader[16].ToString()
                            };

                            products.Add(product);
                        }

                        return products;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<ProductModel> GetAllProducts()
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT * FROM [Product]";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ProductModel> products = new List<ProductModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductModel product = new ProductModel
                            {
                                ProductID = int.Parse(reader[0].ToString()),
                                ShopID = int.Parse(reader[1].ToString()),
                                ProductTypeID = int.Parse(reader[2].ToString()),
                                Code = reader[3].ToString(),
                                Name = reader[4].ToString(),
                                Brand = reader[5].ToString(),
                                Color = reader[6].ToString(),
                                Size = reader[7].ToString(),
                                Material = reader[8].ToString(),
                                Details = reader[9].ToString(),
                                CombineImage = reader[10].ToString(),
                                CoverImage = reader[11].ToString(),
                                Image1 = reader[12].ToString(),
                                Image2 = reader[13].ToString(),
                                Image3 = reader[14].ToString(),
                                Price = float.Parse(reader[15].ToString()),
                                PurchaseLink = reader[16].ToString()
                            };

                            products.Add(product);
                        }

                        return products;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<ProductModel> GetAllProducts(Tuple<int, string> tuple) //userID, city
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT dbo.Product.* FROM dbo.Shop INNER JOIN dbo.Product ON dbo.Shop.ShopID = dbo.Product.ShopID"   
                + " WHERE(dbo.Shop.City = @City)";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = tuple.Item2;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ProductModel> products = new List<ProductModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductModel product = new ProductModel
                            {
                                ProductID = int.Parse(reader[0].ToString()),
                                ShopID = int.Parse(reader[1].ToString()),
                                ProductTypeID = int.Parse(reader[2].ToString()),
                                Code = reader[3].ToString(),
                                Name = reader[4].ToString(),
                                Brand = reader[5].ToString(),
                                Color = reader[6].ToString(),
                                Size = reader[7].ToString(),
                                Material = reader[8].ToString(),
                                Details = reader[9].ToString(),
                                CombineImage = reader[10].ToString(),
                                CoverImage = reader[11].ToString(),
                                Image1 = reader[12].ToString(),
                                Image2 = reader[13].ToString(),
                                Image3 = reader[14].ToString(),
                                Price = float.Parse(reader[15].ToString()),
                                PurchaseLink = reader[16].ToString()
                            };

                            products.Add(product);
                        }

                        return products;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<ProductModel> GetAllProducts(Tuple<int, int, int> tuple) //userID, count, startPoint
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT * FROM [Product]";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ProductModel> products = new List<ProductModel>();

                    if (reader.HasRows)
                    {
                        int productCount = 0;

                        while (reader.Read())
                        {
                            ProductModel product = new ProductModel
                            {
                                ProductID = int.Parse(reader[0].ToString()),
                                ShopID = int.Parse(reader[1].ToString()),
                                ProductTypeID = int.Parse(reader[2].ToString()),
                                Code = reader[3].ToString(),
                                Name = reader[4].ToString(),
                                Brand = reader[5].ToString(),
                                Color = reader[6].ToString(),
                                Size = reader[7].ToString(),
                                Material = reader[8].ToString(),
                                Details = reader[9].ToString(),
                                CombineImage = reader[10].ToString(),
                                CoverImage = reader[11].ToString(),
                                Image1 = reader[12].ToString(),
                                Image2 = reader[13].ToString(),
                                Image3 = reader[14].ToString(),
                                Price = float.Parse(reader[15].ToString()),
                                PurchaseLink = reader[16].ToString()
                            };

                            productCount++;

                            if (productCount < tuple.Item2 + tuple.Item3) //Item2 => count
                            {
                                if (productCount >= tuple.Item3) //Item3 => startPoint
                                {
                                    products.Add(product);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        return products;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<ProductModel> GetAllProducts(int productTypeID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT * FROM [Product] WHERE ProductTypeID=@ProductTypeID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@ProductTypeID", SqlDbType.Int).Value = productTypeID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ProductModel> products = new List<ProductModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductModel product = new ProductModel
                            {
                                ProductID = int.Parse(reader[0].ToString()),
                                ShopID = int.Parse(reader[1].ToString()),
                                ProductTypeID = int.Parse(reader[2].ToString()),
                                Code = reader[3].ToString(),
                                Name = reader[4].ToString(),
                                Brand = reader[5].ToString(),
                                Color = reader[6].ToString(),
                                Size = reader[7].ToString(),
                                Material = reader[8].ToString(),
                                Details = reader[9].ToString(),
                                CombineImage = reader[10].ToString(),
                                CoverImage = reader[11].ToString(),
                                Image1 = reader[12].ToString(),
                                Image2 = reader[13].ToString(),
                                Image3 = reader[14].ToString(),
                                Price = float.Parse(reader[15].ToString()),
                                PurchaseLink = reader[16].ToString()
                            };

                            products.Add(product);
                        }

                        return products;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<ProductModel> GetProductsOfUnfollowedShops(int userID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT * FROM dbo.Product"
                + " WHERE(ShopID NOT IN (SELECT ShopID FROM dbo.Follow WHERE(UserID = @UserID)))";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ProductModel> products = new List<ProductModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductModel product = new ProductModel
                            {
                                ProductID = int.Parse(reader[0].ToString()),
                                ShopID = int.Parse(reader[1].ToString()),
                                ProductTypeID = int.Parse(reader[2].ToString()),
                                Code = reader[3].ToString(),
                                Name = reader[4].ToString(),
                                Brand = reader[5].ToString(),
                                Color = reader[6].ToString(),
                                Size = reader[7].ToString(),
                                Material = reader[8].ToString(),
                                Details = reader[9].ToString(),
                                CombineImage = reader[10].ToString(),
                                CoverImage = reader[11].ToString(),
                                Image1 = reader[12].ToString(),
                                Image2 = reader[13].ToString(),
                                Image3 = reader[14].ToString(),
                                Price = float.Parse(reader[15].ToString()),
                                PurchaseLink = reader[16].ToString()
                            };

                            products.Add(product);
                        }

                        return products;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<ShopModel> GetFollowedShopsInfo(int userID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT dbo.Shop.* FROM dbo.Follow INNER JOIN dbo.Shop ON dbo.Follow.ShopID = dbo.Shop.ShopID WHERE dbo.Follow.UserID=@UserID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ShopModel> shops = new List<ShopModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ShopModel shop = new ShopModel
                            {
                                ShopID = int.Parse(reader[0].ToString()),
                                Name = reader[3].ToString(),
                                Logo = reader[8].ToString()
                            };

                            shops.Add(shop);
                        }

                        return shops;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        #endregion

    }
}
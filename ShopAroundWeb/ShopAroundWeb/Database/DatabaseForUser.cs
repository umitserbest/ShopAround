using ShopAroundWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopAroundWeb.Database
{
    public static class DatabaseForUser
    {
        public static bool IsAvailableUsername(string username)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT UserID FROM [User] WHERE Username=@Username";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
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

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
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

                SqlDataReader reader = cmd.ExecuteReader();

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

                string query = "UPDATE [User] SET Username=@Username, Password=@Password, Name=@Name, Surname=@Surname, Phone=@Phone, About=@About WHERE UserID=@UserID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = userModel.Username;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = userModel.Password;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = userModel.Name;
                cmd.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = userModel.Surname;
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = userModel.Phone;
                cmd.Parameters.Add("@About", SqlDbType.NVarChar).Value = userModel.About;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userModel.UserID;
                cmd.ExecuteNonQuery();

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

        public static List<ShopModel> GetShops(int numberOfRecords)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT TOP " + numberOfRecords + " * FROM [Shop]";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);

                SqlDataReader reader = cmd.ExecuteReader();

                List<ShopModel> shops = new List<ShopModel>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ShopModel shop = new ShopModel();

                        shop.ShopID = int.Parse(reader[0].ToString());
                        shop.Email = reader[1].ToString();
                        //shop.Password = reader[2].ToString();
                        shop.Name = reader[3].ToString();
                        shop.Phone = reader[4].ToString();
                        shop.Address = reader[5].ToString();
                        shop.City = byte.Parse(reader[6].ToString());
                        shop.About = reader[7].ToString();
                        shop.Logo = reader[8].ToString();

                        shops.Add(shop);
                    }

                    return shops;
                }
                else
                {
                    return null;
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

        public static bool UnfollowShop(Tuple<int, int> follow)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "DELETE FROM [Follow] WHERE UserID=@UserID AND ShopID=@ShopID)";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = follow.Item1;
                cmd.Parameters.Add("@ShopID", SqlDbType.Int).Value = follow.Item2;
                cmd.ExecuteNonQuery();

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

        public static List<ProductModel> GetProductsForTheFlow(int numberOfRecords, int userID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT TOP " + numberOfRecords + " dbo.Product.* FROM dbo.Product INNER JOIN dbo.Shop ON dbo.Product.ShopID = dbo.Shop.ShopID INNER JOIN "
                 + "dbo.Follow ON dbo.Shop.ShopID = dbo.Follow.ShopID WHERE dbo.Follow.UserID=@UserID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                SqlDataReader reader = cmd.ExecuteReader();

                List<ProductModel> products = new List<ProductModel>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductModel product = new ProductModel();

                        product.ProductID = int.Parse(reader[0].ToString());
                        product.ShopID = int.Parse(reader[1].ToString());
                        product.ProductTypeID = int.Parse(reader[2].ToString());
                        product.Code = reader[3].ToString();
                        product.Name = reader[4].ToString();
                        product.Brand = reader[5].ToString();
                        product.Color = reader[6].ToString();
                        product.Size = reader[7].ToString();
                        product.Material = reader[8].ToString();
                        product.Details = reader[9].ToString();
                        product.CombineImage = reader[10].ToString();
                        product.CoverImage = reader[11].ToString();
                        product.Image1 = reader[12].ToString();
                        product.Image2 = reader[13].ToString();
                        product.Image3 = reader[14].ToString();

                        products.Add(product);
                    }

                    return products;
                }
                else
                {
                    return null;
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

                SqlDataReader reader = cmd.ExecuteReader();

                List<ProductModel> products = new List<ProductModel>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductModel product = new ProductModel();

                        product.ProductID = int.Parse(reader[0].ToString());
                        product.ShopID = int.Parse(reader[1].ToString());
                        product.ProductTypeID = int.Parse(reader[2].ToString());
                        product.Code = reader[3].ToString();
                        product.Name = reader[4].ToString();
                        product.Brand = reader[5].ToString();
                        product.Color = reader[6].ToString();
                        product.Size = reader[7].ToString();
                        product.Material = reader[8].ToString();
                        product.Details = reader[9].ToString();
                        product.CombineImage = reader[10].ToString();
                        product.CoverImage = reader[11].ToString();
                        product.Image1 = reader[12].ToString();
                        product.Image2 = reader[13].ToString();
                        product.Image3 = reader[14].ToString();

                        products.Add(product);
                    }

                    return products;
                }
                else
                {
                    return null;
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

        public static bool AddProductToWishlist(Tuple<int,int> data)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "INSERT INTO [Wishlist] (UserID, ProductID) VALUES (@UserID, @ProductID)";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = data.Item2;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = data.Item1;
                cmd.ExecuteNonQuery();

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

        public static List<ShopModel> GetFollowedShopsInfo(int userID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT dbo.Shop.* FROM dbo.Follow INNER JOIN dbo.Shop ON dbo.Follow.ShopID = dbo.Shop.ShopID WHERE dbo.Follow.UserID=@UserID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                SqlDataReader reader = cmd.ExecuteReader();

                List<ShopModel> shops = new List<ShopModel>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ShopModel shop = new ShopModel();

                        shop.ShopID = int.Parse(reader[0].ToString());
                        shop.Name = reader[3].ToString();
                        shop.Logo = reader[8].ToString();

                        shops.Add(shop);
                    }

                    return shops;
                }
                else
                {
                    return null;
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
    }
}
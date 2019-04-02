using ShopAroundWeb.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopAroundWeb.Database
{
    public static class DatabaseForShop
    {
        public static bool IsAvailableEmail(string email)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT ShopID FROM [Shop] WHERE Email=@Email";
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

        public static bool SignUp(ShopSignUpModel signUpModel)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "INSERT INTO [Shop] (Email, Password, Name, Phone, City) VALUES (@Email, @Password, @Name, @Phone, @City)";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = signUpModel.Email;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = signUpModel.Password;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = signUpModel.Name;
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = signUpModel.Phone;
                cmd.Parameters.Add("@City", SqlDbType.TinyInt).Value = signUpModel.City;
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

        public static string SignIn(ShopSignInModel signInModel)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT ShopID FROM [Shop] WHERE Email=@Email AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = signInModel.Email;
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

        public static ShopModel GetShopInfo(string shopID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT * FROM [Shop] WHERE ShopID=@ShopID";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@ShopID", SqlDbType.Int).Value = shopID;
              
                SqlDataReader reader = cmd.ExecuteReader();

                ShopModel shop = new ShopModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        shop.ShopID = int.Parse(reader[0].ToString());
                        shop.Email = reader[1].ToString();
                        shop.Password = reader[2].ToString();
                        shop.Name = reader[3].ToString();
                        shop.Phone = reader[4].ToString();
                        shop.Address = reader[5].ToString();
                        shop.City = byte.Parse(reader[6].ToString());
                        shop.About = reader[7].ToString();
                    }

                    return shop;
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

        public static bool UpdateShopInfo(ShopModel shopModel)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "UPDATE [Shop] SET Password=@Password, Name=@Name, Phone=@Phone, Address=@Address, City=@City, About=@About, Logo=@Logo WHERE ShopID=@ShopID";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = shopModel.Password;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = shopModel.Name;
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = shopModel.Phone;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = shopModel.Address;
                cmd.Parameters.Add("@City", SqlDbType.TinyInt).Value = shopModel.City;
                cmd.Parameters.Add("@About", SqlDbType.NVarChar).Value = shopModel.About;
                cmd.Parameters.Add("@Logo", SqlDbType.NVarChar).Value = shopModel.Logo;
                cmd.Parameters.Add("@ShopID", SqlDbType.Int).Value = shopModel.ShopID;
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

        public static List<ProductTypeModel> GetProductTypes()
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT * FROM [ProductType]";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);

                SqlDataReader reader = cmd.ExecuteReader();

                List<ProductTypeModel> productTypes = new List<ProductTypeModel>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductTypeModel productTypeModel = new ProductTypeModel();
                        productTypeModel.ProductTypeID = int.Parse(reader[0].ToString());
                        productTypeModel.Name = reader[1].ToString();
                        productTypes.Add(productTypeModel);
                    }

                    return productTypes;
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

        public static bool AddProduct(ProductModel product)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "INSERT INTO [Product] (ShopID, ProductTypeID, Code, Name, Brand, Color, Size, Material, Details, " +
                    "CombineImage, CoverImage, Image1, Image2, Image3) VALUES (@ShopID, @ProductTypeID, @Code, @Name, @Brand, @Color, @Size, " +
                    "@Material, @Details, @CombineImage, @CoverImage, @Image1, @Image2, @Image3)";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);

                cmd.Parameters.Add("@ShopID", SqlDbType.Int).Value = product.ShopID;
                cmd.Parameters.Add("@ProductTypeID", SqlDbType.Int).Value = product.ProductTypeID;
                cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = product.Code;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = product.Name;
                cmd.Parameters.Add("@Brand", SqlDbType.NVarChar).Value = product.Brand;
                cmd.Parameters.Add("@Color", SqlDbType.NVarChar).Value = product.Color;
                cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = product.Size;
                cmd.Parameters.Add("@Material", SqlDbType.NVarChar).Value = product.Material;
                cmd.Parameters.Add("@Details", SqlDbType.NVarChar).Value = product.Details;
                cmd.Parameters.Add("@CombineImage", SqlDbType.NVarChar).Value = product.CombineImage;
                cmd.Parameters.Add("@CoverImage", SqlDbType.NVarChar).Value = product.CoverImage;
                cmd.Parameters.Add("@Image1", SqlDbType.NVarChar).Value = product.Image1;
                cmd.Parameters.Add("@Image2", SqlDbType.NVarChar).Value = product.Image2;
                cmd.Parameters.Add("@Image3", SqlDbType.NVarChar).Value = product.Image3;

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
    }
}
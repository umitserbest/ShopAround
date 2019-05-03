using ShopAroundWeb.Models;
using System;
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
                    "CombineImage, CoverImage, Image1, Image2, Image3, Price, PurchaseLink) VALUES (@ShopID, @ProductTypeID, @Code, @Name, @Brand, @Color, @Size, " +
                    "@Material, @Details, @CombineImage, @CoverImage, @Image1, @Image2, @Image3, @Price, @PurchaseLink)";

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
                cmd.Parameters.Add("@Price", SqlDbType.SmallMoney).Value = product.Price;
                cmd.Parameters.Add("@PurchaseLink", SqlDbType.NVarChar).Value = product.PurchaseLink;

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

        public static bool EditProduct(ProductModel product)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "UPDATE [Product] SET ProductTypeID=@ProductTypeID, Code=@Code, Name=@Name, Brand=@Brand, Color=@Color, Size=@Size, Material=@Material, Details=@Details, " +
                    "CombineImage=@CombineImage, CoverImage=@CoverImage, Image1=@Image1, Image2=@Image2, Image3=@Image3, Price=@Price, PurchaseLink=@PurchaseLink WHERE ProductID=@ProductID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
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
                cmd.Parameters.Add("@Price", SqlDbType.SmallMoney).Value = product.Price;
                cmd.Parameters.Add("@PurchaseLink", SqlDbType.NVarChar).Value = product.PurchaseLink;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = product.ProductID;

                cmd.ExecuteNonQuery();

                return true;
            }
            catch(Exception)
            {
                throw;
                return false;
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        public static List<ProductModel> GetProducts(int shopID)
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
        }

        public static List<DiscountModel> GetDiscounts(int shopID)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "SELECT * FROM Discount WHERE ShopID=@ShopID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);
                cmd.Parameters.Add("@ShopID", SqlDbType.Int).Value = shopID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<DiscountModel> discounts = new List<DiscountModel>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DiscountModel discount = new DiscountModel
                            {
                                DiscountID = int.Parse(reader[0].ToString()),
                                ShopID = int.Parse(reader[1].ToString()),
                                ProductID = int.Parse(reader[2].ToString()),
                                Date = DateTime.Parse(reader[3].ToString()),
                                Details = reader[4].ToString(),
                                Code = reader[5].ToString()
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
        }

        public static bool AddDiscount(DiscountModel discount)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "INSERT INTO [Discount] (ShopID, ProductID, Date, Details, Code) " +
                    "VALUES (@ShopID, @ProductID, @Date, @Details, @Code)";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);

                cmd.Parameters.Add("@ShopID", SqlDbType.Int).Value = discount.ShopID;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = discount.ProductID;
                cmd.Parameters.Add("@Date", SqlDbType.SmallDateTime).Value = discount.Date;
                cmd.Parameters.Add("@Details", SqlDbType.NVarChar).Value = discount.Details;
                cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = discount.Code;

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

        public static bool EditDiscount(DiscountModel discount)
        {
            try
            {
                DatabaseConnection.OpenConnection();

                string query = "UPDATE [Discount] SET ProductID=@ProductID, Date=@Date, Details=@Details, Code=@Code WHERE DiscountID=@DiscountID";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.connection);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = discount.ProductID;
                cmd.Parameters.Add("@Date", SqlDbType.SmallDateTime).Value = discount.Date;
                cmd.Parameters.Add("@Details", SqlDbType.NVarChar).Value = discount.Details;
                cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = discount.Code;
                cmd.Parameters.Add("@DiscountID", SqlDbType.Int).Value = discount.DiscountID;

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
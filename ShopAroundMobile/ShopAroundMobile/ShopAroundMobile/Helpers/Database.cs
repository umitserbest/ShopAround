using ShopAroundMobile.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShopAroundMobile.Helpers
{
    public static class Database
    {
        private static SQLiteConnection connection;

        public static void Connect()
        {
            try
            {
                // Get an absolute path to the database file
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ShopAround.db");

                connection = new SQLiteConnection(databasePath);

                connection.CreateTable<LocalLogModel>();

                connection.CreateTable<LocalUserModel>();
            }
            catch (Exception)
            {
               // throw;
            }
        }

        public static bool IsExistUser(LocalUserModel user)
        {
            LocalUserModel foundUser = connection.Table<LocalUserModel>().Where(v => v.Username == user.Username && v.Password == user.Password).FirstOrDefault();

            return foundUser != null ? true : false;           
        }
        
        public static LocalUserModel GetUser()
        {
           return connection.Table<LocalUserModel>().FirstOrDefault();           
        }

        public static void AddUser(LocalUserModel user)
        {
            try
            {
                connection.Insert(user);
            }
            catch (Exception)
            {
               // throw;
            }
        }

        public static void AddLog(LocalLogModel firstLog)
        {
            try
            {
                connection.Insert(firstLog);
            }
            catch (Exception)
            {
                //throw;
            }
        }

        public static LocalLogModel GetLog()
        {
            return connection.Table<LocalLogModel>().FirstOrDefault();
        }

        public static void DeleteUser()
        {
            try
            {
                connection.DeleteAll<LocalUserModel>();
            }
            catch (Exception)
            {
                //throw;
            }
        }
        public static void DeleteLog()
        {
            try
            {
                connection.DeleteAll<LocalLogModel>();
            }
            catch (Exception)
            {
              //  throw;
            }
        }
    }
}
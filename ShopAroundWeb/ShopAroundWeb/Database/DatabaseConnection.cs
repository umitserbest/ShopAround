using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopAroundWeb.Database
{
    public static class DatabaseConnection
    {
        /* SERVER */
        public static readonly SqlConnection connection = new SqlConnection("Data Source=(local)\\MSSQLSERVER2012; Initial Catalog=knightan_shoparound; Integrated Security=False; User ID=shoparound; Password=xqS483^k; Connect Timeout=15; Encrypt=False; Packet Size=4096");

        /* LOCAL */
        //public static readonly SqlConnection connection = new SqlConnection("Data Source=(local)\\SQLEXPRESS; Initial Catalog=ShopAround; Integrated Security=True");

        public static void OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch
            {
            }
        }

        public static void CloseConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch
            {
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace PepsiLiteDataAccess
{
    public class Connection
    {
        private static string sqlConString = "Server=172.21.0.65;Port=5432;User Id=pl_db_user1;Password=pl_db_user1;Database=pl_db;";

        public static NpgsqlConnection GetPostGresConnection()
        {
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = new NpgsqlConnection();
                pgSqlCon.ConnectionString = sqlConString;
               // pgSqlCon.Open();
                return pgSqlCon;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pgSqlCon;

        } 
    }
}

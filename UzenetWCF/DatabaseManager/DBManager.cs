using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace UzenetWCF.DatabaseManager
{
    internal class DBManager
    {
        private const string connectionString =
            "SERVER = localhost;" +
            "DATABASE = uzenetkuldo;" +
            "UID = root;" +
            "PASSWORD =;";

        public MySqlConnection OpenDB()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            return conn;
        }
    }
}
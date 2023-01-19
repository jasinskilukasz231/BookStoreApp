using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookStoreApp
{
    public static class Database
    {
        private static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bookstore";
        private static MySqlConnection sqlConnection;
        private static MySqlCommand sqlCommand;
        private static MySqlDataReader reader;

        public static string Find(string query)
        {
            sqlConnection = new MySqlConnection(connectionString);
            sqlCommand = new MySqlCommand(query, sqlConnection);
            sqlCommand.CommandTimeout = 60;
            try
            {
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();

                if(reader.HasRows)
                {
                    string s = "";
                    while (reader.Read())
                    {
                        s = reader.GetString(0);
                    }
                    sqlConnection.Close();
                    return s;
                }
                else
                {
                    sqlConnection.Close();
                    return null;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Query error: " + e.Message);
                sqlConnection.Close();
                return null;
            }
        }
        public static void InsertInto(string query)
        {
            sqlConnection = new MySqlConnection(connectionString);
            sqlCommand = new MySqlCommand(query, sqlConnection);
            sqlCommand.CommandTimeout = 60;
            try
            {
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                sqlConnection.Close();
                MessageBox.Show("Query error: " + e.Message);
            }
        }
    }
}
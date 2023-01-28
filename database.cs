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

        public static string FindOneThing(string query)
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
        public static string FindMany(string query)
        {
            //finds all items
            //adds , as a seperator
            sqlConnection = new MySqlConnection(connectionString);
            sqlCommand = new MySqlCommand(query, sqlConnection);
            sqlCommand.CommandTimeout = 60;
            try
            {
                string s = "";
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();
                
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        s += reader.GetString(0);
                        s += ",";
                    }
                }
                sqlConnection.Close();
                return s;
            }
            catch(Exception e)
            {
                MessageBox.Show("Query error " + e);
                sqlConnection.Close();
                return null;
            }
        }
        public static string[] FindBookData(string query)
        {
            //this function reads all data from database about certain book. Returns specific numbers of columns.
            sqlConnection = new MySqlConnection(connectionString);
            sqlCommand = new MySqlCommand(query, sqlConnection);
            sqlCommand.CommandTimeout = 60;
            try
            {
                int i = 0;
                string[] data = new string[10];
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        data[i] = reader.GetString(i);
                        i++;
                    }
                }
                return data;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
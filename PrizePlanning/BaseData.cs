using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PrizePlanning
{
    public class BaseData
    {
        public static string ConnectionString { get; } = "Server=.\\SQLEXPRESS;Database=PrizePlanningBD;Trusted_Connection=True;";
        public static SqlConnection Connection { get { return connection; } }

        private static SqlConnection connection;
        private SqlCommand command;

        public BaseData()
        {
            connection = new SqlConnection(ConnectionString);

            if (connection.State == ConnectionState.Open)
                connection.Close();

            this.OpenBase();
        }
        ~BaseData()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
        public async void OpenBase()
        {
            await connection.OpenAsync();
        }
    }
}

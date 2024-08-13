using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class DbConnection
    {
        private static string connectionString = "Data Source=.;Initial Catalog=ARECA_IPIS_DB;User Id=sa;Password=areca@123;";


        public static SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                // MessageBox.Show("Connection successfully opened.");
                return connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening database connection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static void Dispose(SqlConnection connection)
        {
            CloseConnection(connection);
            if (connection != null)
            {
                connection.Dispose();
            }
        }

        public int ExecuteNonQuery(string query)
        {
            using (var connection = OpenConnection())
            {
                if (connection == null)
                    return -1;

                using (var cmd = new SqlCommand(query, connection))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public object ExecuteScalar(string query)
        {
            using (var connection = OpenConnection())
            {
                if (connection == null)
                    return null;

                using (var cmd = new SqlCommand(query, connection))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }
        public DataTable ExecuteQuery(string query)
        {
            using (var connection = OpenConnection())
            {
                if (connection == null)
                    return null;

                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public void Dispose()
        {
            Dispose(null);
        }
    }
}

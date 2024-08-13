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
    class BoardConfigurationDb
    {
        private DbConnection dbConnection;

        public BoardConfigurationDb()
        {
            dbConnection = new DbConnection();
        }


        public static List<string> GetFormatType()
        {
            List<string> formatTypesList = new List<string>();

            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].getFormatTypes", connection))
                    {
                        // Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Create a DataTable to hold the result
                        DataTable dataTable = new DataTable();

                        // Execute the command and load the result into the DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        // Convert the DataTable to a List<string>
                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Assuming the column name is "FormatType"
                            string value = row["FormatType"].ToString().Trim();
                            formatTypesList.Add(value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return formatTypesList;
        }

        public static DataTable getBoardConfiguration(string ipAddress)
        {
            DataTable dataTable = new DataTable();
            string storedProcedureName = "config.getBoardConfigurationSP";

            using (SqlConnection connection = DbConnection.OpenConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IPAddress", ipAddress);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return dataTable;
        }

    }
}

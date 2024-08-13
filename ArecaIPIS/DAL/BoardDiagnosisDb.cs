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
    class BoardDiagnosisDb
    {

        private DbConnection dbConnection;

        public BoardDiagnosisDb()
        {
            dbConnection = new DbConnection();
        }

        public static DataTable GetDiagnosisBoards(List<int> PacketIdentifiers)
        {
            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    DataTable packetIdsTable = new DataTable();
                    packetIdsTable.Columns.Add("PacketIdentifier", typeof(int));

                    // Add the packet identifiers to the DataTable
                    foreach (int id in PacketIdentifiers)
                    {
                        packetIdsTable.Rows.Add(id);
                    }

                    using (SqlCommand command = new SqlCommand("[config].[GetDiagnosisSp]", connection))
                    {
                        // Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Add the parameter to the command
                        command.Parameters.AddWithValue("@PacketIdentifiers", packetIdsTable);

                        // Create a DataTable to hold the result
                        DataTable dataTable = new DataTable();

                        // Execute the command and load the result into the DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        // Return the filled DataTable
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Or throw the exception further
            }
        }

    }
}

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

    class HubConfigurationDb
    {
        private DbConnection dbConnection;

        public HubConfigurationDb()
        {
            dbConnection = new DbConnection();
        }

        public static  int SavePdcData(int id, string platformNo,  int etherNetPort, string noOfPorts, string ipAddress, string location, int portNo,int packetidentifier)
        {
            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        return 0;

                    using (var command = new SqlCommand("[config].[InsertUpdatePdcConfigurationSp]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the command
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Platform", platformNo);
                        command.Parameters.AddWithValue("@EtherNetPort",etherNetPort);
                        command.Parameters.AddWithValue("@NoOfPorts", noOfPorts);
                        command.Parameters.AddWithValue("@IpAddress", ipAddress);
                        command.Parameters.AddWithValue("@Location", location);
                        command.Parameters.AddWithValue("@portNo", portNo);
                        command.Parameters.AddWithValue("@packetIdentifier", packetidentifier);
                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions

                MessageBox.Show("An error occurred: " + ex.Message);
                return 0;
            }
        }


        public  static int SaveTadbBoard(
       int id, int pdcPort, int boardId, string location, int ethernetPort, string ipAddress, string platform, int noOfLines,
       bool message, bool boardRunning, string displaySequence, string platforms, string videoType, string letterSpeed,
       string formatType, string letterGap, string displayEffect, int fontSize, string infoDisplayed, int delayTime,
       int eraseTime, string defaultEnglish, string defaultRegional, string defaultHindi ,int portno,int packetidentifier)
        {
            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        return 0;

                    using (var command = new SqlCommand("[config].[InsertUpdateHUBConfigurationSp]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@PdcPort", pdcPort);
                        command.Parameters.AddWithValue("@portNo", portno);
                        command.Parameters.AddWithValue("@Location", location);
                        command.Parameters.AddWithValue("@EtherNetPort", ethernetPort);
                        command.Parameters.AddWithValue("@IpAddress", ipAddress);
                        command.Parameters.AddWithValue("@Platform", platform);
                        command.Parameters.AddWithValue("@packetIdentifier", packetidentifier);
                        command.Parameters.AddWithValue("@BoardId", boardId);
                        command.Parameters.AddWithValue("@NoOfLines", noOfLines);
                        command.Parameters.AddWithValue("@MessagesEnble", message);
                        command.Parameters.AddWithValue("@BoardRunning", boardRunning);
                        command.Parameters.AddWithValue("@DisplaySequence", displaySequence);
                        command.Parameters.AddWithValue("@checkedplatformNumbers", platforms);
                        command.Parameters.AddWithValue("@VideoType", videoType);
                        command.Parameters.AddWithValue("@LetterSpeed", letterSpeed);
                        command.Parameters.AddWithValue("@FormatType", formatType);
                        command.Parameters.AddWithValue("@LetterGap", letterGap);
                        command.Parameters.AddWithValue("@DisplayEffect", displayEffect);
                        command.Parameters.AddWithValue("@FontSize", fontSize);
                        command.Parameters.AddWithValue("@InfoDisplayed", infoDisplayed);
                        command.Parameters.AddWithValue("@DelayTime", delayTime);
                        command.Parameters.AddWithValue("@EraseTime", eraseTime);
                        command.Parameters.AddWithValue("@LanEnglish", defaultEnglish);
                        command.Parameters.AddWithValue("@LanRegional", defaultRegional);
                        command.Parameters.AddWithValue("@LanHindi", defaultHindi);
                      
                        command.ExecuteNonQuery();
                    }
                }

               // MessageBox.Show("Data saved successfully.");
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving data: {ex.Message}");
                return 0;
            }
        }

        public static DataTable GetEthernetPorts()
        {
            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].GetPortsSp", connection))
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

        public static DataTable GetBoardDetails(int HubKey)
        {
            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].[GetChildHubSettingsSp]", connection))
                    {
                        // Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Add the parameter to the command
                        command.Parameters.AddWithValue("@MasterHubKey", HubKey);

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
        public static DataTable GetEnglishBitMap(int fontSize)
        {
            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].[GetEnglishBitMap]", connection))
                    {
                        // Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Add the parameter to the command
                        command.Parameters.AddWithValue("@fontSize", fontSize);

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
        public static DataTable GetHindiBitMap(int fontSize)
        {
            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].[GetHindiBitMap]", connection))
                    {
                        // Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Add the parameter to the command
                        command.Parameters.AddWithValue("@fontSize", fontSize);

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
        public static DataTable GetRegionalBitMap(int fontSize)
        {
            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].[GetRegionalBitMapSp]", connection))
                    {
                        // Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Add the parameter to the command
                        command.Parameters.AddWithValue("@fontSize", fontSize);

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


        public static int DeletePort(int ethernetPort)
        {
            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].DeletePortSp", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add the port number as a parameter to the command
                        command.Parameters.AddWithValue("@ethernetPort", ethernetPort);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return rowsAffected;
                        }
                        else 
                        {
                            return 0;
                           // throw new Exception("No port found with the specified number.");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
                // Handle exceptions (logging, rethrowing, etc.)
               // throw new Exception("Error deleting port: " + ex.Message);
            }
        }
        public static int DeletePdcPort(int pkKey)
        {
            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].DeletePdcPortSp", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add the port number as a parameter to the command
                        command.Parameters.AddWithValue("@Pk", pkKey);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return rowsAffected;
                        }
                        else
                        {
                            return 0;
                            // throw new Exception("No port found with the specified number.");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
                // Handle exceptions (logging, rethrowing, etc.)
                // throw new Exception("Error deleting port: " + ex.Message);
            }
        }

    }
}

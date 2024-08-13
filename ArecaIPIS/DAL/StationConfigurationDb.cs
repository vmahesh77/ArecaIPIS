using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class StationConfigurationDb
    {
        private DbConnection dbConnection;

        public StationConfigurationDb()
        {
            dbConnection = new DbConnection();
        }

        public void SaveStationConfiguration(string stationName, string stationCode, string upStationCode, string downStationCode, 
            string divisionCode, int noOfPlatforms, int portNo, int noOfRowsToDisplay, string ipAddress, List<string> regionalLanguages,
            int MainScreenDisplay)
        {
            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        return;

                    using (var command = new SqlCommand("[config].[SaveStationConfigurationSp]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.AddWithValue("@StationName", stationName);
                        command.Parameters.AddWithValue("@StationCode", stationCode);
                        command.Parameters.AddWithValue("@UpStationcode", upStationCode);
                        command.Parameters.AddWithValue("@DownStationCode", downStationCode);
                        command.Parameters.AddWithValue("@DivisionCode", divisionCode);
                        command.Parameters.AddWithValue("@NoOfPlatforms", noOfPlatforms);
                        command.Parameters.AddWithValue("@PortNo", portNo);
                        command.Parameters.AddWithValue("@OnlineRows", noOfRowsToDisplay);
                        command.Parameters.AddWithValue("@IpAddress", ipAddress);
                        command.Parameters.AddWithValue("@RegionalLanguages", string.Join(",", regionalLanguages));                     
                        command.Parameters.AddWithValue("@MainScreenDisplay", MainScreenDisplay);


                        // Execute the stored procedure
                        command.ExecuteNonQuery();
                        DbConnection.CloseConnection(connection);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving station configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int UpdateStationConfiguration( string stationName, string stationCode, string upStationCode, string downStationCode,
            string divisionCode, int noOfPlatforms, int portNo, int noOfRowsToDisplay, string ipAddress, List<string> regionalLanguages,
            int mainScreenDisplay)
        {
            int rowsAffected = 0;
            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        return rowsAffected;

                    using (var command = new SqlCommand("[config].[UpdateStationConfigurationSp]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                       
                        command.Parameters.AddWithValue("@StationName", stationName);
                        command.Parameters.AddWithValue("@StationCode", stationCode);
                        command.Parameters.AddWithValue("@UpStationcode", upStationCode);
                        command.Parameters.AddWithValue("@DownStationCode", downStationCode);
                        command.Parameters.AddWithValue("@DivisionCode", divisionCode);
                        command.Parameters.AddWithValue("@NoOfPlatforms", noOfPlatforms);
                        command.Parameters.AddWithValue("@PortNo", portNo);
                        command.Parameters.AddWithValue("@OnlineRows", noOfRowsToDisplay);
                        command.Parameters.AddWithValue("@IpAddress", ipAddress);
                        command.Parameters.AddWithValue("@RegionalLanguages", string.Join(",", regionalLanguages));
                        command.Parameters.AddWithValue("@MainScreenDisplay", mainScreenDisplay);

                        // Execute the stored procedure and get the number of rows affected
                        rowsAffected = command.ExecuteNonQuery();
                        DbConnection.CloseConnection(connection);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating station configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rowsAffected;
        }

        public int InsertUpdateStationConfiguration(string stationName, string stationCode, string upStationCode, string downStationCode,
          string divisionCode, int noOfPlatforms, int portNo, int noOfRowsToDisplay, string ipAddress, string regionalLanguages,
          int mainScreenDisplay, DataTable dt)
        {
            int rowsAffected = 0;
            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        return rowsAffected;

                    using (var command = new SqlCommand("[config].[InsertUpdateStationConfigurationSp]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", 1);
                        command.Parameters.AddWithValue("@StationName", stationName);
                        command.Parameters.AddWithValue("@StationCode", stationCode);
                        command.Parameters.AddWithValue("@UpStationcode", upStationCode);
                        command.Parameters.AddWithValue("@DownStationCode", downStationCode);
                        command.Parameters.AddWithValue("@DivisionCode", divisionCode);
                        command.Parameters.AddWithValue("@NoOfPlatforms", noOfPlatforms);
                        command.Parameters.AddWithValue("@PortNo", portNo);
                        command.Parameters.AddWithValue("@OnlineRows", noOfRowsToDisplay);
                        command.Parameters.AddWithValue("@IpAddress", ipAddress);
                        command.Parameters.AddWithValue("@MainScreenDisplay", mainScreenDisplay);
                        command.Parameters.AddWithValue("@platformNames", dt);

                     
                      
                        command.Parameters.AddWithValue("@RegionalLanguages", regionalLanguages);

                        //// Add DataTable as a structured parameter
                        //SqlParameter parameter = command.Parameters.AddWithValue("@platformNames", dt);
                        //parameter.SqlDbType = SqlDbType.Structured;
                        //parameter.TypeName = "dbo.YourDataTableTypeName"; // Replace with the actual table type name

                        // Execute the stored procedure and get the number of rows affected
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating station configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rowsAffected;
        }


        public static DataTable GetRegionalLanguages()
        {
            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].GetRegionalLanguagesSp", connection))
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

        public static void GetStationDetails()
        {
            try
            {
                
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    // Create a command to execute the stored procedure
                    using (SqlCommand command = new SqlCommand("config.GetAllStationDetailsSp", connection))
                    {
                        // Specify that the command is a stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Create a data adapter to retrieve the result set
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Create a DataTable to store the result set
                            DataTable dt = new DataTable();

                            // Fill the DataTable with data from the stored procedure
                            adapter.Fill(dt);

                            // Display or process the retrieved data
                            foreach (DataRow row in dt.Rows)
                            {
                                BaseClass.StationPkId = (int)row["Pkey_StationID"];
                                BaseClass.StationName = (string)row["StationName"];
                                BaseClass.StationCode = (string)row["StationCode"];
                                BaseClass.DivisionCode = (string)row["DivisionCode"];
                                BaseClass.RegionalLanguage1pk = (string)row["RegionalLanguage1"];
                                BaseClass.UpStationCode = (string)row["UpStationcode"];
                                BaseClass.DownStationCode = (string)row["DownStationCode"];
                                BaseClass.OnlineRows = (int)row["OnlineRows"];
                                BaseClass.PortNo = (int)row["PortNo"];
                                BaseClass.MainsCoachDisplay = (int)row["MainsCoachdispaly"];
                                BaseClass.NoOfPlatforms = (int)row["Platforms"];

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static List<string> GetPlatforms()
        {
            List<string> platformNames = new List<string>();

            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    // Create a command to execute the stored procedure
                    using (SqlCommand command = new SqlCommand("config.[GetAllPlatformsSp]", connection))
                    {
                        // Specify that the command is a stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Create a data adapter to retrieve the result set
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Create a DataTable to store the result set
                            DataTable dt = new DataTable();

                            // Fill the DataTable with data from the stored procedure
                            adapter.Fill(dt);

                            // Iterate over the rows of the DataTable and add platform names to the list
                            foreach (DataRow row in dt.Rows)
                            {
                                string platformName = row["PlatformName"].ToString();
                                platformNames.Add(platformName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Handle exceptions as needed
            }

            return platformNames;
        }


    }
}

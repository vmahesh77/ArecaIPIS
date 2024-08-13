using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ArecaIPIS.DAL;

namespace ArecaIPIS.DAL
{
    class LcdTvDb
    {
        private DbConnection dbConnection;

        public LcdTvDb()
        {
            dbConnection = new DbConnection();
        }

        public void InsertcctvSettings(bool coachInfoChk, bool VideoDisplay, bool MessageDisplay, string DefaultMessage, int DateFormat, int scrollingSpeed, string filepath,
                                    string HeaderBackColor, string HeaderForeColor, string HeaderFont, int HeaderFontSize,
                                    string DisplayHeadersBackColor, string DisplayHeadersForeColor, string DisplayHeadersFont, int DisplayHeadersFontSize,
                                    string TrainDetailsBackColor, string TrainDetailsForeColor, string TrainDetailsFont, int TrainDetailsFontSize,
                                    string GeneralMessageBackColor, string GeneralMessageForeColor, string GeneralMessageFont, int GeneralMessageFontSize,
                                    string CoachBackColor, string CoachForeColor, string CoachFont, int CoachFontSize,
                                    string FooterBackColor, string FooterForeColor, string FooterFont, int FooterFontSize)
        {
            try
            {
                // Create connection
                SqlConnection connection = DbConnection.OpenConnection();

                // Create command
                SqlCommand command = new SqlCommand("[config].[InsertCCTVSettingsSP]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddWithValue("@coachInfoChk", coachInfoChk);
                command.Parameters.AddWithValue("@VideoDisplay", VideoDisplay);
                command.Parameters.AddWithValue("@MessageDisplay", MessageDisplay);
                command.Parameters.AddWithValue("@DefaultMessage", DefaultMessage);
                command.Parameters.AddWithValue("@DateFormat", DateFormat);
                command.Parameters.AddWithValue("@scrollingSpeed", scrollingSpeed);
                command.Parameters.AddWithValue("@filepath", filepath);
                command.Parameters.AddWithValue("@HeaderBackColor", HeaderBackColor);
                command.Parameters.AddWithValue("@HeaderForeColor", HeaderForeColor);
                command.Parameters.AddWithValue("@HeaderFont", HeaderFont);
                command.Parameters.AddWithValue("@HeaderFontSize", HeaderFontSize);
                command.Parameters.AddWithValue("@DisplayHeadersBackColor", DisplayHeadersBackColor);
                command.Parameters.AddWithValue("@DisplayHeadersForeColor", DisplayHeadersForeColor);
                command.Parameters.AddWithValue("@DisplayHeadersFont", DisplayHeadersFont);
                command.Parameters.AddWithValue("@DisplayHeadersFontSize", DisplayHeadersFontSize);
                command.Parameters.AddWithValue("@TrainDetailsBackColor", TrainDetailsBackColor);
                command.Parameters.AddWithValue("@TrainDetailsForeColor", TrainDetailsForeColor);
                command.Parameters.AddWithValue("@TrainDetailsFont", TrainDetailsFont);
                command.Parameters.AddWithValue("@TrainDetailsFontSize", TrainDetailsFontSize);
                command.Parameters.AddWithValue("@GeneralMessageBackColor", GeneralMessageBackColor);
                command.Parameters.AddWithValue("@GeneralMessageForeColor", GeneralMessageForeColor);
                command.Parameters.AddWithValue("@GeneralMessageFont", GeneralMessageFont);
                command.Parameters.AddWithValue("@GeneralMessageFontSize", GeneralMessageFontSize);
                command.Parameters.AddWithValue("@CoachBackColor", CoachBackColor);
                command.Parameters.AddWithValue("@CoachForeColor", CoachForeColor);
                command.Parameters.AddWithValue("@CoachFont", CoachFont);
                command.Parameters.AddWithValue("@CoachFontSize", CoachFontSize);
               
                command.Parameters.AddWithValue("@FooterBackColor", FooterBackColor);
                command.Parameters.AddWithValue("@FooterForeColor", FooterForeColor);
                command.Parameters.AddWithValue("@FooterFont", FooterFont);
                command.Parameters.AddWithValue("@FooterFontSize", FooterFontSize);
              


                int rowsAffected = command.ExecuteNonQuery();

                // Close connection
                DbConnection.CloseConnection(connection);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Settings inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to insert settings.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // You may want to handle or log the exception accordingly
            }
        }


        public int updatecctvSettings( int pkValue  , bool coachInfoChk, bool VideoDisplay, bool MessageDisplay, string DefaultMessage, int DateFormat, int scrollingSpeed, string filepath,
                                    string HeaderBackColor, string HeaderForeColor, string HeaderFont, int HeaderFontSize,
                                    string DisplayHeadersBackColor, string DisplayHeadersForeColor, string DisplayHeadersFont, int DisplayHeadersFontSize,
                                    string TrainDetailsBackColor, string TrainDetailsForeColor, string TrainDetailsFont, int TrainDetailsFontSize,
                                    string GeneralMessageBackColor, string GeneralMessageForeColor, string GeneralMessageFont, int GeneralMessageFontSize,
                                    string CoachBackColor, string CoachForeColor, string CoachFont, int CoachFontSize,
                                    string FooterBackColor, string FooterForeColor, string FooterFont, int FooterFontSize, bool SameWindow)
        {
            
            DialogResult result = MessageBox.Show("Do you want to save these settings?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Create connection
                    SqlConnection connection = DbConnection.OpenConnection();

                    // Create command
                    SqlCommand command = new SqlCommand("[config].[InsertOrUpdateCCTVSettingsSP]", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@pkValue", pkValue);
                    command.Parameters.AddWithValue("@coachInfoChk", coachInfoChk);
                    command.Parameters.AddWithValue("@VideoDisplay", VideoDisplay);
                    command.Parameters.AddWithValue("@MessageDisplay", MessageDisplay);
                    command.Parameters.AddWithValue("@DefaultMessage", DefaultMessage);
                    command.Parameters.AddWithValue("@DateFormat", DateFormat);
                    command.Parameters.AddWithValue("@scrollingSpeed", scrollingSpeed);
                    command.Parameters.AddWithValue("@filepath", filepath);
                    command.Parameters.AddWithValue("@HeaderBackColor", HeaderBackColor);
                    command.Parameters.AddWithValue("@HeaderForeColor", HeaderForeColor);
                    command.Parameters.AddWithValue("@HeaderFont", HeaderFont);
                    command.Parameters.AddWithValue("@HeaderFontSize", HeaderFontSize);
                    command.Parameters.AddWithValue("@DisplayHeadersBackColor", DisplayHeadersBackColor);
                    command.Parameters.AddWithValue("@DisplayHeadersForeColor", DisplayHeadersForeColor);
                    command.Parameters.AddWithValue("@DisplayHeadersFont", DisplayHeadersFont);
                    command.Parameters.AddWithValue("@DisplayHeadersFontSize", DisplayHeadersFontSize);
                    command.Parameters.AddWithValue("@TrainDetailsBackColor", TrainDetailsBackColor);
                    command.Parameters.AddWithValue("@TrainDetailsForeColor", TrainDetailsForeColor);
                    command.Parameters.AddWithValue("@TrainDetailsFont", TrainDetailsFont);
                    command.Parameters.AddWithValue("@TrainDetailsFontSize", TrainDetailsFontSize);
                    command.Parameters.AddWithValue("@GeneralMessageBackColor", GeneralMessageBackColor);
                    command.Parameters.AddWithValue("@GeneralMessageForeColor", GeneralMessageForeColor);
                    command.Parameters.AddWithValue("@GeneralMessageFont", GeneralMessageFont);
                    command.Parameters.AddWithValue("@GeneralMessageFontSize", GeneralMessageFontSize);
                    command.Parameters.AddWithValue("@CoachBackColor", CoachBackColor);
                    command.Parameters.AddWithValue("@CoachForeColor", CoachForeColor);
                    command.Parameters.AddWithValue("@CoachFont", CoachFont);
                    command.Parameters.AddWithValue("@CoachFontSize", CoachFontSize);
                    command.Parameters.AddWithValue("@FooterBackColor", FooterBackColor);
                    command.Parameters.AddWithValue("@FooterForeColor", FooterForeColor);
                    command.Parameters.AddWithValue("@FooterFont", FooterFont);
                    command.Parameters.AddWithValue("@FooterFontSize", FooterFontSize);
                    command.Parameters.AddWithValue("@SameWindowChk", SameWindow);



                    int rowsAffected = command.ExecuteNonQuery();
                    rowsAffected = 1;
                    // Close connection
                    DbConnection.CloseConnection(connection);

                    if (rowsAffected > 0)
                    {
                        return rowsAffected;
                    }
                    else;
                    {
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    return -1;
                    MessageBox.Show("Error inserting settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // You may want to handle or log the exception accordingly
                }
            }
            else
            {
                return -1;
                MessageBox.Show("Operation canceled by the user.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static DataTable GetCctvSettings()
        {
     

            try
            {
                // Assuming DbConnection.OpenConnection() returns a valid, open SqlConnection
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].GetCctvsettingsSp", connection))
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
                return null; // Or rethrow the exception if preferred
            }
        }
    }
}

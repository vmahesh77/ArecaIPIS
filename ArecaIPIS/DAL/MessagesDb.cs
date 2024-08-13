using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class MessagesDb
    {

        private DbConnection dbConnection;
     
        public MessagesDb()
        {
            dbConnection = new DbConnection();
        }


        public DataTable GetSpecialMessagesData()
        {
            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("Config.GetallSpecialMessagesDataSP", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        DataTable dt = new DataTable();
                        dt.Load(command.ExecuteReader());

                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving special messages: " + ex.Message);
                
                throw;
            }
        }






        public DataTable GetMessagesByRow(int id)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("Config.GetSpecialMessagesbyRowSP", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@pKeyValue", id);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data from database: " + ex.Message);
            }

            return dataTable;
        }


        public bool InsertOrUpdateMessage(int pkey, string englishMsg, string nationalMsg, string regionalMsg1, string regionalMsg2, string audioFilePath = null)
        {
            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand("config.insertupdateMessagesSP", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;




                        command.Parameters.AddWithValue("@Pkey_SpclMessages", pkey);
                        command.Parameters.AddWithValue("@Englishmsg", englishMsg);
                        command.Parameters.AddWithValue("@NationalMsg", nationalMsg);
                        command.Parameters.AddWithValue("@RegionalMSg1", regionalMsg1);
                        command.Parameters.AddWithValue("@RegionalMsg2", regionalMsg2);
                        command.Parameters.AddWithValue("@AudioFilePath", audioFilePath);

                        //connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                
               MessageBox.Show("An error occurred: " + ex.Message);
           
            }
            return false;
        }
        


        public DataTable CallGetSplMessages1(string PrimaryKeys, int AnnRepeatCount)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("Config.GetSplMessages1", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", PrimaryKeys);
                        command.Parameters.AddWithValue("@AnnRepeatCount", AnnRepeatCount);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data from database: " + ex.Message);
            }

            return dataTable;
        }


        public DataTable getUpdatedStatus(string status)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("Config.UpdateAnnouncementStatus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PlayStatus", status);
                      

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data from database: " + ex.Message);
            }

            return dataTable;
        }


        public bool UpdateAudioPlayStatus(string action)
        {
            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("Scheduled.SetAnnCompleted", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Status", action);

                        int rowsAffected = command.ExecuteNonQuery();

                      
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false; 
                        }




                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data from database: " + ex.Message);
                return false;
            }
        }




    }
}

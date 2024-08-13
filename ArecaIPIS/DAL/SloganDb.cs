using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    class SloganDb
    {

        private DbConnection dbConnection;

        public SloganDb()
        {
            dbConnection = new DbConnection();
        }

        public DataTable GetSloganMessages()
        {
            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("Config.GetSlogansSP", connection))
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
                return null;
            }
        }

        

    public DataTable GetSlogansByRow(int id)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("Config.GetSlogansbyRowSP", connection))
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



        public bool InsertOrUpdateSlogan(int pKey_SpecialMessage, string Msg, string audioFilePath , int Language)
        {

            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand("config.insertupdatesplMessages", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@Pkey_SpclMessages", pKey_SpecialMessage);
                        command.Parameters.AddWithValue("@Message", Msg);
                        command.Parameters.AddWithValue("@AudioFilePath", audioFilePath);
                        command.Parameters.AddWithValue("@LangdID", Language);
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

        public DataTable GetSearchSlogan(string searchQuery)
        {
            DataTable specialSlogan= new DataTable();
            using (var connection = DbConnection.OpenConnection())
            {


                SqlCommand command = new SqlCommand("[config].[GetSearchSlogansSP]", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SearchQuery", searchQuery);

                //SqlParameter recordCountParam = new SqlParameter("@RecordCount", SqlDbType.Int);
                //recordCountParam.Direction = ParameterDirection.Output;
                //command.Parameters.Add(recordCountParam);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(specialSlogan);
            }

            return specialSlogan;
        }
        public string DeleteSlogan(int pkey)
        {
            
            string statusMessage = string.Empty;

            using (var connection = DbConnection.OpenConnection())
            {
                using (SqlCommand command = new SqlCommand("[config].[DeleteSloganMessage]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Pkey_SpclMsgs", pkey);

                    try
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            statusMessage = reader["Status"].ToString();
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        statusMessage = "Error deleting slogan from the database: " + ex.Message;
                    }
                }
            }

            return statusMessage;
        }

    }
}

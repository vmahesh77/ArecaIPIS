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
    class messageScriptDb
    {
        private DbConnection dbConnection;

        public messageScriptDb()
        {
            dbConnection = new DbConnection();
        }
        public DataTable GetAllMessageStatus()
        {
            DataTable dataTable = new DataTable();

            using (var connection = DbConnection.OpenConnection())
            {
                using (SqlCommand command = new SqlCommand("[Config].[Get_STATUS_DROPDOWN_MESSAGES_SP]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public DataTable GetAllTrainPosition()
        {
            DataTable dataTable = new DataTable();

            using (var connection = DbConnection.OpenConnection())
            {
                using (SqlCommand command = new SqlCommand("[Config].[GetTrainPositionSP]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }



        public DataTable GetLanguage()
        {
            DataTable dataTable = new DataTable();

            using (var connection = DbConnection.OpenConnection())
            {
                using (SqlCommand command = new SqlCommand("[Config].[SelectedLanguagesSP]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public (DataTable messageFormat, int recordCount) GetMessageFormat(int pageIndex, int pageSize, int selectedStatus, int selectedLanguage,int selectedPosition)
        {
            DataTable messageFormat = new DataTable();
            int recordCount = 0;

            using (var connection = DbConnection.OpenConnection())
            {


                SqlCommand command = new SqlCommand("[config].[GetMessageFormatsSP]", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PageIndex", pageIndex); 
                command.Parameters.AddWithValue("@PageSize", pageSize);
                command.Parameters.AddWithValue("@StatusMessage", selectedStatus);
                command.Parameters.AddWithValue("@languageid", selectedLanguage);
                command.Parameters.AddWithValue("@PfStatus", selectedPosition);

                SqlParameter recordCountParam = new SqlParameter("@RecordCount", SqlDbType.Int);
                recordCountParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(recordCountParam);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(messageFormat);

                recordCount = (int)recordCountParam.Value;
            }

            return (messageFormat, recordCount);
        }

        public DataTable GetMessageFormatByRow(int id)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("Config.GetMessageFormatbyRowSP", connection))
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

        public bool InsertOrUpdateMessageScript(int pkey, int LanguageName, string messagePath,string MessageName, decimal sequence,int selectedstatus,int position)
        {
            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand("config.insertupdateMessageSP", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Pkey_MessageFormat", pkey);
                        command.Parameters.AddWithValue("@languageid", LanguageName);
                        command.Parameters.AddWithValue("@MessagePath", messagePath);
                        command.Parameters.AddWithValue("@MessageName ", MessageName);
                        command.Parameters.AddWithValue("@sequence", sequence);
                        command.Parameters.AddWithValue("@StatusMessage", selectedstatus);
                        command.Parameters.AddWithValue("@PfStatus", position);

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

    }
}

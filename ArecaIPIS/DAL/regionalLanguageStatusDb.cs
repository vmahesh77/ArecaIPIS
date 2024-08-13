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
    class regionalLanguageStatusDb
    {
        private DbConnection dbConnection;

        public regionalLanguageStatusDb()
        {
            dbConnection = new DbConnection();
        }

        public (DataTable, int) GetRegionalLanguageStatus(int pageIndex, int pagesize)
        {

            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("Config.GetRegionalMessagesSP", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PageIndex", pageIndex);
                        command.Parameters.AddWithValue("@PageSize", pagesize);
                        command.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                        command.Parameters["@RecordCount"].Direction = ParameterDirection.Output;

                        DataTable dt = new DataTable();
                        dt.Load(command.ExecuteReader());

                        int recordCount = Convert.ToInt32(command.Parameters["@RecordCount"].Value);

                        return (dt, recordCount);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving Regional Language Status: " + ex.Message);
                return (null, -1);
            }
        }
        

        public DataTable GetLanguageStatusByRow(int id)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("Config.GetLanguageStatusbyRowSP", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);
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

        public bool InsertOrUpdateMessage(string english, string Hindi, string RLanguage)
        {
            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("config.InsertUpdateStatusSP", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EStatusName", english);
                        cmd.Parameters.AddWithValue("@HStatus", Hindi);
                        cmd.Parameters.AddWithValue("@RStatus", RLanguage);
                        //cmd.Parameters.AddWithValue("@OtherStatus", otherStatus);

                        cmd.ExecuteNonQuery();
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


        public (DataTable Status, int recordCount) GetSearchStatus(int pageIndex, int pageSize, string searchQuery)
        {
            DataTable Status = new DataTable();
            int recordCount = 0;

            using (var connection = DbConnection.OpenConnection())
            {


                SqlCommand command = new SqlCommand("[config].[GetSearchStatusSP]", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", pageSize);
                command.Parameters.AddWithValue("@SearchQuery", searchQuery);

                SqlParameter recordCountParam = new SqlParameter("@RecordCount", SqlDbType.Int);
                recordCountParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(recordCountParam);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(Status);

                recordCount = (int)recordCountParam.Value;
            }

            return (Status, recordCount);
        }


    }
}

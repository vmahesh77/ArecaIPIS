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
    class addCoachDataDb
    {
        private DbConnection dbConnection;
        
        public addCoachDataDb()
        {
            dbConnection = new DbConnection();
        }
        public (DataTable, int) GetCoachData(int pageIndex, int pagesize)
        {

            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("Config.getcoachesSP", connection))
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
                Console.WriteLine("Error retrieving Coach Data: " + ex.Message);
                return (null, -1);
            }
        }

        public DataTable GetCoachDataByRow(int id)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("Config.GetCoachDatabyRowSP", connection))
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


        public bool InsertOrUpdateMessage(int pkey, string english, string Hindi, string Bitmap)
        {
            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand("config.insertupdateCoachDataSP", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Pkey_Coachid", pkey);
                        command.Parameters.AddWithValue("@EnglishCoachName", english);
                        command.Parameters.AddWithValue("@HindiCoachName", Hindi);
                        command.Parameters.AddWithValue("@Bitmap", Bitmap);

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

        public (DataTable coachData, int recordCount) GetSearchCoachdata(int pageIndex, int pageSize, string searchQuery)
        {
            DataTable CoachData = new DataTable();
            int recordCount = 0;

            using (var connection = DbConnection.OpenConnection())
            {


                SqlCommand command = new SqlCommand("[config].[GetSearchCoachDataSP]", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", pageSize);
                command.Parameters.AddWithValue("@SearchQuery", searchQuery);

                SqlParameter recordCountParam = new SqlParameter("@RecordCount", SqlDbType.Int);
                recordCountParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(recordCountParam);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(CoachData);

                recordCount = (int)recordCountParam.Value;
            }

            return (CoachData, recordCount);
        }



    }
}

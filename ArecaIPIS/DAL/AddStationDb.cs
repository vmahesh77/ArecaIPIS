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
    public class AddStationDb
    {


        private DbConnection dbConnection;
     
        public AddStationDb()
        {
            dbConnection = new DbConnection();
        }

        public (DataTable, int) GetAllStationNames(int pageIndex, int pagesize)
        {

            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("Config.GetStationNamesSP", connection))
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
                Console.WriteLine("Error retrieving Station Name: " + ex.Message);
                return (null, -1);
            }
        }

        public bool InsertOrUpdateStationNames(int pkeyStationNames, string stationCode, string stationEng, string stationHind, string stationReg1, string stationReg2, string audioFile = null)
        {

          try
          {
                using (var connection = DbConnection.OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand("[config].[insertupdatestationnamesSP]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Pkey_stationnames", pkeyStationNames);
                        command.Parameters.AddWithValue("@StationCode", stationCode);
                        command.Parameters.AddWithValue("@stationeng", stationEng);
                        command.Parameters.AddWithValue("@stationhind", stationHind);
                        command.Parameters.AddWithValue("@stationreg1", stationReg1);
                        command.Parameters.AddWithValue("@stationreg2", stationReg2);
                        command.Parameters.AddWithValue("@AudoFile", audioFile);

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


        //public int InsertStationNames(string StationCode, string EnglishStationName, string HindiStationName, string RegionalStationName, string filePath)
        //{
        //    try
        //    {
        //        using (var connection = dbConnection.OpenConnection())
        //        {
        //            if (connection == null)
        //                throw new Exception("Database connection is null.");

        //            using (SqlCommand insertCommand = new SqlCommand("[config].[InsertStationNameSp]", connection))
        //            {
        //                insertCommand.CommandType = CommandType.StoredProcedure;
        //                insertCommand.Parameters.AddWithValue("@StationCode", StationCode);
        //                insertCommand.Parameters.AddWithValue("@StationEng", EnglishStationName);
        //                insertCommand.Parameters.AddWithValue("@StationHind", HindiStationName);
        //                insertCommand.Parameters.AddWithValue("@StationReg1", RegionalStationName);
        //                insertCommand.Parameters.AddWithValue("@StationReg2", ""); // Assuming there's no value for StationReg2 in your case
        //                insertCommand.Parameters.AddWithValue("@AudioFile", filePath);
        //                int rowsAffected = insertCommand.ExecuteNonQuery();

        //                MessageBox.Show("New station names inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return rowsAffected;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An error occurred during insertion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return 0;
        //    }
        //}

        //public int UpdateStationNames(int pk, string StationCode, string EnglishStationName, string HindiStationName, string RegionalStationName, string filePath)
        //{
        //    try
        //    {
        //        using (var connection = dbConnection.OpenConnection())
        //        {
        //            if (connection == null)
        //                throw new Exception("Database connection is null.");

        //            using (SqlCommand updateCommand = new SqlCommand("[config].[UpdateStationNameSp]", connection))
        //            {
        //                updateCommand.CommandType = CommandType.StoredProcedure;
        //                updateCommand.Parameters.AddWithValue("@Pkey", pk);
        //                updateCommand.Parameters.AddWithValue("@StationCode", StationCode);
        //                updateCommand.Parameters.AddWithValue("@StationEng", EnglishStationName);
        //                updateCommand.Parameters.AddWithValue("@StationHind", HindiStationName);
        //                updateCommand.Parameters.AddWithValue("@StationReg1", RegionalStationName);
        //                updateCommand.Parameters.AddWithValue("@StationReg2", ""); // Assuming there's no value for StationReg2 in your case
        //                updateCommand.Parameters.AddWithValue("@AudioFile", filePath);
        //                int rowsAffected = updateCommand.ExecuteNonQuery();

        //                MessageBox.Show("Station names updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return rowsAffected;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An error occurred during update: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return 0;
        //    }
        //}
        public DataTable GetStationNameByRow(int id)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("Config.GetStationNamebyRowSP", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StationId", id);
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

        public (DataTable StationName, int recordCount) GetSearchStation(int pageIndex, int pageSize, string searchQuery)
        {
            DataTable StationName = new DataTable();
            int recordCount = 0;

            using (var connection = DbConnection.OpenConnection())
            {


                SqlCommand command = new SqlCommand("[config].[GetSearchStationSP]", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", pageSize);
                command.Parameters.AddWithValue("@SearchQuery", searchQuery);

                SqlParameter recordCountParam = new SqlParameter("@RecordCount", SqlDbType.Int);
                recordCountParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(recordCountParam);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(StationName);

                recordCount = (int)recordCountParam.Value;
            }

            return (StationName, recordCount);
        }
    }
}

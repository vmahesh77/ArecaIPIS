using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArecaIPIS.DAL;
namespace ArecaIPIS.DAL
{
    class OnlineTrainsDao
    {
        public static int GetTopRegGapCode()
        {
            int regGapCode = 0; // Default or invalid value

            using (SqlConnection connection = DbConnection.OpenConnection())
            {
                SqlCommand command = new SqlCommand("GetTopRegGapCode", connection);
                command.CommandType = CommandType.StoredProcedure;

                

                // Execute the command
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        regGapCode = Convert.ToInt32(reader["REG_GAPCODE"]);
                    }
                }

                reader.Close();
            }

            return regGapCode;
        }
        public static DataTable getTrainNumber(string searchQuery)
        {
            DataTable specialSlogan = new DataTable();
            using (var connection = DbConnection.OpenConnection())
            {


                SqlCommand command = new SqlCommand("[config].[GetTrainNumberSP]", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SearchQuery", searchQuery);

                

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(specialSlogan);
            }

            return specialSlogan;
        }
        public static string[] coachPositions(string trainNumber)
        {
            string[] coachValues = null; 
            DataTable coachPositionsdt = OnlineTrainsDao.getCoachPositionsByTrainNumber(trainNumber);


            foreach (DataRow coachRow in coachPositionsdt.Rows)
            {
                string coachpositions = coachRow["coachPositions"].ToString();
                coachValues = coachpositions.Split(',');

            }
            return coachValues;
        }
       

        public DataTable GetStatusByNameAndFor(string statusName, string statusFor)
        {

            DataTable dataTable = new DataTable();

            
            using (SqlConnection connection = DbConnection.OpenConnection())
            {
                
                using (SqlCommand command = new SqlCommand("GetStatusTableByStatusNamesSP", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the parameters required by the stored procedure
                    command.Parameters.Add(new SqlParameter("@StatusName", SqlDbType.NVarChar, 50)).Value = statusName;
                    command.Parameters.Add(new SqlParameter("@StatusFor", SqlDbType.NVarChar, 50)).Value = statusFor;

                    // Create a SqlDataAdapter to execute the command and fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Open the connection
                        connection.Open();

                        // Fill the DataTable with the results of the query
                        adapter.Fill(dataTable);
                    }
                }
            }

            // Return the filled DataTable
            return dataTable;
        }

     

  public static DataTable GetDivertedToTerminatedStationsNames()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = DbConnection.OpenConnection())
            {
                using (SqlCommand command = new SqlCommand("[dbo].GetDivetedToTerminatedStationNamesSp", connection))
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
        public static DataTable GetTopScheduledTaddbRecords()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = DbConnection.OpenConnection())
            {
                using (SqlCommand command = new SqlCommand("[Scheduled].getScheduledRunningTrainsTADDBSP", connection))
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


        public static void DeleteTrainFromRunningTrains(string trainNumber)
        {
            using (SqlConnection connection = DbConnection.OpenConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("config.DeleteTrainFromRunningTrainsSP", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TrainNumber", trainNumber);
                       command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                   
                }
            }
        }



        public static bool DeleteTrainByNumber(string trainNumber)
        {
            using (SqlConnection connection = DbConnection.OpenConnection())
            {
                try
                {
                    

                    using (SqlCommand command = new SqlCommand("config.DeleteTrainByNumberFromTrainsSP", connection))
                    {
                        
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TrainNumber", trainNumber);
                   
                        int rowsAffected = command.ExecuteNonQuery();

                        // If one or more rows were affected, the deletion was successful
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (not shown here)
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return false;
                }
            }
        }



        public static DataTable GetArrivalAndDepartureStatus()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = DbConnection.OpenConnection())
            {
                using (SqlCommand command = new SqlCommand("[config].GetArrivalAndDepartureStatusSP", connection))
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



        public static bool InsertUpdateTrainDetails(int id, string trainNumber, string trainType, string category, string source, string destination,
            string via, string englishName, string hindiName, string regionalName, string arrivalTime, string departureTime, string platform,
         string status, DataTable RunningTrainDirections, List<string> coachPositionList)
        {
            try
            {
                const string storedProcedure = "[Config].[InsertUpdateTrainsInformationSp]";
                using (var connection = DbConnection.OpenConnection())
                {
                    using (var command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Create and add parameters to the command
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@TrainNumber", trainNumber);
                        command.Parameters.AddWithValue("@TrainType", trainType);
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@Source", source);
                        command.Parameters.AddWithValue("@Destination", destination);
                        command.Parameters.AddWithValue("@Via", via);
                        command.Parameters.AddWithValue("@EnglishName", englishName);
                        command.Parameters.AddWithValue("@HindiName", hindiName);
                        command.Parameters.AddWithValue("@RegionalName", regionalName);
                        command.Parameters.AddWithValue("@ArrivalTime", arrivalTime);
                        command.Parameters.AddWithValue("@DepartureTime", departureTime);
                        command.Parameters.AddWithValue("@Platform", platform);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@TrainInfo", RunningTrainDirections);
                       

                        string coachPositions = string.Join(",", coachPositionList);
                        command.Parameters.AddWithValue("@CoachPositions", coachPositions);



                        int rowsAffected = command.ExecuteNonQuery();

                        // Return true if rows were affected, indicating a successful delete
                        return rowsAffected > 0;

                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or display a message
                MessageBox.Show("An error occurred: " + ex.Message);
                return false;
            }
        }

        private static DataTable ConvertListToDataTable(List<string> coachPositionList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CoachPosition", typeof(string));

            foreach (string coach in coachPositionList)
            {
                dt.Rows.Add(coach);
            }

            return dt;
        }


        public static bool CheckTrainExisted(string trainNumber)
        {
            try
            {
                using (SqlConnection connection = DbConnection.OpenConnection())
                {
                    string query = "SELECT COUNT(1) FROM [config].[TrainDetails] WHERE TrainNumber = @TrainNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainNumber", trainNumber);


                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception e)
            {
                // Handle the exception, log it, or display a message
                Console.WriteLine("An error occurred: " + e.Message);
            }

            return false;
        }

        public static bool DeleteTrainDetails(string trainID)
        {
            try
            {
                const string storedProcedure = "[config].[DeleteTrainInformationSp]";
                using (var connection = DbConnection.OpenConnection())
                {
                    using (var command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add the TrainID parameter
                        command.Parameters.AddWithValue("@TrainID", trainID);

                        int rowsAffected = command.ExecuteNonQuery();

                        // Return true if rows were affected, indicating a successful delete
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or display a message
                MessageBox.Show("An error occurred: " + ex.Message);
                return false;
            }
        }
        public static DataTable GetTrainByNumber(string trainNumber)
        {


            using (SqlConnection connection = DbConnection.OpenConnection())
            {
                using (SqlCommand command = new SqlCommand("[config].[GetTrainByNumberSP]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TrainNumber", trainNumber);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public static DataTable GetTrainByTrainDirtections(string trainNumber)
        {
            try
            {
                using (SqlConnection connection = DbConnection.OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand("[config].[GetTrainDirectionsByTrainNumberSP]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TrainNumber", trainNumber);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                e.ToString();
            }
            return null;
        }           


        public static DataTable GetAllTrains()
        {
            

            using (SqlConnection connection = DbConnection.OpenConnection())
            {
                using (SqlCommand command = new SqlCommand("[config].[GetAllTrainsSP]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public static DataTable GetTrains()
        {


            using (SqlConnection connection = DbConnection.OpenConnection())
            {
                using (SqlCommand command = new SqlCommand("GetTrainsSP", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

      public  static DataTable getCoachPositionsByTrainNumber(string trainNumber)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection =DbConnection.OpenConnection())
            {
                SqlCommand command = new SqlCommand("[config].[GetCoachPositionsByTrainNumberSP]", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TrainNumber", trainNumber);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                try
                {
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            return dataTable;
        }

        public static DataTable GetStatusByName(string statusName)
        {
            DataTable dataTable = new DataTable();        
            using (SqlConnection connection =DbConnection.OpenConnection())
            {
                using (SqlCommand command = new SqlCommand("[Scheduled].[GetStatusByNameSP]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StatusName", statusName);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }


        public static DataTable GetAllStatus()
        {
           
            DataTable dataTable = new DataTable();

            // Use a using block to ensure the connection is properly closed and disposed
            using (SqlConnection connection = DbConnection.OpenConnection())
            {
                // Create a SqlCommand to execute the stored procedure
                using (SqlCommand command = new SqlCommand("GetAllStatusSP", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Create a SqlDataAdapter to execute the command and fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Open the connection
                 

                        // Fill the DataTable with the results of the query
                        adapter.Fill(dataTable);
                    }
                }
            }

            // Return the filled DataTable
            return dataTable;
        }

    }
}

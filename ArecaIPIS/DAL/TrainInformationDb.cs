using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ArecaIPIS.DAL
{
    class TrainInformationDb
    {
      

        public TrainInformationDb()
        {
           
        }

        public static List<string> GetTrainTypes()
        {
            List<string> trainTypes = new List<string>();

            try
            {
                // Open a database connection
                using (var connection = DbConnection.OpenConnection())
                {
                    // Check if the connection is established
                    if (connection != null)
                    {
                        // Create a command to execute the stored procedure
                        using (var command = new SqlCommand("[config].[GetTrainTypes]", connection))
                        {
                            // Specify that the command is a stored procedure
                            command.CommandType = CommandType.StoredProcedure;

                            // Execute the command and retrieve the data
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                // Check if the reader has rows
                                if (reader.HasRows)
                                {
                                    // Iterate over the rows and add train types to the list
                                    while (reader.Read())
                                    {
                                        // Assuming the train type is stored in the first column
                                        string trainType = reader.GetString(0);
                                        trainTypes.Add(trainType);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return trainTypes;
        }
    }
}

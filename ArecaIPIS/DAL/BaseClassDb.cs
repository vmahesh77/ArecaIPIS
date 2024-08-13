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
    class BaseClassDb
    {
       
            private DbConnection dbConnection;

            public BaseClassDb()
            {
                dbConnection = new DbConnection();
            }

            public static DataTable GetDisplayEffects()
            {
                try
                {
                    // Your database connection code (assuming dbConnection is a valid object)
                    using (var connection = DbConnection.OpenConnection())
                    {
                        if (connection == null)
                            throw new Exception("Database connection is null.");

                        using (SqlCommand command = new SqlCommand("[config].GetDisplayEffectsSp", connection))
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
            public static DataTable GetLetterSpeed()
            {
                try
                {
                    // Your database connection code (assuming dbConnection is a valid object)
                    using (var connection = DbConnection.OpenConnection())
                    {
                        if (connection == null)
                            throw new Exception("Database connection is null.");

                        using (SqlCommand command = new SqlCommand("[config].GetLetterSpeedSp", connection))
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
        public static DataTable GetinfoDisplay()
        {
            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].GetInfodisplayedSp", connection))
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

        public static DataTable GetPacketIdentifier()
        {
            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].GetPacketIdentifierSP", connection))
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


        public static DataTable GetFormatType()
        {
            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].GetFormatTypeSp", connection))
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

        public static DataTable GetFormats()
        {
            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].GetFormatsSp", connection))
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
        public static DataTable GetFontSize()
        {
            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].GetFontSizeSp", connection))
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
        public static DataTable GetLetterGap()
        {
            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].GetLetterGapSp", connection))
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
        public static DataTable GetIVDOVDSpeed()
        {
            try
            {
                // Your database connection code (assuming dbConnection is a valid object)
                using (var connection = DbConnection.OpenConnection())
                {
                    if (connection == null)
                        throw new Exception("Database connection is null.");

                    using (SqlCommand command = new SqlCommand("[config].GetLetterSpeedIvdOvdSp", connection))
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
    }


    }

using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DataAccess
{
    public class LicenseClassData
    {
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM LicenseClasses";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return dt;
        }

        public static bool GetLicenseClassInfoByID(int LicenseClassID, out string ClassName, out decimal ClassFees)
        {
            bool isFound = false;
            ClassName = string.Empty;
            ClassFees = 0;

            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            ClassName = reader["ClassName"] != DBNull.Value ? (string)reader["ClassName"] : "";
                            ClassFees = reader["ClassFees"] != DBNull.Value ? Convert.ToDecimal(reader["ClassFees"]) : 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return isFound;
        }


        public static bool GetLicenseClassInfoByID(int LicenseClassID, out string ClassName, out decimal ClassFees, out byte DefaultValidityLength)
        {
            bool isFound = false;
            ClassName = string.Empty; ClassFees = 0; DefaultValidityLength = 0;

            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            ClassName = reader["ClassName"] != DBNull.Value ? (string)reader["ClassName"] : "";
                            ClassFees = reader["ClassFees"] != DBNull.Value ? Convert.ToDecimal(reader["ClassFees"]) : 0;
                            DefaultValidityLength = reader["DefaultValidityLength"] != DBNull.Value ? Convert.ToByte(reader["DefaultValidityLength"]) : (byte)0;
                        }
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return isFound;
        }
    }
}
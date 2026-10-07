using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DataAccess
{
    public class DriverData
    {

        public static int GetPersonIdByDriverId(int DriverID)
        {
            int personId = 0;
            string query = "SELECT PersonID FROM Drivers WHERE DriverID=@DriverID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DriverID", DriverID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null) personId = Convert.ToInt32(result);
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return personId;
        }
        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            string query = @"
SELECT 
    D.DriverID,
    D.PersonID,
    P.NationalNo AS [National No.],
    (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS [Full Name],
    D.CreatedDate AS [Date],
    (SELECT COUNT(*) FROM Licenses L WHERE L.DriverID = D.DriverID AND L.IsActive = 1) AS [Active Licenses]
FROM Drivers D
INNER JOIN People P ON D.PersonID = P.PersonID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows) dt.Load(reader);
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return dt;
        }
        public static int AddNewDriver(int PersonID, int CreatedByUserID)
        {
            int ID = -1;
            string query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
VALUES (@PersonID, @CreatedBy, @Date); SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@CreatedBy", CreatedByUserID);
                command.Parameters.AddWithValue("@Date", DateTime.Now);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int value)) ID = value;
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return ID;
        }

        public static bool GetDriverByPersonID(int PersonID, out int DriverID)
        {
            bool isFound = false;
            DriverID = -1;
            string query = "SELECT DriverID FROM Drivers WHERE PersonID=@PersonID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null) { isFound = true; DriverID = Convert.ToInt32(result); }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return isFound;
        }
    }
}
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DataAccess
{
    public class DetainedLicenseData
    {
        public static bool IsLicenseDetained(int LicenseID)
        {
            bool detained = false;
            string query = "SELECT COUNT(*) FROM DetainedLicenses WHERE LicenseID=@LicenseID AND IsReleased=0";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                try
                {
                    connection.Open();
                    detained = Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return detained;
        }

        public static int AddNewDetain(int LicenseID, decimal FineFees, int CreatedByUserID)
        {
            int ID = -1;
            string query = @"INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedBy, 0); SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                command.Parameters.AddWithValue("@DetainDate", DateTime.Now);
                command.Parameters.AddWithValue("@FineFees", FineFees);
                command.Parameters.AddWithValue("@CreatedBy", CreatedByUserID);
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

        public static bool GetActiveDetainByLicenseID(int LicenseID, out int DetainID, out DateTime DetainDate, out decimal FineFees)
        {
            bool isFound = false;
            DetainID = -1; DetainDate = DateTime.MinValue; FineFees = 0;

            string query = "SELECT * FROM DetainedLicenses WHERE LicenseID=@LicenseID AND IsReleased=0";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            DetainID = Convert.ToInt32(reader["DetainID"]);
                            DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                            FineFees = Convert.ToDecimal(reader["FineFees"]);
                        }
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return isFound;
        }

        public static bool ReleaseDetain(int DetainID, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rows = 0;
            string query = @"UPDATE DetainedLicenses
SET IsReleased=1, ReleaseDate=@ReleaseDate, ReleasedByUserID=@ReleasedBy, ReleaseApplicationID=@ReleaseAppID
WHERE DetainID=@DetainID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DetainID", DetainID);
                command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
                command.Parameters.AddWithValue("@ReleasedBy", ReleasedByUserID);
                command.Parameters.AddWithValue("@ReleaseAppID", ReleaseApplicationID);
                try
                {
                    connection.Open();
                    rows = command.ExecuteNonQuery();
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return rows > 0;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();
            string query = @"
SELECT 
    DL.DetainID AS [D.ID],
    DL.LicenseID AS [L.ID],
    DL.DetainDate AS [D.Date],
    DL.IsReleased AS [Is Released],
    DL.FineFees AS [Fine Fees],
    DL.ReleaseDate AS [Release Date],
    P.NationalNo AS [N.No],
    (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS [Full Name],
    DL.ReleaseApplicationID AS [Rlease App.ID]
FROM DetainedLicenses DL
INNER JOIN Licenses L ON DL.LicenseID = L.LicenseID
INNER JOIN Drivers D ON L.DriverID = D.DriverID
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
    }
}
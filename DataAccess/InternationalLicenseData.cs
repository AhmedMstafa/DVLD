using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DataAccess
{
    public class InternationalLicenseData
    {
        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, int CreatedByUserID)
        {
            int ID = -1;
            string query = @"INSERT INTO InternationalLicenses
(ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
VALUES (@AppID, @DriverID, @LocalLicenseID, @IssueDate, @ExpDate, 1, @CreatedBy);
SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AppID", ApplicationID);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@LocalLicenseID", IssuedUsingLocalLicenseID);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ExpDate", ExpirationDate);
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
        public static DataTable GetAllInternationalLicenseApplications()
        {
            DataTable dt = new DataTable();
            string query = @"
SELECT 
    IL.InternationalLicenseID AS [Intl License ID],
    A.ApplicationID,
    IL.DriverID,
    IL.IssuedUsingLocalLicenseID AS [L.License ID],
    IL.IssueDate,
    IL.ExpirationDate,
    IL.IsActive
FROM InternationalLicenses IL
INNER JOIN Applications A ON IL.ApplicationID = A.ApplicationID";

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

        public static bool GetInternationalLicenseDetailsByID(int InternationalLicenseID,
            out int ApplicationID, out int DriverID, out int LocalLicenseID,
            out string FullName, out string NationalNo, out int Gender, out DateTime DateOfBirth,
            out DateTime IssueDate, out DateTime ExpirationDate, out bool IsActive,
            out DateTime ApplicationDate, out decimal Fees, out string CreatedByUserName)
        {
            bool isFound = false;
            ApplicationID = 0; DriverID = 0; LocalLicenseID = 0; FullName = ""; NationalNo = "";
            Gender = 0; DateOfBirth = DateTime.MinValue; IssueDate = DateTime.MinValue; ExpirationDate = DateTime.MinValue;
            IsActive = false; ApplicationDate = DateTime.MinValue; Fees = 0; CreatedByUserName = "";

            string query = @"
SELECT 
    IL.ApplicationID, IL.DriverID, IL.IssuedUsingLocalLicenseID, IL.IssueDate, IL.ExpirationDate, IL.IsActive,
    A.ApplicationDate, A.PaidFees,
    U.UserName AS CreatedByUserName,
    P.FirstName, P.SecondName, P.ThirdName, P.LastName, P.NationalNo, P.Gendor, P.DateOfBirth
FROM InternationalLicenses IL
INNER JOIN Applications A ON IL.ApplicationID = A.ApplicationID
INNER JOIN Users U ON A.CreatedByUserID = U.UserID
INNER JOIN Drivers D ON IL.DriverID = D.DriverID
INNER JOIN People P ON D.PersonID = P.PersonID
WHERE IL.InternationalLicenseID = @ID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", InternationalLicenseID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                            DriverID = Convert.ToInt32(reader["DriverID"]);
                            LocalLicenseID = reader["IssuedUsingLocalLicenseID"] != DBNull.Value ? Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]) : 0;
                            IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                            IsActive = Convert.ToBoolean(reader["IsActive"]);
                            ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                            Fees = Convert.ToDecimal(reader["PaidFees"]);
                            CreatedByUserName = (string)reader["CreatedByUserName"];
                            FullName = $"{reader["FirstName"]} {reader["SecondName"]} {reader["ThirdName"]} {reader["LastName"]}";
                            NationalNo = reader["NationalNo"] != DBNull.Value ? (string)reader["NationalNo"] : "";
                            Gender = reader["Gendor"] != DBNull.Value ? Convert.ToInt32(reader["Gendor"]) : 0;
                            DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(reader["DateOfBirth"]) : DateTime.MinValue;
                        }
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return isFound;
        }

        public static bool HasEligibleLocalLicense(int DriverID, int RequiredLicenseClassID)
        {
            bool eligible = false;
            string query = @"SELECT COUNT(*) FROM Licenses
WHERE DriverID = @DriverID AND LicenseClass = @ClassID AND IsActive = 1";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@ClassID", RequiredLicenseClassID);
                try
                {
                    connection.Open();
                    eligible = Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return eligible;
        }

        public static bool HasActiveInternationalLicense(int DriverID)
        {
            bool exists = false;
            string query = "SELECT COUNT(*) FROM InternationalLicenses WHERE DriverID=@DriverID AND IsActive=1";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DriverID", DriverID);
                try
                {
                    connection.Open();
                    exists = Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return exists;
        }
    }
}
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DataAccess
{
    public class LicenseData
    {
        public static bool DeactivateLicense(int LicenseID)
        {
            int rows = 0;
            string query = "UPDATE Licenses SET IsActive = 0 WHERE LicenseID = @LicenseID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                try
                {
                    connection.Open();
                    rows = command.ExecuteNonQuery();
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return rows > 0;
        }
        public static bool GetLicenseDetailsByLicenseID(int LicenseID,
    out int DriverID, out int PersonID, out int ApplicationID, out string ClassName, out string FullName, out string NationalNo,
    out int Gender, out DateTime DateOfBirth, out DateTime IssueDate, out DateTime ExpirationDate,
    out string Notes, out bool IsActive, out string ImagePath)
        {
            bool isFound = false;
            DriverID = 0; PersonID = 0; ApplicationID = 0; ClassName = ""; FullName = ""; NationalNo = ""; Gender = 0;
            DateOfBirth = DateTime.MinValue; IssueDate = DateTime.MinValue; ExpirationDate = DateTime.MinValue;
            Notes = ""; IsActive = false; ImagePath = "";

            string query = @"
SELECT L.LicenseID, L.DriverID, L.ApplicationID, L.LicenseClass, L.IssueDate, L.ExpirationDate, L.Notes, L.IsActive,
       LC.ClassName, D.PersonID,
       P.FirstName, P.SecondName, P.ThirdName, P.LastName, P.NationalNo, P.Gendor, P.DateOfBirth, P.ImagePath
FROM Licenses L
INNER JOIN LicenseClasses LC ON L.LicenseClass = LC.LicenseClassID
INNER JOIN Drivers D ON L.DriverID = D.DriverID
INNER JOIN People P ON D.PersonID = P.PersonID
WHERE L.LicenseID = @LicenseID";

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
                            DriverID = Convert.ToInt32(reader["DriverID"]);
                            PersonID = Convert.ToInt32(reader["PersonID"]);
                            ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                            ClassName = (string)reader["ClassName"];
                            FullName = $"{reader["FirstName"]} {reader["SecondName"]} {reader["ThirdName"]} {reader["LastName"]}";
                            NationalNo = reader["NationalNo"] != DBNull.Value ? (string)reader["NationalNo"] : "";
                            Gender = reader["Gendor"] != DBNull.Value ? Convert.ToInt32(reader["Gendor"]) : 0;
                            DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(reader["DateOfBirth"]) : DateTime.MinValue;
                            IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                            Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : "";
                            IsActive = Convert.ToBoolean(reader["IsActive"]);
                            ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "";
                        }
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return isFound;
        }
        public static DataTable GetInternationalLicensesByDriverID(int DriverID)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT InternationalLicenseID, IssueDate, ExpirationDate, IsActive
FROM InternationalLicenses
WHERE DriverID=@DriverID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DriverID", DriverID);
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
        public static bool GetLicenseDetailsByApplicationID(int ApplicationID,
    out int LicenseID, out string ClassName, out string FullName, out string NationalNo,
    out int Gender, out DateTime DateOfBirth, out DateTime IssueDate, out DateTime ExpirationDate,
    out string Notes, out bool IsActive, out int DriverID, out string ImagePath)
        {
            bool isFound = false;
            LicenseID = 0; ClassName = ""; FullName = ""; NationalNo = ""; Gender = 0;
            DateOfBirth = DateTime.MinValue; IssueDate = DateTime.MinValue; ExpirationDate = DateTime.MinValue;
            Notes = ""; IsActive = false; DriverID = 0; ImagePath = "";

            string query = @"
SELECT 
    L.LicenseID, L.IssueDate, L.ExpirationDate, L.Notes, L.IsActive, L.DriverID,
    LC.ClassName,
    P.FirstName, P.SecondName, P.ThirdName, P.LastName, P.NationalNo, P.Gendor, P.DateOfBirth, P.ImagePath
FROM Licenses L
INNER JOIN LicenseClasses LC ON L.LicenseClass = LC.LicenseClassID
INNER JOIN Drivers D ON L.DriverID = D.DriverID
INNER JOIN People P ON D.PersonID = P.PersonID
WHERE L.ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            LicenseID = Convert.ToInt32(reader["LicenseID"]);
                            ClassName = (string)reader["ClassName"];
                            FullName = $"{reader["FirstName"]} {reader["SecondName"]} {reader["ThirdName"]} {reader["LastName"]}";
                            NationalNo = reader["NationalNo"] != DBNull.Value ? (string)reader["NationalNo"] : "";
                            Gender = reader["Gendor"] != DBNull.Value ? Convert.ToInt32(reader["Gendor"]) : 0;
                            DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(reader["DateOfBirth"]) : DateTime.MinValue;
                            IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                            Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : "";
                            IsActive = Convert.ToBoolean(reader["IsActive"]);
                            DriverID = Convert.ToInt32(reader["DriverID"]);
                            ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "";
                        }
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return isFound;
        }
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate,
          DateTime ExpirationDate, decimal PaidFees, string Notes, int CreatedByUserID)
        {
            int ID = -1;
            string query = @"INSERT INTO Licenses
(ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, CreatedByUserID)
VALUES (@AppID, @DriverID, @Class, @IssueDate, @ExpDate, @Notes, @Fees, 1, @CreatedBy);
SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AppID", ApplicationID);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@Class", LicenseClass);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ExpDate", ExpirationDate);
                command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
                command.Parameters.AddWithValue("@Fees", PaidFees);
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

        public static DataTable GetLicenseByApplicationID(int ApplicationID)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Licenses WHERE ApplicationID=@AppID";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AppID", ApplicationID);
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

        public static DataTable GetLocalLicensesByDriverID(int DriverID)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT L.LicenseID, LC.ClassName, L.IssueDate, L.ExpirationDate, L.IsActive
FROM Licenses L INNER JOIN LicenseClasses LC ON L.LicenseClass = LC.LicenseClassID
WHERE L.DriverID=@DriverID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DriverID", DriverID);
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
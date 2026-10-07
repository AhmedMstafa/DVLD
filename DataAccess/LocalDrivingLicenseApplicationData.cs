using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DataAccess
{
    public class LocalDrivingLicenseApplicationData
    {

        public static bool GetApplicationDetailsByID(int LocalDrivingLicenseApplicationID,
    out int ApplicationID, out int PersonID, out string FullName,
    out DateTime ApplicationDate, out byte ApplicationStatus, out DateTime LastStatusDate,
    out decimal PaidFees, out string ApplicationTypeTitle, out string CreatedByUserName,
    out int LicenseClassID, out string ClassName)
        {
            bool isFound = false;
            ApplicationID = 0; PersonID = 0; FullName = ""; ApplicationDate = DateTime.MinValue;
            ApplicationStatus = 0; LastStatusDate = DateTime.MinValue; PaidFees = 0;
            ApplicationTypeTitle = ""; CreatedByUserName = ""; LicenseClassID = 0; ClassName = "";

            string query = @"
SELECT 
    LDL.LocalDrivingLicenseApplicationID,
    A.ApplicationID,
    A.ApplicantPersonID,
    (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS FullName,
    A.ApplicationDate,
    A.ApplicationStatus,
    A.LastStatusDate,
    A.PaidFees,
    AT.ApplicationTypeTitle,
    U.UserName AS CreatedByUserName,
    LDL.LicenseClassID,
    LC.ClassName
FROM LocalDrivingLicenseApplications LDL
INNER JOIN Applications A ON LDL.ApplicationID = A.ApplicationID
INNER JOIN People P ON A.ApplicantPersonID = P.PersonID
INNER JOIN ApplicationTypes AT ON A.ApplicationTypeID = AT.ApplicationTypeID
INNER JOIN Users U ON A.CreatedByUserID = U.UserID
INNER JOIN LicenseClasses LC ON LDL.LicenseClassID = LC.LicenseClassID
WHERE LDL.LocalDrivingLicenseApplicationID = @ID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", LocalDrivingLicenseApplicationID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                            PersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                            FullName = (string)reader["FullName"];
                            ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                            ApplicationStatus = Convert.ToByte(reader["ApplicationStatus"]);
                            LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                            ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                            CreatedByUserName = (string)reader["CreatedByUserName"];
                            LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                            ClassName = (string)reader["ClassName"];
                        }
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return isFound;
        }
        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int ID = -1;

            string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
VALUES (@ApplicationID, @LicenseClassID); SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int value))
                        ID = value;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return ID;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();

            string query = @"
SELECT 
    LDL.LocalDrivingLicenseApplicationID AS [L.D.L.AppID],
    LC.ClassName AS [Driving Class],
    P.NationalNo AS [National No.],
    (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS [Full Name],
    A.ApplicationDate AS [Application Date],
    0 AS [Passed Tests],
    CASE A.ApplicationStatus 
         WHEN 1 THEN 'New'
         WHEN 2 THEN 'Completed'
         WHEN 3 THEN 'Cancelled'
         ELSE 'Unknown'
    END AS [Status]
FROM LocalDrivingLicenseApplications LDL
INNER JOIN Applications A ON LDL.ApplicationID = A.ApplicationID
INNER JOIN LicenseClasses LC ON LDL.LicenseClassID = LC.LicenseClassID
INNER JOIN People P ON A.ApplicantPersonID = P.PersonID";

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
    }
}
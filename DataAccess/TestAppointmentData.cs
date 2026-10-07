using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DataAccess
{
    public class TestAppointmentData
    {
        public static int AddNewTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID)
        {
            int ID = -1;
            string query = @"INSERT INTO TestAppointments
(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID)
VALUES (@TestTypeID, @AppID, @Date, @Fees, @CreatedBy); SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@AppID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@Date", AppointmentDate);
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

        public static bool UpdateTestAppointment(int TestAppointmentID, DateTime AppointmentDate, decimal PaidFees)
        {
            int rows = 0;
            string query = @"UPDATE TestAppointments SET AppointmentDate=@Date, PaidFees=@Fees
WHERE TestAppointmentID=@ID AND NOT EXISTS (SELECT 1 FROM Tests WHERE TestAppointmentID=@ID)";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", TestAppointmentID);
                command.Parameters.AddWithValue("@Date", AppointmentDate);
                command.Parameters.AddWithValue("@Fees", PaidFees);
                try { connection.Open(); rows = command.ExecuteNonQuery(); }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return rows > 0;
        }

        public static bool GetAppointmentByID(int TestAppointmentID, out int LocalDrivingLicenseApplicationID, out int TestTypeID, out DateTime AppointmentDate, out decimal PaidFees)
        {
            bool isFound = false;
            LocalDrivingLicenseApplicationID = 0; TestTypeID = 0; AppointmentDate = DateTime.MinValue; PaidFees = 0;

            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID=@ID";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", TestAppointmentID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            LocalDrivingLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                            TestTypeID = Convert.ToInt32(reader["TestTypeID"]);
                            AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                        }
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return isFound;
        }

        public static DataTable GetOpenAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT TA.* FROM TestAppointments TA
LEFT JOIN Tests T ON TA.TestAppointmentID = T.TestAppointmentID
WHERE TA.LocalDrivingLicenseApplicationID=@AppID AND TA.TestTypeID=@TestTypeID AND T.TestID IS NULL";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AppID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
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

        public static int GetNextTrialNumber(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int count = 0;
            string query = @"SELECT COUNT(*) FROM TestAppointments
WHERE LocalDrivingLicenseApplicationID=@AppID AND TestTypeID=@TestTypeID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AppID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    count = result != null ? Convert.ToInt32(result) : 0;
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return count + 1;
        }

        public static int GetLastAppointmentID(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int id = -1;
            string query = @"SELECT TOP 1 TestAppointmentID FROM TestAppointments
WHERE LocalDrivingLicenseApplicationID=@AppID AND TestTypeID=@TestTypeID
ORDER BY AppointmentDate DESC";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AppID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null) id = Convert.ToInt32(result);
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return id;
        }

        public static DataTable GetAppointmentsWithResults(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();
            string query = @"
SELECT TA.TestAppointmentID,
       ROW_NUMBER() OVER (ORDER BY TA.AppointmentDate) AS TrialNumber,
       TA.AppointmentDate, TA.PaidFees,
       CASE WHEN T.TestID IS NOT NULL THEN 1 ELSE 0 END AS IsLocked
FROM TestAppointments TA
LEFT JOIN Tests T ON TA.TestAppointmentID = T.TestAppointmentID
WHERE TA.LocalDrivingLicenseApplicationID=@AppID AND TA.TestTypeID=@TestTypeID
ORDER BY TA.AppointmentDate";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AppID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
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

        public static int GetPassedTestTypesCount(int LocalDrivingLicenseApplicationID)
        {
            int count = 0;
            string query = @"SELECT COUNT(DISTINCT TA.TestTypeID)
FROM TestAppointments TA
INNER JOIN Tests T ON TA.TestAppointmentID = T.TestAppointmentID
WHERE TA.LocalDrivingLicenseApplicationID=@AppID AND T.TestResult = 1";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AppID", LocalDrivingLicenseApplicationID);
                try { connection.Open(); count = Convert.ToInt32(command.ExecuteScalar()); }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return count;
        }

        public static bool IsTestTypePassed(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool passed = false;
            string query = @"SELECT COUNT(*) FROM TestAppointments TA
INNER JOIN Tests T ON TA.TestAppointmentID = T.TestAppointmentID
WHERE TA.LocalDrivingLicenseApplicationID=@AppID AND TA.TestTypeID=@TestTypeID AND T.TestResult = 1";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AppID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                try { connection.Open(); passed = Convert.ToInt32(command.ExecuteScalar()) > 0; }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
            return passed;
        }
    }
}
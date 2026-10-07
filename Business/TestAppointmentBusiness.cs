using DataAccess;
using System;
using System.Data;

namespace Business
{
    public class TestAppointmentBusiness
    {
        public enum enTestType { Vision = 1, Written = 2, Street = 3 }

        public int TestAppointmentID { get; private set; } = -1;
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int TestTypeID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public enum enMode { AddNew, Update }
        public enMode Mode = enMode.AddNew;

        public TestAppointmentBusiness() { }

        private TestAppointmentBusiness(int id, int appId, int testTypeId, DateTime date, decimal fees)
        {
            TestAppointmentID = id;
            LocalDrivingLicenseApplicationID = appId;
            TestTypeID = testTypeId;
            AppointmentDate = date;
            PaidFees = fees;
            Mode = enMode.Update;
        }

        public bool Save(int CreatedByUserID)
        {
            if (Mode == enMode.AddNew)
            {
                TestAppointmentID = TestAppointmentData.AddNewTestAppointment(LocalDrivingLicenseApplicationID, TestTypeID, AppointmentDate, PaidFees, CreatedByUserID);
                return TestAppointmentID > 0;
            }
            return TestAppointmentData.UpdateTestAppointment(TestAppointmentID, AppointmentDate, PaidFees);
        }

        public static TestAppointmentBusiness FindOpenAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = TestAppointmentData.GetOpenAppointment(LocalDrivingLicenseApplicationID, TestTypeID);
            if (dt.Rows.Count == 0) return null;

            DataRow r = dt.Rows[0];
            return new TestAppointmentBusiness(
                Convert.ToInt32(r["TestAppointmentID"]), LocalDrivingLicenseApplicationID, TestTypeID,
                Convert.ToDateTime(r["AppointmentDate"]), Convert.ToDecimal(r["PaidFees"]));
        }

        public static TestAppointmentBusiness FindByID(int TestAppointmentID)
        {
            if (TestAppointmentData.GetAppointmentByID(TestAppointmentID, out int appId, out int testTypeId, out DateTime date, out decimal fees))
                return new TestAppointmentBusiness(TestAppointmentID, appId, testTypeId, date, fees);
            return null;
        }

        public static int GetNextTrialNumber(int LocalDrivingLicenseApplicationID, int TestTypeID)
            => TestAppointmentData.GetNextTrialNumber(LocalDrivingLicenseApplicationID, TestTypeID);

        public static int GetLastAppointmentID(int LocalDrivingLicenseApplicationID, int TestTypeID)
            => TestAppointmentData.GetLastAppointmentID(LocalDrivingLicenseApplicationID, TestTypeID);

        public static DataTable GetAppointmentsWithResults(int LocalDrivingLicenseApplicationID, int TestTypeID)
            => TestAppointmentData.GetAppointmentsWithResults(LocalDrivingLicenseApplicationID, TestTypeID);

        public static int? GetNextRequiredTestType(int LocalDrivingLicenseApplicationID)
        {
            foreach (enTestType type in Enum.GetValues(typeof(enTestType)))
                if (!TestAppointmentData.IsTestTypePassed(LocalDrivingLicenseApplicationID, (int)type))
                    return (int)type;
            return null;
        }

        public static int GetPassedTestsCount(int LocalDrivingLicenseApplicationID)
            => TestAppointmentData.GetPassedTestTypesCount(LocalDrivingLicenseApplicationID);

        public static bool HasPassedAllTests(int LocalDrivingLicenseApplicationID)
            => GetPassedTestsCount(LocalDrivingLicenseApplicationID) == 3;
    }
}
using DataAccess;
using System;
using System.Data;

namespace Business
{
    public class LocalDrivingLicenseApplicationBusiness
    {

        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int ApplicationID { get; private set; }
        public int PersonID { get; private set; }
        public string FullName { get; private set; }
        public DateTime ApplicationDate { get; private set; }
        public byte ApplicationStatus { get; private set; }
        public DateTime LastStatusDate { get; private set; }
        public decimal PaidFees { get; private set; }
        public string ApplicationTypeTitle { get; private set; }
        public string CreatedByUserName { get; private set; }
        public int LicenseClassID { get; private set; }
        public string ClassName { get; private set; }

        public static LocalDrivingLicenseApplicationBusiness FindByID(int LocalDrivingLicenseApplicationID)
        {
            if (DataAccess.LocalDrivingLicenseApplicationData.GetApplicationDetailsByID(
                LocalDrivingLicenseApplicationID,
                out int applicationId, out int personId, out string fullName,
                out DateTime appDate, out byte status, out DateTime statusDate,
                out decimal fees, out string typeTitle, out string createdBy,
                out int classId, out string className))
            {
                return new LocalDrivingLicenseApplicationBusiness
                {
                    LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID,
                    ApplicationID = applicationId,
                    PersonID = personId,
                    FullName = fullName,
                    ApplicationDate = appDate,
                    ApplicationStatus = status,
                    LastStatusDate = statusDate,
                    PaidFees = fees,
                    ApplicationTypeTitle = typeTitle,
                    CreatedByUserName = createdBy,
                    LicenseClassID = classId,
                    ClassName = className
                };
            }
            return null;
        }
        public const int NEW_LOCAL_DL_APPLICATION_TYPE_ID = 1;

        public static bool CanCreateNewApplication(int PersonID)
        {
            return !ApplicationBusiness.HasActiveApplicationOfType(PersonID, NEW_LOCAL_DL_APPLICATION_TYPE_ID);
        }

        public static int AddNewLocalDrivingLicenseApplication(int PersonID, int LicenseClassID, decimal ApplicationFees, int CreatedByUserID, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!CanCreateNewApplication(PersonID))
            {
                errorMessage = "This person already has an open application of the same type";
                return -1;
            }

            int applicationId = ApplicationBusiness.AddNewApplication(PersonID, NEW_LOCAL_DL_APPLICATION_TYPE_ID, ApplicationFees, CreatedByUserID);

            if (applicationId <= 0)
            {
                errorMessage = "An error occurred while creating the application";
                return -1;
            }

            int localAppId = DataAccess.LocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(applicationId, LicenseClassID);

            if (localAppId <= 0)
            {
                errorMessage = "The base application was created, but linking it to the driving license application failed";
                return -1;
            }

            return localAppId;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return DataAccess.LocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }
    }
}
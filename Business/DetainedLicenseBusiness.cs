using DataAccess;
using System;
using System.Data;

namespace Business
{
    public class DetainedLicenseBusiness
    {
        public const int RELEASE_DETAINED_APPLICATION_TYPE_ID = 5;

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }

        public static bool IsLicenseDetained(int LicenseID) => DetainedLicenseData.IsLicenseDetained(LicenseID);

        public static int DetainLicense(int LicenseID, decimal FineFees, int CreatedByUserID, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (IsLicenseDetained(LicenseID))
            {
                errorMessage = "This license is already detained";
                return -1;
            }

            int detainId = DetainedLicenseData.AddNewDetain(LicenseID, FineFees, CreatedByUserID);

            if (detainId <= 0)
            {
                errorMessage = "An error occurred while detaining the license";
            }

            return detainId;
        }

        public static DetainedLicenseBusiness FindActiveDetainByLicenseID(int LicenseID)
        {
            if (DetainedLicenseData.GetActiveDetainByLicenseID(LicenseID, out int detainId, out DateTime detainDate, out decimal fineFees))
            {
                return new DetainedLicenseBusiness
                {
                    DetainID = detainId,
                    LicenseID = LicenseID,
                    DetainDate = detainDate,
                    FineFees = fineFees
                };
            }
            return null;
        }

        public static bool ReleaseLicense(int DetainID, int LicenseID, int PersonID, decimal ApplicationFees, int CreatedByUserID, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!IsLicenseDetained(LicenseID))
            {
                errorMessage = "This license is not currently detained";
                return false;
            }

            int applicationId = ApplicationBusiness.AddNewApplication(PersonID, RELEASE_DETAINED_APPLICATION_TYPE_ID, ApplicationFees, CreatedByUserID);

            if (applicationId <= 0)
            {
                errorMessage = "An error occurred while creating the release application";
                return false;
            }

            bool released = DetainedLicenseData.ReleaseDetain(DetainID, CreatedByUserID, applicationId);

            if (!released)
            {
                errorMessage = "The application was created, but releasing the license failed";
                return false;
            }

            ApplicationBusiness.UpdateApplicationStatus(applicationId, ApplicationBusiness.enApplicationStatus.Completed);
            return true;
        }

        public static DataTable GetAllDetainedLicenses() => DetainedLicenseData.GetAllDetainedLicenses();
    }
}
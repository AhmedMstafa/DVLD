using DataAccess;
using System;
using System.Data;

namespace Business
{
    public class LicenseBusiness
    {
        public int LicenseID { get; private set; }
        public string ClassName { get; private set; }
        public string FullName { get; private set; }
        public string NationalNo { get; private set; }
        public int Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string Notes { get; private set; }
        public bool IsActive { get; private set; }
        public int DriverID { get; private set; }
        public string ImagePath { get; private set; }

        public int PersonID { get; private set; }
        public int ApplicationID { get; private set; }
        public const int RENEW_LOCAL_LICENSE_APPLICATION_TYPE_ID = 2;

        public const int RENEWAL_ELIGIBLE_DAYS_BEFORE_EXPIRATION = 30;

        public const int REPLACEMENT_LOST_APPLICATION_TYPE_ID = 3;
        public const int REPLACEMENT_DAMAGED_APPLICATION_TYPE_ID = 4;

        public static bool IsEligibleForReplacement(bool IsActive, int LicenseID, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!IsActive)
            {
                errorMessage = "Cannot replace an inactive license";
                return false;
            }

            if (DetainedLicenseBusiness.IsLicenseDetained(LicenseID))
            {
                errorMessage = "Cannot replace a currently detained license";
                return false;
            }

            return true;
        }

        public static int ReplaceLicense(int OldLicenseID, int DriverID, int ApplicationID, int LicenseClass, decimal LicenseFees, string Notes, int CreatedByUserID, out string errorMessage)
        {
            errorMessage = string.Empty;

            DataAccess.LicenseData.DeactivateLicense(OldLicenseID);

            LicenseClassBusiness.Find(LicenseClass, out string className, out decimal classFees, out byte validityYears);

            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = issueDate.AddYears(validityYears > 0 ? validityYears : 10);

            int newLicenseId = DataAccess.LicenseData.AddNewLicense(ApplicationID, DriverID, LicenseClass, issueDate, expirationDate, LicenseFees, Notes, CreatedByUserID);

            if (newLicenseId <= 0)
            {
                errorMessage = "An error occurred while issuing the replacement license";
                return -1;
            }

            return newLicenseId;
        }
        public static bool IsEligibleForRenewal(bool IsActive, DateTime ExpirationDate, int LicenseID, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!IsActive)
            {
                errorMessage = "Cannot renew an inactive license";
                return false;
            }

            if (DetainedLicenseBusiness.IsLicenseDetained(LicenseID))
            {
                errorMessage = "Cannot renew a currently detained license";
                return false;
            }

            DateTime eligibleFrom = ExpirationDate.AddDays(-RENEWAL_ELIGIBLE_DAYS_BEFORE_EXPIRATION);

            if (DateTime.Now < eligibleFrom)
            {
                errorMessage = $"The selected license has not expired yet. It is valid until {ExpirationDate:dd/MM/yyyy}";
                return false;
            }

            return true;
        }
        public static int RenewLicense(int OldLicenseID, int DriverID, int ApplicationID, int LicenseClass, decimal LicenseFees, string Notes, int CreatedByUserID, out string errorMessage)
        {
            errorMessage = string.Empty;

            DataAccess.LicenseData.DeactivateLicense(OldLicenseID);

            LicenseClassBusiness.Find(LicenseClass, out string className, out decimal classFees, out byte validityYears);

            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = issueDate.AddYears(validityYears > 0 ? validityYears : 10);

            int newLicenseId = DataAccess.LicenseData.AddNewLicense(ApplicationID, DriverID, LicenseClass, issueDate, expirationDate, LicenseFees, Notes, CreatedByUserID);

            if (newLicenseId <= 0)
            {
                errorMessage = "An error occurred while issuing the new license";
                return -1;
            }

            return newLicenseId;
        }

        public static LicenseBusiness FindByLicenseID(int LicenseID)
        {
            if (DataAccess.LicenseData.GetLicenseDetailsByLicenseID(LicenseID,
                out int driverId, out int personId, out int applicationId, out string className, out string fullName, out string nationalNo,
                out int gender, out DateTime dob, out DateTime issueDate, out DateTime expDate,
                out string notes, out bool isActive, out string imagePath))
            {
                return new LicenseBusiness
                {
                    DriverID = driverId,
                    PersonID = personId,
                    ApplicationID = applicationId,
                    ClassName = className,
                    FullName = fullName,
                    NationalNo = nationalNo,
                    Gender = gender,
                    DateOfBirth = dob,
                    IssueDate = issueDate,
                    ExpirationDate = expDate,
                    Notes = notes,
                    IsActive = isActive,
                    ImagePath = imagePath
                };
            }
            return null;
        }
        public static DataTable GetInternationalLicensesByDriverID(int DriverID)
    => DataAccess.LicenseData.GetInternationalLicensesByDriverID(DriverID);
        public static LicenseBusiness FindByApplicationID(int ApplicationID)
        {
            if (DataAccess.LicenseData.GetLicenseDetailsByApplicationID(ApplicationID,
                out int licenseId, out string className, out string fullName, out string nationalNo,
                out int gender, out DateTime dob, out DateTime issueDate, out DateTime expDate,
                out string notes, out bool isActive, out int driverId, out string imagePath))
            {
                return new LicenseBusiness
                {
                    LicenseID = licenseId,
                    ClassName = className,
                    FullName = fullName,
                    NationalNo = nationalNo,
                    Gender = gender,
                    DateOfBirth = dob,
                    IssueDate = issueDate,
                    ExpirationDate = expDate,
                    Notes = notes,
                    IsActive = isActive,
                    DriverID = driverId,
                    ImagePath = imagePath
                };
            }
            return null;
        }
        public static int IssueFirstTimeLicense(int PersonID, int ApplicationID, int LicenseClassID, string Notes, int CreatedByUserID, out string errorMessage)
        {
            errorMessage = string.Empty;

            int driverId = DriverBusiness.GetOrCreateDriver(PersonID, CreatedByUserID);

            LicenseClassBusiness.Find(LicenseClassID, out string className, out decimal classFees, out byte validityYears);

            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = issueDate.AddYears(validityYears > 0 ? validityYears : 10);

            int licenseId = DataAccess.LicenseData.AddNewLicense(ApplicationID, driverId, LicenseClassID, issueDate, expirationDate, classFees, Notes, CreatedByUserID);

            if (licenseId <= 0)
            {
                errorMessage = "An error occurred while issuing the license";
                return -1;
            }

            ApplicationBusiness.UpdateApplicationStatus(ApplicationID, ApplicationBusiness.enApplicationStatus.Completed);
            return licenseId;
        }
        public static DataTable GetLicenseByApplicationID(int ApplicationID) => DataAccess.LicenseData.GetLicenseByApplicationID(ApplicationID);

        public static DataTable GetLocalLicensesByDriverID(int DriverID) => DataAccess.LicenseData.GetLocalLicensesByDriverID(DriverID);
    }
}
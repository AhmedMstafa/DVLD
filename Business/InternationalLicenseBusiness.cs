using DataAccess;
using System;
using System.Data;

namespace Business
{
    public class InternationalLicenseBusiness
    {
        public const int REQUIRED_LICENSE_CLASS_ID = 3;

        public const int NEW_INTERNATIONAL_LICENSE_APPLICATION_TYPE_ID = 6;

        public int InternationalLicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LocalLicenseID { get; set; }
        public string FullName { get; set; }
        public string NationalNo { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ApplicationDate { get; set; }
        public decimal Fees { get; set; }
        public string CreatedByUserName { get; set; }

        public static bool IsEligible(int DriverID, int LocalLicenseID, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!InternationalLicenseData.HasEligibleLocalLicense(DriverID, REQUIRED_LICENSE_CLASS_ID))
            {
                errorMessage = "The person must have an active Class 3 local license first";
                return false;
            }

            if (DetainedLicenseBusiness.IsLicenseDetained(LocalLicenseID))
            {
                errorMessage = "Cannot issue an international license because the local license is currently detained";
                return false;
            }

            if (InternationalLicenseData.HasActiveInternationalLicense(DriverID))
            {
                errorMessage = "The person already has an active international license";
                return false;
            }

            return true;
        }

        public static int IssueInternationalLicense(int DriverID, int PersonID, int LocalLicenseID, decimal Fees, int CreatedByUserID, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!IsEligible(DriverID, LocalLicenseID, out errorMessage))
                return -1;

            int applicationId = ApplicationBusiness.AddNewApplication(PersonID, NEW_INTERNATIONAL_LICENSE_APPLICATION_TYPE_ID, Fees, CreatedByUserID);

            if (applicationId <= 0)
            {
                errorMessage = "An error occurred while creating the application";
                return -1;
            }

            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = issueDate.AddYears(1);

            int internationalLicenseId = InternationalLicenseData.AddNewInternationalLicense(
                applicationId, DriverID, LocalLicenseID, issueDate, expirationDate, CreatedByUserID);

            if (internationalLicenseId <= 0)
            {
                errorMessage = "The base application was created, but issuing the international license failed";
                return -1;
            }

            ApplicationBusiness.UpdateApplicationStatus(applicationId, ApplicationBusiness.enApplicationStatus.Completed);
            return internationalLicenseId;
        }

        public static DataTable GetAllInternationalLicenseApplications()
            => InternationalLicenseData.GetAllInternationalLicenseApplications();

        public static InternationalLicenseBusiness FindByID(int InternationalLicenseID)
        {
            if (InternationalLicenseData.GetInternationalLicenseDetailsByID(InternationalLicenseID,
                out int appId, out int driverId, out int localLicenseId,
                out string fullName, out string nationalNo, out int gender, out DateTime dob,
                out DateTime issueDate, out DateTime expDate, out bool isActive,
                out DateTime appDate, out decimal fees, out string createdBy))
            {
                return new InternationalLicenseBusiness
                {
                    InternationalLicenseID = InternationalLicenseID,
                    ApplicationID = appId,
                    DriverID = driverId,
                    LocalLicenseID = localLicenseId,
                    FullName = fullName,
                    NationalNo = nationalNo,
                    Gender = gender,
                    DateOfBirth = dob,
                    IssueDate = issueDate,
                    ExpirationDate = expDate,
                    IsActive = isActive,
                    ApplicationDate = appDate,
                    Fees = fees,
                    CreatedByUserName = createdBy
                };
            }
            return null;
        }
    }
}
using DataAccess;
using System;

namespace Business
{
    public class ApplicationBusiness
    {
        public enum enApplicationStatus : byte
        {
            New = 1,
            Completed = 2,
            Cancelled = 3
        }

        public static int AddNewApplication(int ApplicantPersonID, int ApplicationTypeID, decimal PaidFees, int CreatedByUserID)
        {
            DateTime now = DateTime.Now;

            return DataAccess.ApplicationData.AddNewApplication(
                ApplicantPersonID,
                now,
                ApplicationTypeID,
                (byte)enApplicationStatus.New,
                now,
                PaidFees,
                CreatedByUserID);
        }

        public static bool HasActiveApplicationOfType(int PersonID, int ApplicationTypeID)
        {
            return DataAccess.ApplicationData.HasActiveApplicationOfType(PersonID, ApplicationTypeID);
        }

        public static bool UpdateApplicationStatus(int ApplicationID, enApplicationStatus NewStatus)
        {
            return DataAccess.ApplicationData.UpdateApplicationStatus(ApplicationID, (byte)NewStatus);
        }
    }
}
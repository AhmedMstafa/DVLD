using DataAccess;
using System;
using System.Data;

namespace Business
{
    public class ApplicationTypeBusiness
    {
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }
        public enMode Mode = enMode.AddNew;

        public int ApplicationTypeID { get; private set; } = -1;
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

        public ApplicationTypeBusiness()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = string.Empty;
            this.ApplicationFees = 0;
            this.Mode = enMode.AddNew;
        }

        private ApplicationTypeBusiness(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
            this.Mode = enMode.Update;
        }

        private bool _IsValid()
        {
            if (string.IsNullOrWhiteSpace(this.ApplicationTypeTitle)) return false;
            if (this.ApplicationFees < 0) return false;
            return true;
        }

        private bool _AddNewApplicationType()
        {
            try
            {
                this.ApplicationTypeID = DataAccess.ApplicationTypeData.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationFees);
                return this.ApplicationTypeID > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool _UpdateApplicationType()
        {
            try
            {
                return DataAccess.ApplicationTypeData.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static ApplicationTypeBusiness? Find(int ApplicationTypeID)
        {
            try
            {
                if (DataAccess.ApplicationTypeData.GetApplicationTypeInfoByID(ApplicationTypeID, out string ApplicationTypeTitle, out decimal ApplicationFees))
                    return new ApplicationTypeBusiness(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Save()
        {
            if (!_IsValid())
                return false;

            if (this.Mode == enMode.AddNew)
                return _AddNewApplicationType();
            else if (this.Mode == enMode.Update)
                return _UpdateApplicationType();
            else
                return false;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return DataAccess.ApplicationTypeData.GetAllApplicationTypes();
        }

        public static bool DeleteApplicationType(int ApplicationTypeID)
        {
            return DataAccess.ApplicationTypeData.DeleteApplicationType(ApplicationTypeID);
        }

        public static bool IsApplicationTypeExist(int ApplicationTypeID)
        {
            return DataAccess.ApplicationTypeData.IsApplicationTypeExist(ApplicationTypeID);
        }
    }
}
using DataAccess;
using System;
using System.Data;

namespace Business
{
    public class TestTypeBusiness
    {
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }
        public enMode Mode = enMode.AddNew;

        public int TestTypeID { get; private set; } = -1;
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        public TestTypeBusiness()
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = string.Empty;
            this.TestTypeDescription = string.Empty;
            this.TestTypeFees = 0;
            this.Mode = enMode.AddNew;
        }

        private TestTypeBusiness(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
            this.Mode = enMode.Update;
        }

        private bool _IsValid()
        {
            if (string.IsNullOrWhiteSpace(this.TestTypeTitle)) return false;
            if (this.TestTypeFees < 0) return false;
            return true;
        }

        private bool _AddNewTestType()
        {
            try
            {
                this.TestTypeID = DataAccess.TestTypeData.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
                return this.TestTypeID > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool _UpdateTestType()
        {
            try
            {
                return DataAccess.TestTypeData.UpdateTestType(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static TestTypeBusiness? Find(int TestTypeID)
        {
            try
            {
                if (DataAccess.TestTypeData.GetTestTypeInfoByID(TestTypeID, out string TestTypeTitle, out string TestTypeDescription, out decimal TestTypeFees))
                    return new TestTypeBusiness(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
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
                return _AddNewTestType();
            else if (this.Mode == enMode.Update)
                return _UpdateTestType();
            else
                return false;
        }

        public static DataTable GetAllTestTypes()
        {
            return DataAccess.TestTypeData.GetAllTestTypes();
        }

        public static bool DeleteTestType(int TestTypeID)
        {
            return DataAccess.TestTypeData.DeleteTestType(TestTypeID);
        }

        public static bool IsTestTypeExist(int TestTypeID)
        {
            return DataAccess.TestTypeData.IsTestTypeExist(TestTypeID);
        }
    }
}
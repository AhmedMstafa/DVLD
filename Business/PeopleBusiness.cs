using DataAccess;
using System.Data;

namespace Business
{
    public class PeopleBusiness
    {
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }
        public enMode Mode = enMode.AddNew;

        public int ID { get; private set; } = -1;

        public string FirstName { get; set; }

        public string SecondName { get; set; }
        public string ThirdName { get; set; }

        public string LastName { get; set; }

        public string NationalNo { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Gender { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        public int NationalityCountryID { get; set; }

        public string ImagePath { get; set; }

        public PeopleBusiness()
        {
            this.ID = -1;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.NationalNo = string.Empty;
            this.DateOfBirth = new DateTime(1900, 1, 1);
            this.Gender = 0;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.NationalityCountryID = 0;
            this.ImagePath = string.Empty;

            this.Mode = enMode.AddNew;
        }

        private PeopleBusiness(int ID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, int Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.ID = ID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.Mode = enMode.Update;
        }

        public static PeopleBusiness? FindByNationalNo(string NationalNo)
        {
            try
            {
                if (DataAccess.PeopleData.GetPeopleInfoByNationalNo(
                    NationalNo,
                    out int ID,
                    out string FirstName,
                    out string SecondName,
                    out string ThirdName,
                    out string LastName,
                    out DateTime DateOfBirth,
                    out int Gender,
                    out string Address,
                    out string Phone,
                    out string Email,
                    out int NationalityCountryID,
                    out string ImagePath))
                {
                    return Find(ID);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private bool _IsValid()
        {
            if (string.IsNullOrWhiteSpace(this.FirstName)) return false;
            if (string.IsNullOrWhiteSpace(this.LastName)) return false;
            if (string.IsNullOrWhiteSpace(this.NationalNo)) return false;
            return true;
        }

        private bool _AddNewPeople()
        {
            try
            {
                this.ID = DataAccess.PeopleData.AddNewPeople(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
                return (this.ID > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool _UpdatePeople()
        {
            try
            {
                return DataAccess.PeopleData.UpdatePeople(this.ID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static PeopleBusiness? Find(int ID)
        {
            try
            {
                if(DataAccess.PeopleData.GetPeopleInfoByID(
                    ID,
                    out string NationalNo,
                    out string FirstName,
                    out string SecondName,
                    out string ThirdName,
                    out string LastName,
                    out DateTime DateOfBirth,
                    out int Gender,
                    out string Address,
                    out string Phone,
                    out string Email,
                    out int NationalityCountryID,
                    out string ImagePath))
                    return new PeopleBusiness(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
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
                return _AddNewPeople();
            else if (this.Mode == enMode.Update)
                return _UpdatePeople();
            else
                return false;
        }

        public static DataTable GetAllPeople()
        {
            return DataAccess.PeopleData.GetAllPeople();
        }

        public static bool DeletePeople(int ID)
        {
            return DataAccess.PeopleData.DeletePeople(ID);
        }

        public static bool IsPeopleExist(int ID)
        {
            return DataAccess.PeopleData.IsPeopleExist(ID);
        }
    }
}
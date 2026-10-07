using DataAccess;
using Common;
using System;
using System.Data;

namespace Business
{
    public class UserBusiness
    {
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }
        public enMode Mode = enMode.AddNew;

        public int UserID { get; private set; } = -1;
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public UserBusiness()
        {
            this.UserID = -1;
            this.PersonID = 0;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsActive = true;
            this.Mode = enMode.AddNew;
        }

        private UserBusiness(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.Mode = enMode.Update;
        }

        private bool _IsValid()
        {
            if (string.IsNullOrWhiteSpace(this.UserName)) return false;
            if (string.IsNullOrWhiteSpace(this.Password)) return false;
            if (this.PersonID <= 0) return false;
            return true;
        }

        private bool _AddNewUser()
        {
            try
            {
                this.UserID = DataAccess.UserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
                return this.UserID > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool _UpdateUser()
        {
            try
            {
                return DataAccess.UserData.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static UserBusiness? Find(int UserID)
        {
            try
            {
                if (DataAccess.UserData.GetUserInfoByID(UserID, out int PersonID, out string UserName, out string Password, out bool IsActive))
                    return new UserBusiness(UserID, PersonID, UserName, Password, IsActive);
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
                return _AddNewUser();
            else if (this.Mode == enMode.Update)
                return _UpdateUser();
            else
                return false;
        }

        public static DataTable GetAllUsers()
        {
            return DataAccess.UserData.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return DataAccess.UserData.DeleteUser(UserID);
        }

        public static bool IsUserExist(int UserID)
        {
            return DataAccess.UserData.IsUserExist(UserID);
        }

        public static bool IsUserNameExist(string UserName)
        {
            return DataAccess.UserData.IsUserNameExist(UserName);
        }

        public static bool Login(string username, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Please enter username and password";
                return false;
            }

            bool success = UserData.Login(username, password, out int userId, out int personId, out bool isActive);

            if (!success)
            {
                errorMessage = "Invalid username or password";
                return false;
            }

            UserSession.SetSession(userId, personId, username, isActive);
            return true;
        }

        public static bool ChangePassword(string oldPassword, string newPassword, out string errorMessage)
        {
            errorMessage = string.Empty;

            bool success = UserData.ChangePassword(UserSession.Username, oldPassword, newPassword);

            if (!success)
            {
                errorMessage = "Current password is incorrect";
            }

            return success;
        }
    }
}
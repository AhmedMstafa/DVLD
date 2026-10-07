using DataAccess;
using System.Data;

namespace Business
{
    public class LicenseClassBusiness
    {
        public static DataTable GetAllLicenseClasses() => DataAccess.LicenseClassData.GetAllLicenseClasses();

        public static bool Find(int LicenseClassID, out string ClassName, out decimal ClassFees, out byte DefaultValidityLength)
            => DataAccess.LicenseClassData.GetLicenseClassInfoByID(LicenseClassID, out ClassName, out ClassFees, out DefaultValidityLength);
    }
}
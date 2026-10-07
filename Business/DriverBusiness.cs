using DataAccess;
using System.Data;

namespace Business
{
    public class DriverBusiness
    {
        public static int GetPersonIdByDriverId(int DriverID) => DataAccess.DriverData.GetPersonIdByDriverId(DriverID);
        public static DataTable GetAllDrivers() => DataAccess.DriverData.GetAllDrivers();
        public static int GetOrCreateDriver(int PersonID, int CreatedByUserID)
        {
            if (DriverData.GetDriverByPersonID(PersonID, out int driverId))
                return driverId;
            return DriverData.AddNewDriver(PersonID, CreatedByUserID);
        }
    }
}
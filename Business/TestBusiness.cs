using DataAccess;

namespace Business
{
    public class TestBusiness
    {
        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            return TestData.AddNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);
        }
    }
}
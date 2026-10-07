using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class PeopleData
    {

        public static bool GetPeopleInfoByNationalNo(string NationalNo, out int ID, out string FirstName, out string SecondName, out string ThirdName, out string LastName, out DateTime DateOfBirth, out int Gender, out string Address, out string Phone, out string Email, out int NationalityCountryID, out string ImagePath)
        {
            bool isFound = false;

            ID = -1;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = 0;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityCountryID = 0;
            ImagePath = string.Empty;

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NationalNo", NationalNo);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            ID = reader["PersonID"] != DBNull.Value ? Convert.ToInt32(reader["PersonID"]) : -1;
                            FirstName = reader["FirstName"] != DBNull.Value ? (string)reader["FirstName"] : "";
                            SecondName = reader["SecondName"] != DBNull.Value ? (string)reader["SecondName"] : "";
                            ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : "";
                            LastName = reader["LastName"] != DBNull.Value ? (string)reader["LastName"] : "";
                            DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? (DateTime)reader["DateOfBirth"] : DateTime.MinValue;
                            Gender = reader["Gendor"] != DBNull.Value ? (int)reader["Gendor"] : 0;
                            Phone = reader["Phone"] != DBNull.Value ? (string)reader["Phone"] : "";
                            Address = reader["Address"] != DBNull.Value ? (string)reader["Address"] : "";
                            Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : "";
                            NationalityCountryID = reader["NationalityCountryID"] != DBNull.Value ? (int)reader["NationalityCountryID"] : 0;
                            ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return isFound;
        }
        public static bool GetPeopleInfoByID(int ID, out string NationalNo, out string FirstName, out string SecondName, out string ThirdName, out string LastName, out DateTime DateOfBirth, out int Gender, out string Address, out string Phone, out string Email, out int NationalityCountryID, out string ImagePath)
        {
            bool isFound = false;

            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = 0;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityCountryID = 0;
            ImagePath = string.Empty;

            string query = @"SELECT * FROM People WHERE PersonID = @ID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            NationalNo = reader["NationalNo"] != DBNull.Value ? (string)reader["NationalNo"] : "";
                            FirstName = reader["FirstName"] != DBNull.Value ? (string)reader["FirstName"] : "";
                            SecondName = reader["SecondName"] != DBNull.Value ? (string)reader["SecondName"] : "";
                            ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : "";
                            LastName = reader["LastName"] != DBNull.Value ? (string)reader["LastName"] : "";
                            DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? (DateTime)reader["DateOfBirth"] : DateTime.MinValue;
                            Gender = reader["Gendor"] != DBNull.Value ? (int)reader["Gendor"] : 0;
                            Phone = reader["Phone"] != DBNull.Value ? (string)reader["Phone"] : "";
                            Address = reader["Address"] != DBNull.Value ? (string)reader["Address"] : "";
                            Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : "";
                            NationalityCountryID = reader["NationalityCountryID"] != DBNull.Value ? (int)reader["NationalityCountryID"] : 0;

                            ImagePath = reader["ImagePath"] != DBNull.Value
                                ? (string)reader["ImagePath"]
                                : "";
                        }

                      
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                }
                connection.Close();
            }

            return isFound;
        }
        public static int AddNewPeople(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, int Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int ID = -1;

            string query = @"INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath); SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NationalNo", NationalNo);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@SecondName", SecondName);
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                command.Parameters.AddWithValue("@Gendor", Gender);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int value))
                        ID = value;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return ID;
        }

        public static bool UpdatePeople(int ID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int rowsAffected = 0;

            string query = @"UPDATE People SET NationalNo=@NationalNo, FirstName=@FirstName, SecondName=@SecondName, ThirdName=@ThirdName, LastName=@LastName, DateOfBirth=@DateOfBirth, Gendor=@Gendor, Address=@Address, Phone=@Phone, Email=@Email, NationalityCountryID=@NationalityCountryID, ImagePath=@ImagePath WHERE PersonID=@ID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@NationalNo", NationalNo);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@SecondName", SecondName);
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                command.Parameters.AddWithValue("@Gendor", Gendor);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return rowsAffected > 0;
        }

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM People";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return dt;
        }

        public static bool DeletePeople(int PersonID)
        {
            int rowsAffected = 0;
            string query = @"DELETE FROM People WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return rowsAffected > 0;
        }

        public static bool IsPeopleExist(int ID)
        {
            bool isFound = false;
            string query = "SELECT COUNT(*) FROM People WHERE PersonID=@ID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    int count = result != null ? Convert.ToInt32(result) : 0;
                    isFound = count > 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return isFound;
        }
    }
}
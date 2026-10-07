namespace Common
{
    public static class UserSession
    {
        public static int UserId { get; private set; }
        public static int PersonId { get; private set; }
        public static string Username { get; private set; }
        public static bool IsLoggedIn { get; private set; }

        public static bool IsActive { get; set; } 

        public static void SetSession(int userId, int personId, string username, bool isActive)
        {
            UserId = userId;
            PersonId = personId;
            Username = username;
            IsLoggedIn = true;
            IsActive = isActive;
        }

        public static void ClearSession()
        {
            UserId = 0;
            PersonId = 0;
            Username = null;
            IsLoggedIn = false;
            IsActive = false;
        }
    }
}
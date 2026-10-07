using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public static class RememberMeHelper
    {
        private static readonly string FilePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyApp", "credentials.dat");

        public static void Save(string username, string password)
        {
            string raw = $"{username}|{password}";
            byte[] encrypted = ProtectedData.Protect(Encoding.UTF8.GetBytes(raw), null, DataProtectionScope.CurrentUser);

            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            File.WriteAllBytes(FilePath, encrypted);
        }

        public static (string username, string password)? Load()
        {
            if (!File.Exists(FilePath)) return null;

            try
            {
                byte[] encrypted = File.ReadAllBytes(FilePath);
                byte[] decrypted = ProtectedData.Unprotect(encrypted, null, DataProtectionScope.CurrentUser);
                string raw = Encoding.UTF8.GetString(decrypted);
                var parts = raw.Split('|');
                return (parts[0], parts[1]);
            }
            catch
            {
                return null;
            }
        }

        public static void Clear()
        {
            if (File.Exists(FilePath)) File.Delete(FilePath);
        }
    }
}
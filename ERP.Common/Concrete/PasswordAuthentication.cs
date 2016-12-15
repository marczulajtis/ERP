using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ERP.Common.Concrete
{
    public static class PasswordAuthentication
    {
        private const int DerivedKeyLength = 24;

        public static string GenerateSalt()
        {
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                byte[] tokenData = new byte[32];
                rng.GetBytes(tokenData);

                return Convert.ToBase64String(tokenData);
            }
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] hashValue;

            var valueToHash = string.IsNullOrEmpty(password) ? string.Empty : password;

            var saltInBytes = Encoding.ASCII.GetBytes(salt);

            using (var pbkdf2 = new Rfc2898DeriveBytes(valueToHash, saltInBytes))
            {
                hashValue = pbkdf2.GetBytes(DerivedKeyLength);
            }

            return Convert.ToBase64String(hashValue);
        }

        public static bool CompareHashes(string originalHash, string newHash)
        {
            if (string.Equals(originalHash, newHash))
            {
                return true;
            }

            return false;
        }
    }
}

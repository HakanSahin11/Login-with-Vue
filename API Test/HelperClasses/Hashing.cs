using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace API_Test.HelperClasses
{
    public class Hashing
    {
        public static bool HashSalt(string input, string savedPasswordHash)
        {

            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(input, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            var test = Convert.ToBase64String(hash);

            hash = Convert.FromBase64String(test);

            int ok = 1;
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    ok = 0;
            }
            if (ok == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

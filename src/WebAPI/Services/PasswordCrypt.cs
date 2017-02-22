using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace WebAPI.Services
{
    public static class PasswordCrypt
    {
        private const string saltStr = "U2FsdCBzdHJpbmcgZm9yIGNyeXB0IHBhc3N3b3JkITIzJCMyMjM=";
        //private int saltLength = 128;
        public static string CreateDbPassword(string unsaltedPassword)
        {
            byte[] salt = new byte[128 / 8];
            
            //using(var rng = RandomNumberGenerator.Create())
            //{
            //    rng.GetBytes(salt);
            //}
            
            Array.Copy(Convert.FromBase64String(saltStr), salt, 128 / 8);
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: unsaltedPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}

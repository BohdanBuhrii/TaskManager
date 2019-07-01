using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class HashHelper
    {
        public static string GetHashStringSHA256(string str)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hashPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
            string result = "";
            foreach (byte b in hashPassword)
            {
                result += b.ToString();
            }
            return result;
        }
    }
}

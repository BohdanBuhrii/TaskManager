using System.Security.Cryptography;
using System.Text;

namespace Helper
{
    public class HashHelper
    {
        public static string GetHashStringSHA256(string str)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hashPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
            string result = string.Empty;
            foreach (byte b in hashPassword)
            {
                result += b.ToString();
            }

            return result;
        }
    }
}

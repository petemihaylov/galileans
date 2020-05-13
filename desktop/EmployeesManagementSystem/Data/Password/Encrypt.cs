using System.Security.Cryptography;
using System.Text;

namespace EmployeesManagementSystem
{
    class Encrypt
    {
        public static string GetMD5Hash(string input)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] b = Encoding.UTF8.GetBytes(input);
                b = md5.ComputeHash(b);

                StringBuilder sb = new StringBuilder();
                foreach (byte x in b)
                {
                    sb.Append(x.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}

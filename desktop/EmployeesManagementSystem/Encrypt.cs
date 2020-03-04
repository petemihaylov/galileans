using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem
{
    class Encrypt
    {
        public static string GetMD5Hash(string input)
        {
            // Encryption

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                // Reading byte per byte the input
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

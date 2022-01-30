using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Security.Services
{
    public class MD5Service
    {
        public static string Encrypt(string valor)
        {
            var hash = new MD5CryptoServiceProvider()
                .ComputeHash(Encoding.UTF8.GetBytes(valor));

            var result = string.Empty;
            foreach (var item in hash)
                result += item.ToString("X2"); //X2 -> hexadecimal

            return result;
        }
    }
}




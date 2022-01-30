using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Security.Settings
{
    public class TokenSettings
    {
        /// <summary>
        /// Chave anti-falsificação para geração dos tokens
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Tempo de expiração dos tokens
        /// </summary>
        public int ExpirationInHours { get; set; }
    }
}




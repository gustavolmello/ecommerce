using Microsoft.IdentityModel.Tokens;
using ProjetoECommerce.Security.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Security.Services
{
    public class TokenService
    {
        private readonly TokenSettings _tokenSettings;

        public TokenService(TokenSettings tokenSettings)
        {
            _tokenSettings = tokenSettings;
        }

        /// <summary>
        /// Método para gerar os tokens do sistema
        /// </summary>
        /// <param name="userName">Nome do usuário para o qual o token será gerado</param>
        /// <returns>Token JWT</returns>
        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenSettings.SecretKey);

            //conteudo do token (PAYLOAD)
            var tokenDescription = new SecurityTokenDescriptor
            {
                //criando a identificação do usuario para o AspNet
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username) //nome do usuario
                }),

                //definindo a data de expiração do Token
                Expires = DateTime.Now.AddHours(_tokenSettings.ExpirationInHours),

                //criptografia do Token a chave secreta (evitar falsificação)
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}




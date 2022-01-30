using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjetoECommerce.Security.Services;
using ProjetoECommerce.Security.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Presentation.Configurations
{
    public class JwtConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var settingsSection = configuration.GetSection("AccessTokenSettings");
            services.Configure<TokenSettings>(settingsSection);

            var appSettings = settingsSection.Get<TokenSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    bearer =>
                    {
                        bearer.RequireHttpsMetadata = false;
                        bearer.SaveToken = true;
                        bearer.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                );

            services.AddTransient(map => new TokenService(appSettings));
        }
    }
}




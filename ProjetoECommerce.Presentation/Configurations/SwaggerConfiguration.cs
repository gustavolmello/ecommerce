﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoECommerce.Presentation.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                swagger =>
                {
                    swagger.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "ECommerce - Treinamento em C# WebDeveloper.",
                        Description = "Projeto desenvolvido em AspNet 5 API com SqlServer e EntityFramework.",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "COTI Informática - Escola de NERDS",
                            Url = new Uri("http://www.cotiinformatica.com.br"),
                            Email = "contato@cotiinformatica.com.br"
                        }
                    });
                }
                );
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "COTI API"); });
        }
    }
}




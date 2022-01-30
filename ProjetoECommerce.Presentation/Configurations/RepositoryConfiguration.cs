using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoECommerce.Data.Contexts;
using ProjetoECommerce.Data.Interfaces;
using ProjetoECommerce.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoECommerce.Presentation.Configurations
{
    public class RepositoryConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer
                (configuration.GetConnectionString("ProjetoECommerce")));

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
        }
    }
}




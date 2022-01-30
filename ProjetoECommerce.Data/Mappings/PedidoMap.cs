using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoECommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Data.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            //Relacionamento com Cliente (Foreign Key)
            builder.HasOne(p => p.Cliente) //Pedido TEM 1 Cliente
                .WithMany(c => c.Pedidos) //Cliente TEM Muitos Pedidos
                .HasForeignKey(p => p.ClienteId); //Chave estrangeira

            
        }
    }
}

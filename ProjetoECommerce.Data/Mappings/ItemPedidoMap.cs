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
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(i => i.Id);

            //Relacionamento com Pedido (1pN)
            builder.HasOne(i => i.Pedido)
                .WithMany(p => p.ItensPedido)
                .HasForeignKey(i => i.PedidoId);

            //Relacionamento com Produto (1pN)
            builder.HasOne(i => i.Produto)
                .WithMany(p => p.ItensPedido)
                .HasForeignKey(i => i.ProdutoId);
        }
    }
}




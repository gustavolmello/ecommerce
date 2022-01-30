using ProjetoECommerce.Data.Contexts;
using ProjetoECommerce.Data.Entities;
using ProjetoECommerce.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Data.Repositories
{
    public class ItemPedidoRepository
        : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        private readonly SqlServerContext _context;

        public ItemPedidoRepository(SqlServerContext context)
            : base(context)
        {
            _context = context;
        }

        public List<ItemPedido> GetByPedido(Guid idPedido)
        {
            return _context.ItemPedido
                    .Where(i => i.PedidoId.Equals(idPedido))
                    .ToList();
        }
    }
}


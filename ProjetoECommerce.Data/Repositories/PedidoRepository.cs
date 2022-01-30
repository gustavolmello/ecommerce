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
    public class PedidoRepository
        : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly SqlServerContext _context;

        public PedidoRepository(SqlServerContext context)
            : base(context)
        {
            _context = context;
        }

        public List<Pedido> GetByCliente(Guid idCliente)
        {
            return _context.Pedido
                    .Where(p => p.ClienteId.Equals(idCliente))
                    .OrderByDescending(p => p.Data)
                    .ToList();
        }
    }
}




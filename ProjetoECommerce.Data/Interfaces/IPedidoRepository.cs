using ProjetoECommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Data.Interfaces
{
    public interface IPedidoRepository
        : IBaseRepository<Pedido>
    {
        List<Pedido> GetByCliente(Guid idCliente);
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Data.Entities
{
    public class ItemPedido
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid PedidoId { get; set; }

        #region Associações

        public Produto Produto { get; set; }
        public Pedido Pedido { get; set; }

        #endregion
    }
}




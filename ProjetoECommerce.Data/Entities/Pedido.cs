using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Data.Entities
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public Guid ClienteId { get; set; }
        

        #region Associações

        public Cliente Cliente { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }

        #endregion
    }
}

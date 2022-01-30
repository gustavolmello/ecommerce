using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoECommerce.Presentation.Models
{
    public class PedidoConsultaModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public ClienteConsultaModel Cliente { get; set; }
        public List<ItemPedidoConsultaModel> ItensPedido { get; set; }
    }
}

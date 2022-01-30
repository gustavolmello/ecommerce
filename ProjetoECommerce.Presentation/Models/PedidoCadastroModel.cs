using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoECommerce.Presentation.Models
{
    public class PedidoCadastroModel
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public List<ItemPedidoCadastroModel> Itens { get; set; }
    }
}

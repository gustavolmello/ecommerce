using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoECommerce.Presentation.Models
{
    public class ItemPedidoCadastroModel
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}

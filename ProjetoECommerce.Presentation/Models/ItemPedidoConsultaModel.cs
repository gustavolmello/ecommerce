using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoECommerce.Presentation.Models
{
    public class ItemPedidoConsultaModel
    {
        public int Quantidade { get; set; }
        public ProdutoConsultaModel Produto { get; set; }
    }
}


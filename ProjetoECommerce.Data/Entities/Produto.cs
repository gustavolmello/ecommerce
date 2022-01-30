using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Data.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Foto { get; set; }

        #region Associações

        public ICollection<ItemPedido> ItensPedido { get; set; }

        #endregion
    }
}

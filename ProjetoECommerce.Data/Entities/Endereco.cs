using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Data.Entities
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public Guid ClienteId { get; set; }

        #region Associações

        public Cliente Cliente { get; set; }
        

        #endregion
    }
}

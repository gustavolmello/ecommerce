using ProjetoECommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Data.Interfaces
{
    public interface IEnderecoRepository : IBaseRepository<Endereco>
    {
        Endereco GetByCliente(Guid idCliente);
    }
}





using ProjetoECommerce.Data.Contexts;
using ProjetoECommerce.Data.Entities;
using ProjetoECommerce.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Data.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        private readonly SqlServerContext _context;

        public EnderecoRepository(SqlServerContext context)
            : base(context)
        {
            _context = context;
        }

        public Endereco GetByCliente(Guid idCliente)
        {
            return _context.Endereco
                .FirstOrDefault(e => e.ClienteId.Equals(idCliente));
        }
    }
}





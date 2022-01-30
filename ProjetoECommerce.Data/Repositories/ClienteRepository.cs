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
    public class ClienteRepository
        : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly SqlServerContext _context;

        public ClienteRepository(SqlServerContext context)
            : base(context)
        {
            _context = context;
        }

        public Cliente Get(string email)
        {
            return _context.Cliente
                .FirstOrDefault(c => c.Email.Equals(email));
        }

        public Cliente Get(string email, string senha)
        {
            return _context.Cliente
                .FirstOrDefault(c => c.Email.Equals(email)
                                  && c.Senha.Equals(senha));
        }
    }
}






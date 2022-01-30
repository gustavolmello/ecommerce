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
    public class ProdutoRepository
        : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly SqlServerContext _context;

        public ProdutoRepository(SqlServerContext context)
            : base(context)
        {
            _context = context;
        }
    }
}




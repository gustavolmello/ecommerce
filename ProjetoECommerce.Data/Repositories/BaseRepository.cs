using Microsoft.EntityFrameworkCore;
using ProjetoECommerce.Data.Contexts;
using ProjetoECommerce.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly SqlServerContext _context;

        protected BaseRepository(SqlServerContext context)
        {
            _context = context;
        }

        public virtual void Create(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Added;
            _context.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }
    }
}




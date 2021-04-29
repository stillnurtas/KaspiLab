using AdventureWorks.Repository.Interfaces;
using AdventureWorks.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Repositories
{
    public class Repository<E> : IRepository<E> where E : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Create(E item)
        {
            _context.Set<E>().Add(item);
        }

        public void Delete(E item)
        {
            _context.Set<E>().Remove(item);
        }

        public E Get(int id)
        {
            return _context.Set<E>().Find(id);
        }

        public IEnumerable<E> GetAll()
        {
            return _context.Set<E>().ToList();
        }

        public IEnumerable<E> GetList(Expression<Func<E, bool>> predicate)
        {
            return _context.Set<E>().Where(predicate).ToList();
        }

        public void Update(E item)
        {
            _context.Set<E>().Add(item);
        }
    }
}

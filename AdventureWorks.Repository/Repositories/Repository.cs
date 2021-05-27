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

        public void CreateRange(IEnumerable<E> items)
        {
            _context.Set<E>().AddRange(items);
        }

        public void Update(E item)
        {
            _context.Entry(_context.Set<E>()).State = EntityState.Modified;
        }

        public void Delete(E item)
        {
            _context.Set<E>().Remove(item);
        }

        public void DeleteRange(IEnumerable<E> item)
        {
            _context.Set<E>().RemoveRange(item);
        }

        public async Task<E> Get(int id)
        {
            return await _context.Set<E>().FindAsync(id);
        }

        public async Task<IEnumerable<E>> GetAll()
        {
            return await _context.Set<E>().ToListAsync();
        }

        public async Task<IEnumerable<E>> GetList(Expression<Func<E, bool>> predicate)
        {
            return await _context.Set<E>().Where(predicate).ToListAsync();
        }
    }
}

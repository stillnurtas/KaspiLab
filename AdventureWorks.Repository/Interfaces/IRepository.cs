using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Interfaces
{
    public interface IRepository<E> where E : class
    {
        Task<E> Get(int id);
        Task<E> Get(Expression<Func<E, bool>> predicate);
        Task<IEnumerable<E>> GetAll();
        Task<IEnumerable<E>> GetList(Expression<Func<E, bool>> predicate);
        void Update(E item);
        void Create(E item);
        void CreateRange(IEnumerable<E> items);
        void Delete(E item);
        void DeleteRange(IEnumerable<E> items);
    }
}

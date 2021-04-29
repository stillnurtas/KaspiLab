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
        E Get(int id);
        IEnumerable<E> GetAll();
        IEnumerable<E> GetList(Expression<Func<E, bool>> predicate);
        void Update(E item);
        void Create(E item);
        void Delete(E item);
    }
}

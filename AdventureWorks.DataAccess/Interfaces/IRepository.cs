using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureWorks.DataAccess.Interfaces
{
    interface IRepository<T> : IDisposable where T : class
    {
        T Get(int id);
        IEnumerable GetList();
        void Update(T item);
        void Create(T item);
        void Save();
    }
}

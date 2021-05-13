using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Interfaces
{
    public interface ICacheManager
    {
        string GenKey(object obj, string keyField);
        object Get(string key);
        object Get(Type type, string id);
        void Set(object obj, string keyField);
        void Set(string key, object obj);
        void Set(string key, object obj, TimeSpan expiration);
        void Remove(string key);
        void Clear();
    }
}

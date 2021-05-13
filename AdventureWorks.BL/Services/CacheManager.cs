using AdventureWorks.BL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Services
{
    public class CacheManager : ICacheManager
    {
        private readonly IMemoryCache _cache;

        public CacheManager(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Clear()
        {
            _cache.Dispose();
        }

        public string GenKey(object obj, string keyField)
        {
            if (obj == null)
            {
                throw new ArgumentException($"Object is null!!!");
            }

            var type = obj.GetType();
            var field = type.GetProperty(keyField);

            if (field == null)
            {
                throw new ArgumentException($"Object doesn't contain {keyField} field!!!");
            }

            var id = field.GetValue(obj);
            return (type.Name + id);
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public object Get(Type type, string id)
        {
            return _cache.Get(type.Name + id);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Set(object obj, string keyField)
        {
            var key = GenKey(obj, keyField);
            _cache.Set(key, obj, DateTimeOffset.UtcNow.AddDays(1));
        }

        public void Set(string key, object obj)
        {
            TimeSpan timeSpan = new TimeSpan(1, 0, 0);
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(timeSpan);
            _cache.Set(key, obj, cacheEntryOptions);
        }

        public void Set(string key, object obj, TimeSpan expiration)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(expiration);
            _cache.Set(key, obj, cacheEntryOptions);
        }
    }
}

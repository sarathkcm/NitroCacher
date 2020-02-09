using NitroCacher.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroCacher.Plugins
{
    class MemoryCache : ICache
    {
        private static Lazy<ConcurrentDictionary<string, dynamic>> _cache = 
            new Lazy<ConcurrentDictionary<string, dynamic>>(() => new ConcurrentDictionary<string, dynamic>());

        private ConcurrentDictionary<string, dynamic> Cache => _cache.Value;

        public void Clear()
        {
            Cache.Clear();
        }

        public void Delete(string key)
        {
            Cache.TryRemove(key, out var ignoredValue);
        }

        public T Get<T>(string key)
        {
            Cache.TryGetValue(key, out var result);
            return result;
        }

        public bool Has(string key)
        {
           return Cache.ContainsKey(key);
        }

        public void Set<T>(string key, T value)
        {
            Cache.AddOrUpdate(key, (k) => value, (k,v) => value);
        }
    }
}

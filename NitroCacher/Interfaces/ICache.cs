using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroCacher.Interfaces
{
    public interface ICache
    {
        void Set<T>(string key, T value);
        T Get<T>(string key);
        bool Has(string key);
        void Delete(string key);
        void Clear();
    }
}

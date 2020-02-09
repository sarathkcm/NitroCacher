using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroCacher.Interfaces
{
    public interface IConfigManager
    {
        T GetConfig<T>() where T : class;
        void SaveConfig<T>(T config) where T : class;
    }
}

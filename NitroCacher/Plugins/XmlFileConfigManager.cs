using NitroCacher.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroCacher.Plugins
{
    public class XmlFileConfigManager : IConfigManager
    {
        string _configPath;
        public XmlFileConfigManager()
        {
            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _configPath = Path.Combine(appDataFolder, "NitroCacher", "Settings.config");
        }

        public T GetConfig<T>() where T : class
        {
            try
            {
                return Utils.XmlDeSerialize<T>(File.ReadAllText(_configPath));
            }
            catch
            {
                return null;
            }
        }

        public void SaveConfig<T>(T config) where T : class
        {
            File.WriteAllText(_configPath, Utils.XmlSerialize(config));
        }
    }
}

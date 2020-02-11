using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroCacher.Models
{
    [Serializable]
    public struct Header
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public Header(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}

using NitroCacher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroCacher.Models
{
    public class CachingRule
    {
        public string ProfileId { get; set; }
        public FilterRule FilterRule { get; set; }
        public ICache Cache { get; set; }
    }
}

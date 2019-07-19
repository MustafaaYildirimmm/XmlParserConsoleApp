using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser
{
    public class LoadProfile
    {
        public string EtsoCode { get; set; }
        public string Name { get; set; }
        public Dictionary<DateTime,decimal> Values { get; set; }
    }
}

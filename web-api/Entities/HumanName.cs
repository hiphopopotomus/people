using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Entities
{
    public class HumanName
    {
        public string text { get; set; }
        public string family { get; set; }
        public List<string> given { get; set; }
        public List<string> prefix { get; set; }
        public List<string> suffix { get; set; }
    }
}

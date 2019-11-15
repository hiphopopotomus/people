using System.Collections.Generic;

namespace webapi.Entities
{
    public class HumanName
    {
        public NameUse use { get; set; }
        public string text { get; set; }
        public string family { get; set; }
        public List<string> given { get; set; }
        public List<string> prefix { get; set; }
        public List<string> suffix { get; set; }
    }
}

using System.Collections.Generic;

namespace webapi.Entities
{
    public class CouchDbSearchResponse
    {
        public IList<object> docs { get; set; }
    }
}

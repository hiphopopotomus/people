using System;
using System.Text.Json.Serialization;
using webapi.Json;

namespace webapi.Entities
{
    public class CouchDbDocument
    {
        [JsonPropertyName("_id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid documentId { get; set; }

        [JsonPropertyName("_rev")]
        public string documentVersion { get; set; }
    }
}

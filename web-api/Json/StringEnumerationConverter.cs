using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using webapi.Entities;

namespace webapi.Json
{
    public class StringEnumerationConverter<T> : JsonConverter<T> where T : TypedEnumeration<string>
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return ITypedEnumeration.GetValue<T>(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer?.WriteStringValue(value?.Id);
        }
    }
}

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using webapi.Entities;

namespace webapi.Json
{
    public class IntEnumerationConverter<T> : JsonConverter<T> where T : TypedEnumeration<int>
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return ITypedEnumeration.GetValue<T>(reader.GetInt32());
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer?.WriteStringValue(value?.Id.ToString(System.Globalization.CultureInfo.InvariantCulture));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace web_api.Entities
{
    [JsonConverter(typeof(AdministrativeGenderConverter))]
    public sealed class AdministrativeGender: TypeSafeEnum<string, AdministrativeGender>
    {
        public static AdministrativeGender Male { get; } = new AdministrativeGender("male", "Male", "Male.");
        public static AdministrativeGender Female { get; } = new AdministrativeGender("female", "Female", "Female.");
        public static AdministrativeGender Other { get; } = new AdministrativeGender("other", "Other", "Other.");
        public static AdministrativeGender Unknown { get; } = new AdministrativeGender("unknown", "Unknown", "Unknown.");

        private AdministrativeGender(string id, string name, string description) : base(id, name, description)
        {
        }

        public static explicit operator string(AdministrativeGender gender) => gender?.ToString();
        public static explicit operator AdministrativeGender(string name) => Male.GetValue(name);
    }

    public abstract class TypeSafeEnum<TId, TEnum> where TEnum : TypeSafeEnum<TId, TEnum>
    {
        public TypeSafeEnum(TId id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public TId Id { get; }
        public string Name { get; }
        public string Description { get; }

        public override string ToString() => Id.ToString();
        public IEnumerable<string> GetNames() => GetValues().Select(value => value.Name);
        public TEnum GetValue(string name) => GetValues().First(value => value.ToString().Equals(name, StringComparison.OrdinalIgnoreCase));

        public IReadOnlyList<TEnum> GetValues()
        {
            return typeof(TEnum).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(property => (TEnum)property.GetValue(null))
                .ToList();
        }
    }

    internal class AdministrativeGenderConverter : JsonConverter<AdministrativeGender>
    {
        public override AdministrativeGender Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return AdministrativeGender.Male.GetValue(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, AdministrativeGender value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Id);
        }
    }
}

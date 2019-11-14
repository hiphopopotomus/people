using System.Text.Json.Serialization;
using webapi.Json;

namespace webapi.Entities
{
    [JsonConverter(typeof(StringEnumerationConverter<AdministrativeGender>))]
    public sealed class AdministrativeGender: TypedEnumeration<string>
    {
        public static AdministrativeGender Male { get; } = new AdministrativeGender("male", "Male", "Male.");
        public static AdministrativeGender Female { get; } = new AdministrativeGender("female", "Female", "Female.");
        public static AdministrativeGender Other { get; } = new AdministrativeGender("other", "Other", "Other.");
        public static AdministrativeGender Unknown { get; } = new AdministrativeGender("unknown", "Unknown", "Unknown.");

        private AdministrativeGender(string id, string name, string description) : base(id, name, description)
        {
        }
    }
}

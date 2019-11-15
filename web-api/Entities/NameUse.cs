using System.Text.Json.Serialization;
using webapi.Json;

namespace webapi.Entities
{
    [JsonConverter(typeof(StringEnumerationConverter<NameUse>))]
    public sealed class NameUse : TypedEnumeration<string>
    {
        public static NameUse usual { get; } = new NameUse("usual", "Usual", "Known as/conventional/the one you normally use.");
        public static NameUse official { get; } = new NameUse("official", "Official", "The formal name as registered in an official(government) registry, but which name might not be commonly used. May be called \"legal name\".");
        public static NameUse temp { get; } = new NameUse("temp", "Temp", "A temporary name. Name.period can provide more detailed information. This may also be used for temporary names assigned at birth or in emergency situations.");
        public static NameUse nickname { get; } = new NameUse("nickname", "Nickname", "A name that is used to address the person in an informal manner, but is not part of their formal or usual name.");
        public static NameUse anonymous { get; } = new NameUse("anonymous", "Anonymous", "Anonymous assigned name, alias, or pseudonym (used to protect a person's identity for privacy reasons).");
        public static NameUse old { get; } = new NameUse("old", "Old", "This name is no longer in use (or was never correct, but retained for records).");
        public static NameUse maiden { get; } = new NameUse("maiden", "Name changed for Marriage", "A name used prior to changing name because of marriage. This name use is for use by applications that collect and store names that were used prior to a marriage. Marriage naming customs vary greatly around the world, and are constantly changing. This term is not gender specific. The use of this term does not imply any particular history for a person's name.");
        public NameUse(string id, string name, string description) : base(id, name, description)
        {
        }
    }
}

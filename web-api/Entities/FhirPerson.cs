using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace webapi.Entities
{
    [TypeConverter(typeof(FhirPersonConverter))]
    public class FhirPerson
    {
        public string id { get; set; }
        public bool active { get; set; }
        public AdministrativeGender gender { get; set; }
        public DateTime birthDate { get; set; }
        public List<HumanName> name { get; set; }

        public static implicit operator Person(FhirPerson person) => TypeDescriptor.GetConverter(typeof(FhirPerson)).ConvertTo(person, typeof(Person)) as Person;
        public static implicit operator FhirPerson(Person person) => TypeDescriptor.GetConverter(typeof(FhirPerson)).ConvertFrom(person) as FhirPerson;
     
        private class FhirPersonConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return typeof(Person) == sourceType;
            }

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                var person = value as Person;

                return new FhirPerson 
                { 
                    id = person.documentId.ToString(),
                    active = person.active,
                    gender = person.gender,
                    birthDate = person.birthDate,
                    name = person.name
                };
            }

            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                return typeof(Person) == destinationType;
            }

            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
            {
                var fhirPerson = value as FhirPerson;

                return new Person
                {
                    documentId = (fhirPerson.id == null) ? default : Guid.Parse(fhirPerson.id),
                    active = fhirPerson.active,
                    gender = fhirPerson.gender,
                    birthDate = fhirPerson.birthDate,
                    name = fhirPerson.name
                };
            }
        }
    }
}

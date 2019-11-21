using System;
using System.Collections.Generic;
using webapi.Entities;

namespace webapi
{
    public class Person : CouchDbDocument
    {
        public bool active { get; set; }
        public AdministrativeGender gender { get; set; }
        public DateTime birthDate { get; set; }
        public List<HumanName> name { get; set; }
    }
}

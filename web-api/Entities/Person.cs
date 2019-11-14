using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Entities;

namespace webapi
{
    public class Person : Document
    {
        public bool active { get; set; }
        public AdministrativeGender gender { get; set; }
        public DateTime birthDate { get; set; }
        public List<HumanName> name { get; set; }
    }
}

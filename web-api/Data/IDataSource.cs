using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace webapi.Data
{
    public interface IDataSource : IDisposable
    {
        public Task<Person> GetPerson(Guid id);
        public Task<Person[]> FindPersons();
    }
}

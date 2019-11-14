using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace webapi.Data
{
    public interface IDataSource : IDisposable
    {
        public Task<ActionResult<Person>> GetPerson(Guid id);
        public Task<ActionResult<Person[]>> FindPersons();
    }
}

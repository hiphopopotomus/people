using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Entities;

namespace webapi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IDataSource _dataSource;

        public PersonController(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        [HttpGet]
        public async Task<ActionResult<FhirPerson[]>> GetPersonList()
        {
            return (await _dataSource.FindPersons().ConfigureAwait(false)).Select(p => (FhirPerson)p).ToArray();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            return await _dataSource.GetPerson(id).ConfigureAwait(false);
        }
    }
}
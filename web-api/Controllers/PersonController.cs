using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;

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
        public async Task<ActionResult<Person[]>> GetPersonList()
        {
            return await _dataSource.FindPersons().ConfigureAwait(true);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            return await _dataSource.GetPerson(id).ConfigureAwait(true);
        }
    }
}
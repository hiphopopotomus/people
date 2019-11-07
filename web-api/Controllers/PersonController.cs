using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace web_api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IConfiguration _configuration;
        private static HttpClient _httpClient = new HttpClient();

        public PersonController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<Person>> GetPersonList()
        {
            var data = await _httpClient.GetStringAsync(_configuration["repository-uri"] + "people/04013a4fe3d826de43d931c45300013b");
            return JsonConvert.DeserializeObject<Person>(data);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(long id)
        {
            var data = await _httpClient.GetStringAsync(_configuration["repository-uri"] + "people/" + id);
            return JsonConvert.DeserializeObject<Person>(data);
        }
    }
}
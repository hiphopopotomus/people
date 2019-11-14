using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using webapi.Entities;

namespace webapi.Data
{
    public sealed class CouchDbDataSource : IDataSource
    {
        private IConfiguration _configuration;
        private HttpClient _httpClient = new HttpClient();

        public CouchDbDataSource(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            var location = GetUriBuilder(id.ToString("N", CultureInfo.InvariantCulture));
            var result = await _httpClient.GetStringAsync(location.Uri).ConfigureAwait(false);
            return JsonSerializer.Deserialize<Person>(result);
        }

        public async Task<ActionResult<Person[]>> FindPersons()
        {
            var content = await PostRequest("_find", "{\"selector\": {\"type\":\"Person\"}}").ConfigureAwait(false);
            var searchResult = JsonSerializer.Deserialize<CouchDbSearchResponse>(content);

            return JsonSerializer.Deserialize<Person[]>(JsonSerializer.Serialize(searchResult.docs));
        }

        private UriBuilder GetUriBuilder(string path)
        {
            return new UriBuilder
            {
                Host = _configuration.GetSection("repository")["host"],
                Port = int.Parse(_configuration.GetSection("repository")["port"], CultureInfo.InvariantCulture),
                Path = $"{_configuration.GetSection("repository")["name"]}/{path}"
            };
        }

        private async Task<string> PostRequest(string path, string body)
        {
            var location = GetUriBuilder(path);
            using var request = GetJsonContent(body);
            var response = await _httpClient.PostAsync(location.Uri, request).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        private static HttpContent GetJsonContent(string body)
        {
            return new StringContent(body, Encoding.UTF8, MediaTypeNames.Application.Json);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestCountriesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CountriesController(IHttpClientFactory httpClientFactory)
        {
           _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries([FromQuery] string param1, [FromQuery] string param2, [FromQuery] string param3, [FromQuery] string param4)
        {
            // Create the URL with parameters (you can customize this based on your requirements).
            string apiUrl = "https://restcountries.com/v3.1/all";

            // Make the HTTP request to the REST Countries API.
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                // Parse the JSON response to a variable/object.
                var json = await response.Content.ReadAsStringAsync();
                var countriesData = JsonSerializer.Deserialize<object>(json);

                return Ok(countriesData);
            }

            return BadRequest("Failed to retrieve data from the API.");
        }
    }
}

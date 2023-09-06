using ApiCountryDataCollector.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CountriesController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }

    [HttpGet("getCountry")]
    public async Task<IActionResult> GetCountry(
        [FromQuery] string param1 = null,
        [FromQuery] int param2 = 0,
        [FromQuery] string param3 = null,
        [FromQuery] string param4 = null)
    {
        try
        {
            // Construct the API URL
            var apiUrl = "https://restcountries.com/v3.1/all";

            // Make a request to the REST Countries API
            using var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync(apiUrl);

            // Deserialize the JSON response to a list of Country objects
            var countries = JsonSerializer.Deserialize<List<Country>>(response);

            // Apply your parameter filtering logic here if needed

            return Ok(countries);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

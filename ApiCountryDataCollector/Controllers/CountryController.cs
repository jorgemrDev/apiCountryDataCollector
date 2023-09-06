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
        [FromQuery] string searchQuery = "st",
        [FromQuery] int maxPopulation = 1111111,
        [FromQuery] string sortOrder = "ascend",
        [FromQuery] int numberOfRecords = 10)
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

            countries = FilterCountriesByName(countries, searchQuery);
            countries = FilterCountriesByPopulation(countries, maxPopulation);
            countries = SortCountriesByName(countries, sortOrder);
            countries = LimitRecords(countries, numberOfRecords);

            return Ok(countries);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    private static List<Country> FilterCountriesByName(List<Country> countries, string searchQuery)
    {
        // Use LINQ to filter countries based on the search query
        searchQuery = searchQuery.ToLower(); // Make the search case-insensitive

        List<Country> filteredCountries = countries
            .Where(country => country.name.common.ToLower().Contains(searchQuery))
            .ToList();

        return filteredCountries;
    }

    private static List<Country> FilterCountriesByPopulation(List<Country> countries, int maxPopulation)
    {
        // Use LINQ to filter countries based on the maximum population
        List<Country> filteredCountries = countries
            .Where(country => country.population < maxPopulation)
            .ToList();

        return filteredCountries;
    }

    private static List<Country> SortCountriesByName(List<Country> countries, string sortOrder)
    {
        // Use LINQ to sort countries by name in ascending or descending order
        if (sortOrder.ToLower() == "ascend")
        {
            return countries.OrderBy(country => country.name.common).ToList();
        }
        else if (sortOrder.ToLower() == "descend")
        {
            return countries.OrderByDescending(country => country.name.common).ToList();
        }
        else
        {
            throw new ArgumentException("Invalid sortOrder. Use 'ascend' or 'descend'.");
        }
    }

    private static List<Country> LimitRecords(List<Country> countries, int numberOfRecords)
    {
        // Use LINQ to take the first 'numberOfRecords' records
        List<Country> limitedCountries = countries
            .Take(numberOfRecords)
            .ToList();

        return limitedCountries;
    }
}

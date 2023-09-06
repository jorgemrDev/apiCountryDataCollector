using ApiCountryDataCollector.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace YourNamespace.Tests
{
    [TestClass]
    public class CountriesControllerTests
    {
        private CountriesController _controller;
        private Mock<IHttpClientFactory> _mockHttpClientFactory;

        [TestInitialize]
        public void Initialize()
        {
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();
            _controller = new CountriesController(_mockHttpClientFactory.Object);
        }

        [TestMethod]
        public async Task GetCountry_ReturnsOkResult()
        {
            // Arrange
            var httpClient = new HttpClient();
            _mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            // Act
            var result = await _controller.GetCountry();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetCountry_WithInvalidSortOrder_ReturnsBadRequest()
        {
            // Arrange
            var httpClient = new HttpClient();
            _mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            // Act
            var result = await _controller.GetCountry(sortOrder: "invalid");

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task GetCountry_WithFilter_ReturnsFilteredResults()
        {
            var httpClient = new HttpClient();
            _mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            // Act
            var result = await _controller.GetCountry(searchQuery: "st");

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okObjectResult = (OkObjectResult)result;
            List<Country> filteredCountries = (List<Country>)okObjectResult.Value;
            Assert.AreEqual(6, filteredCountries.Count);
            Assert.AreEqual("Christmas Island", filteredCountries[0].name.common);
        }

        [TestMethod]
        public async Task GetCountry_WithPopulationFilter_ReturnsFilteredResults()
        {
            var httpClient = new HttpClient();
            _mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            // Act
            var result = await _controller.GetCountry(maxPopulation: 10000000);


            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okObjectResult = (OkObjectResult)result;
            List<Country> filteredCountries = (List<Country>)okObjectResult.Value;
            Assert.AreEqual(10, filteredCountries.Count);
            Assert.AreEqual("Austria", filteredCountries[0].name.common);
        }

        [TestMethod]
        public async Task GetCountry_WithLimit_ReturnsFilteredResults()
        {
            var httpClient = new HttpClient();
            _mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            // Act
            var result = await _controller.GetCountry(numberOfRecords: 3);


            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okObjectResult = (OkObjectResult)result;
            List<Country> filteredCountries = (List<Country>)okObjectResult.Value;
            Assert.AreEqual(3, filteredCountries.Count);
            Assert.AreEqual("Christmas Island", filteredCountries[0].name.common);
        }

        [TestMethod]
        public async Task GetCountry_Sorting_ReturnsFilteredResults()
        {
            var httpClient = new HttpClient();
            _mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            // Act
            var result = await _controller.GetCountry(sortOrder: "descend");


            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okObjectResult = (OkObjectResult)result;
            List<Country> filteredCountries = (List<Country>)okObjectResult.Value;
            Assert.AreEqual(6, filteredCountries.Count);
            Assert.AreEqual("Western Sahara", filteredCountries[0].name.common);
        }
    }
}

using System;
using System.Threading.Tasks;
using Xunit;
using WebApiDates;
using Microsoft.AspNetCore.Mvc.Testing;

namespace tests
{
    public class WebApiTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public WebApiTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task DateTimeTests()
        {
            // Arrange
            var client = _factory.CreateClient();
            var date = "2021-08-21";

            // Act
            var response = await client.GetAsync($"/webapidates/datetime?date={date}");

            Console.WriteLine(response.StatusCode);
            // Assert
            // Assert.Equal(expectedResponseCode.ToString(), response.StatusCode);
        }

        [Fact]
        public async Task StringTests()
        {
            // Arrange
            var client = _factory.CreateClient();
            var date = "2021-08-21";

            // Act
            var response = await client.GetAsync($"/webapidates/string?date={date}");

            Console.WriteLine(response.);
            // Assert
            // Assert.Equal(expectedResponseCode.ToString(), response.StatusCode);
        }        
    }
}

using System.Threading.Tasks;
using Xunit;
using WebApiDates;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace WebApiDates.Tests
{
    public class WebApiTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public WebApiTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("2021-08-21", HttpStatusCode.OK)]
        [InlineData("2021-21-08", HttpStatusCode.BadRequest)]
        [InlineData("08-21-2021", HttpStatusCode.BadRequest)]
        [InlineData("21-08-2021", HttpStatusCode.BadRequest)]
        [InlineData("2021/08/21", HttpStatusCode.BadRequest)]
        [InlineData("2021/21/08", HttpStatusCode.BadRequest)]
        [InlineData("08/21/2021", HttpStatusCode.BadRequest)]
        [InlineData("21/08/2021", HttpStatusCode.BadRequest)]
        [InlineData("08.21.2021", HttpStatusCode.BadRequest)]
        [InlineData("21.08.2021", HttpStatusCode.BadRequest)]
        [InlineData("2021.08.21", HttpStatusCode.BadRequest)]
        [InlineData("2021.21.08", HttpStatusCode.BadRequest)]
        public async Task DateTimeTests(string date, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            using var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/webapidates/datetime?date={date}");

            // Assert
            Assert.Equal(expectedStatusCode, response.StatusCode);
        }
    }
}

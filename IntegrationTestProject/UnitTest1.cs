using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace IntegrationTestProject
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public UnitTest1(WebApplicationFactory<Program> factory) {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/contacts")]
        public async void Test1(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();                     // Status Code 200-299

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());

            var body = await response.Content.ReadAsStringAsync();

            Assert.NotNull(body);
        }
    }
}
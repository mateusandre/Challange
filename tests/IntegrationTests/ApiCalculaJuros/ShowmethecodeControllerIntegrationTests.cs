using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.ApiCalculaJuros
{
    public class ShowmethecodeControllerIntegrationTests
        : IClassFixture<WebApplicationFactory<Application.ApiCalculaJuros.Startup>>
    {
        private readonly WebApplicationFactory<Application.ApiCalculaJuros.Startup> _factory;

        public ShowmethecodeControllerIntegrationTests(WebApplicationFactory<Application.ApiCalculaJuros.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/showmethecode")]
        public async Task Get_EndpointsReturnSuccess(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299            
        }
    }
}

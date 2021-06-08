using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }        
    }
}

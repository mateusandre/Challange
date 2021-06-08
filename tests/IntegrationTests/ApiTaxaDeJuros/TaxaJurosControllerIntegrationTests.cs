using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.ApiTaxaDeJuros
{
    public class TaxaJurosControllerIntegrationTests
        : IClassFixture<WebApplicationFactory<Application.ApiTaxaDeJuros.Startup>>
    {
        private readonly WebApplicationFactory<Application.ApiTaxaDeJuros.Startup> _factory;
        public TaxaJurosControllerIntegrationTests(WebApplicationFactory<Application.ApiTaxaDeJuros.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/taxajuros")]
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

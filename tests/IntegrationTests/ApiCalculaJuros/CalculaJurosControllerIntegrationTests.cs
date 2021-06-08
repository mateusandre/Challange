using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.ApiCalculaJuros
{
    public class CalculaJurosControllerIntegrationTests
    {
        [Theory]
        [InlineData("/calculaJuros?valorInicial=100&meses=5")]
        public async Task Get_CalculoReturnSuccess(string url)
        {
            //Arrange
            IWebHostBuilder serverTaxaDeJurosBuilder = new WebHostBuilder()
             .UseStartup<Application.ApiTaxaDeJuros.Startup>()
             .UseKestrel(options => options.Listen(IPAddress.Any, 80))
             .UseUrls("http://localhost:15001")
             .UseIIS()
             .UseConfiguration(new ConfigurationBuilder()
              .Build()
             );

            TestServer taxaDeJurosServer = new TestServer(serverTaxaDeJurosBuilder);
            var handler1 = taxaDeJurosServer.CreateHandler();

            HttpClient client1 = taxaDeJurosServer.CreateClient();
            client1.BaseAddress = new Uri("http://localhost:5001");

            IWebHostBuilder serverCalculaJurosBuilder = new WebHostBuilder()
             .UseStartup<Application.ApiCalculaJuros.Startup>()
             .ConfigureTestServices(
              services =>
              {
                  //Inject HttpClient that's able to connect to server 1.
                  services.AddSingleton(typeof(HttpClient), client1);
                  services.AddHttpClient("TaxaDeJuros", c => c.BaseAddress = taxaDeJurosServer.BaseAddress)
                  .ConfigurePrimaryHttpMessageHandler(_ => handler1);
              })
             .UseKestrel(options => options.Listen(IPAddress.Any, 81))
             .UseIIS()
             .UseConfiguration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
              .Build()
             );
            TestServer calculaJurosServer = new TestServer(serverCalculaJurosBuilder);

            HttpClient client2 = calculaJurosServer.CreateClient();

            // Act
            var response = await client2.GetAsync(url);

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var resultado = await JsonSerializer.DeserializeAsync<decimal>(responseStream);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal((decimal)105.10, resultado);
        }
    }
}

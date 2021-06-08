using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infraestructure.Crosscutting
{
    public class HttpTaxaDeJurosApi : IHttpTaxaDeJurosAPI
    {
        protected readonly IHttpClientFactory _clientFactory;

        public HttpTaxaDeJurosApi(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<decimal> ObterTaxaDeJuros()
        {            
            var request = new HttpRequestMessage(HttpMethod.Get, "taxaJuros");
            var httpClient = _clientFactory.CreateClient("TaxaDeJuros");

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<decimal>(responseStream);
            }
            else
            {
                throw new HttpRequestException("Não foi possível obter a taxa de juros.");
            }
        }
    }
}

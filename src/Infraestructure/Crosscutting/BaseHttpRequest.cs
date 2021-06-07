using System.Net.Http;

namespace Infraestructure.Crosscutting
{
    public class BaseHttpRequest
    {
        protected readonly IHttpClientFactory _clientFactory;
        
        public BaseHttpRequest(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;

        }
    }
}

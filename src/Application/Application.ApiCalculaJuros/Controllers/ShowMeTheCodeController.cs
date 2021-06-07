using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Application.ApiCalculaJuros.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ShowMeTheCodeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            return _configuration["GitHubRepository"];
        }
    }
}

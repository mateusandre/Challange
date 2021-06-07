using Microsoft.AspNetCore.Mvc;
using Service;
using System.Threading.Tasks;

namespace Application.ApiCalculaJuros.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculoDeJurosService _calculoDeJurosService;
        public CalculaJurosController(ICalculoDeJurosService calculoDeJurosService)
        {
            _calculoDeJurosService = calculoDeJurosService;
        }

        [HttpGet]
        public async Task<decimal> Get(decimal valorInicial, int tempo)
        {
            return await _calculoDeJurosService.CalcularJuros(valorInicial, tempo);
        }        
    }
}

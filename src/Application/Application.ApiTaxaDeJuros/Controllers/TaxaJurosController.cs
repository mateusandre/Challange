using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ApiTaxaDeJuros.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxaDeJurosService _taxaDeJurosService;
        public TaxaJurosController(ITaxaDeJurosService taxaDeJurosService)
        {
            _taxaDeJurosService = taxaDeJurosService;
        }

        [HttpGet]
        public async Task<decimal> Get()
        {
            return await _taxaDeJurosService.ObterTaxaDeJuros();
        }
    }
}

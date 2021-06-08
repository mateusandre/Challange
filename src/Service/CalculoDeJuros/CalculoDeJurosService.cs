using Domain.Models;
using Infraestructure.Crosscutting;
using System;
using System.Threading.Tasks;

namespace Service
{
    public class CalculoDeJurosService : ICalculoDeJurosService
    {
        private readonly IHttpTaxaDeJurosAPI _apiTaxaDeJuros;
        public CalculoDeJurosService(IHttpTaxaDeJurosAPI apiTaxaDeJuros)
        {
            _apiTaxaDeJuros = apiTaxaDeJuros;
        }

        public async Task<decimal> CalcularJuros(double valorInicial, int meses)
        {
            try
            {
                var taxaDeJuros = await _apiTaxaDeJuros.ObterTaxaDeJuros();
                var jurosCompostos = new JurosCompostos((double)taxaDeJuros, valorInicial, meses);

                return jurosCompostos.CalcularJuros();
            }            
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao realizar o cálculo de juros. { ex.Message }");
            }
        }
    }
}

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

        public async Task<decimal> CalcularJuros(decimal valorInicial, int tempo)
        {
            try
            {
                var taxaDeJuros = await _apiTaxaDeJuros.ObterTaxaDeJuros();
                var valorFinal = (double)valorInicial * Math.Pow((double)(1 + taxaDeJuros), tempo);
                return decimal.Parse(valorFinal.ToString("N2"));
            }            
            catch (Exception)
            {
                throw;
            }
        }
    }
}

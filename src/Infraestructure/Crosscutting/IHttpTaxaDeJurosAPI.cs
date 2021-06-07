using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Crosscutting
{
    public interface IHttpTaxaDeJurosAPI
    {
        Task<decimal> ObterTaxaDeJuros();
    }
}

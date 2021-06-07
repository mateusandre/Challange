using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TaxaDeJurosService : ITaxaDeJurosService
    {
        public async Task<decimal> ObterTaxaDeJuros()
        {
            return await Task.Run(() => { return TaxaDeJuros.Taxa; });
        }
    }
}

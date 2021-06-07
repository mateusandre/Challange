using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ITaxaDeJurosService
    {
        Task<decimal> ObterTaxaDeJuros();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICalculoDeJurosService
    {
        Task<decimal> CalcularJuros(double valorInicial, int meses);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class JurosCompostos
    {
        public double TaxaDeJuros { get; private set; }
        public double ValorInicial { get; private set; }
        public int Meses { get; private set; }

        public JurosCompostos(double taxaDeJuros, double valorInicial, int meses )
        {
            TaxaDeJuros = taxaDeJuros;
            ValorInicial = valorInicial;
            Meses = meses;
        }

        public decimal CalcularJuros()
        {
            var valorFinal = ValorInicial * Math.Pow((1 + TaxaDeJuros), Meses);
            return decimal.Parse(valorFinal.ToString("N2"));
        }
    }
}

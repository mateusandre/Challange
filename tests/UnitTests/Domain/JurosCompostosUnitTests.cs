using Domain.Models;
using Xunit;

namespace UnitTests.Domain
{
    public class JurosCompostosUnitTests
    {
        [Fact]
        public void DeveRetornarValorDecimal()
        {
            //Arrange
            double valorInicial = 100;
            double taxaDeJuros = 0.01;
            int meses = 5;
            var jurosCompostos = new JurosCompostos(taxaDeJuros, valorInicial, meses);

            //Act
            var resultado = jurosCompostos.CalcularJuros();

            //Assert
            Assert.Equal((decimal)105.10, resultado);
        }
    }
}

using Infraestructure.Crosscutting;
using Moq;
using Service;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Service
{
    public class CalculoDeJurosServiceUnitTests
    {
        [Fact]
        public async Task DeveCalcularOsJurosCompostosCorretamente()
        {
            //Arrange
            double valorInicial = 100;
            int meses = 5;
            var mockHttpTaxaDeJurosApi = new Mock<IHttpTaxaDeJurosAPI>();
            mockHttpTaxaDeJurosApi.Setup(x => x.ObterTaxaDeJuros()).ReturnsAsync((decimal)0.01);

            var calculoDeJurosService = new CalculoDeJurosService(mockHttpTaxaDeJurosApi.Object);

            //Act
            var resultado = await calculoDeJurosService.CalcularJuros(valorInicial, meses);

            //Assert
            Assert.Equal((decimal)105.10, resultado);
        }
    }
}

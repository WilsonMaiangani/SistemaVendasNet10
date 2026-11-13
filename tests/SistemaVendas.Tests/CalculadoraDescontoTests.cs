using SistemaVendas.Console;

namespace SistemaVendas.Tests;

public class CalculadoraDescontoTests
{
    [Fact]
    public void AplicarDesconto_ComValoresValidos_DeveRetornarValorComDesconto()
    {
        var calc = new CalculadoraDesconto();
        var resultado = calc.AplicarDesconto(200m, 10m);
        Assert.Equal(180m, resultado);
    }

    [Fact]
    public void AplicarDesconto_ComPercentagemAcimaDe100_DeveLancarExcecao()
    {
        var calc = new CalculadoraDesconto();
        Assert.Throws<ArgumentException>(() => calc.AplicarDesconto(200m, 110m));
    }
}

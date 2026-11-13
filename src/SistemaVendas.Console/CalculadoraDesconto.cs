namespace SistemaVendas.Console;

public class CalculadoraDesconto
{
    public decimal AplicarDesconto(decimal valorTotal, decimal percentagemDesconto)
    {
        if (valorTotal < 0 || percentagemDesconto < 0 || percentagemDesconto > 100)
            throw new ArgumentException("Valores inválidos para cálculo de desconto.");

        return valorTotal - (valorTotal * (percentagemDesconto / 100m));
    }
}

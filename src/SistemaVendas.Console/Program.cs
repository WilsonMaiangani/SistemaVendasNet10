

using SistemaVendas.Console;

var calc = new CalculadoraDesconto();
decimal valorFinal = calc.AplicarDesconto(1000m, 15m);

System.Console.WriteLine("=== Sistema de Vendas .NET 10 ===");
System.Console.WriteLine($"Valor Original: 1000.00 | Com 15% de desconto: {valorFinal:F2}");

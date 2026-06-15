using Comum.Financeiro;

namespace Comum.Financiero.Testes;

public class PercentualTests
{
    [Fact]
    public void DeveCriarPercentual()
    {
        var percentual = Percentual.De(10m);
        
        Assert.Equal(10m, percentual.Valor);
    }
    
    [Fact]
    public void DeveProibirPercentual()
    {
        var percentual = Percentual.De(-1m);
        
        Assert.Throws<ValorFinanceiroInvalidoException>(()=> percentual);
    }
    
    [Fact]
    public void DeveConverterparaFatorDeDesconto()
    {
        var percentual = Percentual.De(10m);
        
        var fator = percentual.ComFatorDeDesconto();
        
        Assert.Equal(0.90m, fator);
    }
    
    [Fact]
    public void DeveConverterParaFatorDeAcrecimo()
    {
        var percentual = Percentual.De(10m);
        
        var fator = percentual.ComFatorDeAcrecimo();
        
        Assert.Equal(1.10m, fator);
    }
}
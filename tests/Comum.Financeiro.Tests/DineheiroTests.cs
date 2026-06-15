using Comum.Financeiro;

public class DinheiroTests
{
    [Fact]
    public void DeveCriarDinheiroEmBrl()
    {
        var dinheiro = Dinheiro.EmReais(10.50m);

        // Teste de integridade
        Assert.Equal(10.50m, dinheiro.Valor);
        Assert.Equal(Moeda.RealBrasileiro, dinheiro.Moeda);
    }

    [Fact]
    public void DeveSomarDoisValoresemBrl()
    {
        var primeiroValor = Dinheiro.EmReais(10m);
        var segundoValor = Dinheiro.EmReais(5.50m);

        var resultado = primeiroValor.Somar(segundoValor);

        Assert.Equal(15.50m, resultado.Valor);
        Assert.Equal(Moeda.RealBrasileiro, resultado.Moeda);
    }

    [Fact]
    public void DeveSubtrairDoisValoresEmBrl()
    {
        var primeiroDinheiro = Dinheiro.EmReais(30m);
        var segundoDinheiro = Dinheiro.EmReais(10.50m);

        var resultado = primeiroDinheiro.Subtrair(segundoDinheiro);

        Assert.Equal(19.50m, resultado.Valor);
        Assert.Equal(Moeda.RealBrasileiro, resultado.Moeda);
    }

    [Fact]
    public void DeveImpedirSomaEntreBrlUSD()
    {
        var dinheiroEmBrl = Dinheiro.EmReais(10m);
        var dinheiroEmUSD = Dinheiro.EmDolar(20m);

        var resultado = dinheiroEmBrl.Somar(dinheiroEmUSD);

        Assert.Throws<MoedasDiferentesException>(() => dinheiroEmBrl.Somar(dinheiroEmUSD));
    }

    [Fact]
    public void DeveImpedirSubtracaoEntreBrlUSD()
    {
        var dinheiroEmBrl = Dinheiro.EmReais(10m);
        var dinheiroEmUSD = Dinheiro.EmDolar(20m);

        var resultado = dinheiroEmBrl.Somar(dinheiroEmUSD);

        Assert.Throws<MoedasDiferentesException>(() => dinheiroEmBrl.Subtrair(dinheiroEmUSD));
    }

    [Fact]
    public void DeveMultiplicarDinheiroPorQuantidade()
    {
        var dinheiro = Dinheiro.EmReais(20m);
        
        var resultado = dinheiro.Multiplicar(2m);
        
        Assert.Equal(40m, resultado.Valor);
        Assert.Equal(Moeda.RealBrasileiro, resultado.Moeda);
    }

    [Fact]
    public void DeveVerificarValorEhZero()
    {
        var dinheiro = Dinheiro.EmReais(0m);

        Assert.True(dinheiro.EhZero());
        Assert.False(dinheiro.EhPositivo());
        Assert.False(dinheiro.EhNegativo());
    }

    [Fact]
    public void DeveVerificarValorEhPositivo()
    {
        var dinheiro = Dinheiro.EmReais(1m);

        Assert.False(dinheiro.EhZero());
        Assert.True(dinheiro.EhPositivo());
        Assert.False(dinheiro.EhNegativo());
    }

    [Fact]
    public void DeveVerifivarValorEhNegativo()
    {
        var dinheiro = Dinheiro.EmReais(-1m);

        Assert.False(dinheiro.EhZero());
        Assert.False(dinheiro.EhPositivo());
        Assert.True(dinheiro.EhNegativo());
    }
    
    [Fact]
    public void DeveFormatarValorEmReais()
    {
        var dinheiro = Dinheiro.EmReais(10.5m);
        var valorFormatado = dinheiro.Formatar();
        
        Assert.Contains("R$", valorFormatado);
        Assert.Contains("10,60", valorFormatado);
    }
    
    [Fact]
    public void DeveAplicarDescontoPercentual()
    {
        var dinheiro = Dinheiro.EmReais(100m);
        var desconto = Percentual.De(10m);
        
        var resultado = dinheiro.AplicarDesconto(desconto);
        
        Assert.Equal(90m, resultado.Valor);
        Assert.Equal(Moeda.RealBrasileiro, resultado.Moeda);
    }
    
    [Fact]
    public void DeveAplicarAcrecimoPercentual()
    {
        var dinheiro = Dinheiro.EmReais(100m);
        var acrescimo = Percentual.De(10m);
        
        var resultado = dinheiro.AplicarAcrescimo(acrescimo);
        
        Assert.Equal(110m, resultado.Valor);
        Assert.Equal(Moeda.RealBrasileiro, resultado.Moeda);
    }
    
    [Fact]
    public void DeveImpedirDescontoMaiorQueCemPorcento()
    {
        var dinheiro = Dinheiro.EmReais(100m);
        var desconto = Percentual.De(101m);
        
        Assert.Throws<ValorFinanceiroInvalidoException>(() => dinheiro.AplicarDesconto(desconto));
    }
}
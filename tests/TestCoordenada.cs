using Xunit;
using TP1_Algo2_Ro;

public class TestCoordenada
{
    [Fact]
    public void CoordenadaValida()
    {
        Coordenada c = new(1, 1);
        Assert.True(c.EsValida());
    }

    [Theory]
    [InlineData(-1, -1)]
    [InlineData(11, 11)]
    public void CoordenadaInvalida(int x, int y)
    {
        Coordenada c = new(x, y);
        Assert.False(c.EsValida());
    }

    [Fact]
    public void CoordenadasIguales()
    {
        Coordenada c1 = new(1, 1);
        Coordenada c2 = new(1, 1);
        Assert.Equal(c1, c2);
    }

    [Fact]
    public void CoordenadasDistintas()
    {
        Coordenada c1 = new(1, 1);
        Coordenada c2 = new(2, 2);
        Assert.NotEqual(c1, c2);
    }
}
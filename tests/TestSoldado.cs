using Xunit;
using TP1_Algo2_Ro;

public class TestSoldado
{
    [Fact]
    public void TestMoverse()
    {
        Coordenada origen = new(1, 1);
        Coordenada destino = new(2, 2);
        Soldado s = new(origen, 1);
        Assert.Equal(s.posicion, origen);
        s.Moverse(destino);
        Assert.Equal(s.posicion, destino);
    }
}
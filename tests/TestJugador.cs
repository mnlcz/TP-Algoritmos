using Xunit;
using TP1_Algo2_Ro;

public class TestJugador
{
    private Jugador BaseSample()
    {
        Soldado[] soldados = new[]
        {
            new Soldado(new Coordenada(1, 1), 1),
            new Soldado(new Coordenada(2, 2), 2),
            new Soldado(new Coordenada(3, 3), 3)
        };
        return new Jugador(soldados);
    }
    
    private Jugador BaseSample(Soldado s1)
    {
        Soldado[] soldados = new[]
        {
            s1,
            new Soldado(new Coordenada(2, 2), 2),
            new Soldado(new Coordenada(3, 3), 3)
        };
        return new Jugador(soldados);
    }

    [Fact]
    public void TestEncontrarSoldado()
    {
        Soldado s1 = new(new Coordenada(1, 1), 1);
        Jugador j = BaseSample(s1);
        Assert.NotNull(j.EncontrarSoldado(s1.posicion));
    }

    [Fact]
    public void TestNoEncontrarSoldado()
    {
        Soldado s1 = new(new Coordenada(4, 4), 4);
        Jugador j = BaseSample();
        Assert.Null(j.EncontrarSoldado(s1.posicion));
    }

    [Fact]
    public void TestActualizarSoldados()
    {
        Soldado s1 = new(new Coordenada(1, 1), 1);
        Jugador j = BaseSample(s1);
        Assert.Contains(s1, j.soldados);
        s1.eliminado = true;
        j.ActualizarSoldados();
        Assert.DoesNotContain(s1, j.soldados);
    }
}
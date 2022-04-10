using TP1_Algo2_Ro;
using Xunit;

namespace TP1_Algo2_Ro.tests
{
    public class TestJugador
    {
        private static Jugador BaseSample()
        {
            Soldado[] soldados = new[]
            {
            new Soldado(new Coordenada(1, 1), 1),
            new Soldado(new Coordenada(2, 2), 2),
            new Soldado(new Coordenada(3, 3), 3)
        };
            return new Jugador(soldados);
        }

        private static Jugador BaseSample(Soldado s1)
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
            Assert.NotNull(j.EncontrarSoldado(s1.Posicion));
        }

        [Fact]
        public void TestNoEncontrarSoldado()
        {
            Soldado s1 = new(new Coordenada(4, 4), 4);
            Jugador j = BaseSample();
            Assert.Null(j.EncontrarSoldado(s1.Posicion));
        }

        [Fact]
        public void TestActualizarSoldados()
        {
            Soldado s1 = new(new Coordenada(1, 1), 1);
            Jugador j = BaseSample(s1);
            Assert.Contains(s1, j.Soldados);
            s1.Eliminado = true;
            j.ActualizarSoldados();
            Assert.DoesNotContain(s1, j.Soldados);
        }
    }
}
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
            return new Jugador(soldados, 1);
        }

        private static Jugador BaseSample(Soldado s1)
        {
            Soldado[] soldados = new[]
            {
            s1,
            new Soldado(new Coordenada(2, 2), 2),
            new Soldado(new Coordenada(3, 3), 3)
        };
            return new Jugador(soldados, 1);
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

        [Fact]
        public void TestMoverSoldado()
        {
            Coordenada origen = new(1, 1);
            Coordenada destino = new(6, 6);
            Soldado s1 = new(origen, 1);
            Jugador j = BaseSample(s1);
            Assert.Equal(origen, s1.Posicion);
            j.MoverSoldado(1, destino);
            Assert.Equal(destino, s1.Posicion);
        }
    }
}
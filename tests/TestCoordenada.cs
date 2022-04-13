using TP1_Algo2_Ro;
using Xunit;

namespace TP1_Algo2_Ro.tests
{
    public class TestCoordenada
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(9, 9)]
        public void CoordenadaValida(int x, int y)
        {
            Coordenada c = new(x, y);
            Assert.True(c.EsValida());
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(10, 10)]
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

        [Fact]
        public void TestDistancia()
        {
            Coordenada c1 = new(1, 1);
            Coordenada c2 = new(1, 2);
            Coordenada c3 = new(0, 0);
            Coordenada c4 = new(9, 9);
            Assert.Equal(1, c1.Distancia(c2));
            Assert.Equal(9, c3.Distancia(c4));
        }
    }
}
using TP1_Algo2_Ro;
using Xunit;

namespace TP1_Algo2_Ro.tests
{
    public class TestSoldado
    {
        [Fact]
        public void TestMoverse()
        {
            Coordenada origen = new(1, 1);
            Coordenada destino = new(2, 2);
            Soldado s = new(origen, 1);
            Assert.Equal(s.Posicion, origen);
            s.Moverse(destino);
            Assert.Equal(s.Posicion, destino);
        }
    }
}
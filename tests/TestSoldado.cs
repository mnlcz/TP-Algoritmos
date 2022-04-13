using TP1_Algo2_Ro;
using Xunit;

namespace TP1_Algo2_Ro.tests
{
    public class TestSoldado
    {
        [Theory]
        [InlineData(Direccion.ABAJO)]
        [InlineData(Direccion.ARRIBA)]
        [InlineData(Direccion.IZQUIERDA)]
        [InlineData(Direccion.DERECHA)]
        [InlineData(Direccion.ABAJO_DERECHA)]
        [InlineData(Direccion.ABAJO_IZQUIERDA)]
        [InlineData(Direccion.ARRIBA_DERECHA)]
        [InlineData(Direccion.ARRIBA_IZQUIERDA)]
        public void TestMoverse(Direccion d)    // FIXME
        {
            Coordenada c = new(1, 1);
            Soldado s = new(c, 1);
            Assert.Equal(c, s.Posicion);
            s.Moverse(d);
            switch(d)
            {
                case Direccion.ARRIBA:
                    Coordenada destino = new(1, 0);
                    Assert.Equal(destino, s.Posicion);
                    break;
                case Direccion.ABAJO:
                    Coordenada destino2 = new(1, 2);
                    Assert.Equal(destino2, s.Posicion);
                    break;
                case Direccion.IZQUIERDA:
                    Coordenada destino3 = new(0, 1);
                    Assert.Equal(destino3, s.Posicion);
                    break;
                case Direccion.DERECHA:
                    Coordenada destino4 = new(2, 1);
                    Assert.Equal(destino4, s.Posicion);
                    break;
                case Direccion.ARRIBA_DERECHA:
                    Coordenada destino5 = new(2, 0);
                    Assert.Equal(destino5, s.Posicion);
                    break;
                case Direccion.ARRIBA_IZQUIERDA:
                    Coordenada destino6 = new(0, 0);
                    Assert.Equal(destino6, s.Posicion);
                    break;
                case Direccion.ABAJO_DERECHA:
                    Coordenada destino7 = new(2, 2);
                    Assert.Equal(destino7, s.Posicion);
                    break;
                case Direccion.ABAJO_IZQUIERDA:
                    Coordenada destino8 = new(0, 2);
                    Assert.Equal(destino8, s.Posicion);
                    break;
            }
        }
    }
}
using TP1_Algo2_Ro;
using Xunit;

namespace TP1_Algo2_Ro.tests
{
    public class TestTablero
    {
        /*
         * TABLERO BASE CON LOS SIGUIENTES CONTENIDOS:
         *      [0, 0] ==> NADA
         *      [0, 1] ==> J1
         *      [0, 2] ==> J2
         *      [0, 3] ==> INACTIVA
         */
        private static Tablero BaseTablero()
        {
            var t = new Tablero();
            t.TableroDeJuego[0, 0] = ' ';
            t.TableroDeJuego[0, 1] = '1';
            t.TableroDeJuego[0, 2] = '2';
            t.TableroDeJuego[0, 3] = 'X';
            return t;
        }

        [Fact]
        public void TestHayAlgoEn()
        {
            var t = BaseTablero();
            Assert.Equal(ObjetoEnCoordenada.NADA, t.QueHayEn(new Coordenada(0, 0)));
            Assert.Equal(ObjetoEnCoordenada.J1, t.QueHayEn(new Coordenada(0, 1)));
            Assert.Equal(ObjetoEnCoordenada.J2, t.QueHayEn(new Coordenada(0, 2)));
            Assert.Equal(ObjetoEnCoordenada.INACTIVA, t.QueHayEn(new Coordenada(0, 3)));
        }

        [Fact]
        public void TestQuitarElementoDe()
        {
            var t = BaseTablero();
            Coordenada c = new(0, 1);
            Assert.Equal(ObjetoEnCoordenada.J1, t.QueHayEn(c));
            t.QuitarElementoDe(c);
            Assert.Equal(ObjetoEnCoordenada.INACTIVA, t.QueHayEn(c));
        }

        // TODO: TestActualizarContenido()
    }
}
using System.Diagnostics;

namespace TP1_Algo2_Ro
{
    public static class Partida
    {
        private static Jugador? ganador;
        private static readonly Jugador j1 = new(x: 0, y1: 0, y2: 1, y3: 2, nro: 1);
        private static readonly Jugador j2 = new(x: 9, y1: 7, y2: 8, y3: 9, nro: 2);
        private static readonly Tablero tablero = new();
        private static Jugador turnoDe = j1;

        public static void Jugar()
        {
            tablero.ActualizarContenido(j1, j2);
            tablero.Mostrar();
            while (ganador == null)
            {
                EmpezarTurno();
                TerminarTurno();
                tablero.ActualizarContenido(j1, j2);
                tablero.Mostrar();
                if (!j1.Soldados.Any())
                    ganador = j1;
                else if (!j2.Soldados.Any())
                    ganador = j2;
            }
            Console.WriteLine($"El ganador es el jugador {ganador.Numero}");
        }

        private static void EmpezarTurno()
        {
            Console.WriteLine($"TURNO DEL JUGADOR {turnoDe.Numero}");
            Console.Write($"El jugador {turnoDe.Numero} tiene disponibles los soldados ");
            turnoDe.MostrarSoldados();
            (uint nSoldado, Coordenada coordenada) = GestionarInput(turnoDe);
            Jugador? victima = turnoDe.Numero == 1 ? j2 : j1;
            Atacar(victima, coordenada);
            /* TODO:
             *      - Preguntar si quiere moverse.
             *      - En caso de que si:
             *          - Nuevo PedirCoordenada() que evalue si hay un enemigo en la posicion.
             *              - En caso de que si eliminar a ambos soldados.
             */
            //turnoDe.MoverSoldado(nSoldado, coordenada);
        }

        // Pre: la coordenada tiene un objeto atacable: j1 ataca a j2 || j2 ataca a j1
        public static void Atacar(Jugador victima, Coordenada coordenada)
        {
            var soldadoEnemigo = victima.EncontrarSoldado(coordenada);
            soldadoEnemigo!.Eliminado = true;
            victima.ActualizarSoldados();
            tablero.QuitarElementoDe(coordenada);
            tablero.CoordenadasInactivas.Add(coordenada);
        }

        public static void TerminarTurno() => turnoDe = (turnoDe == j1) ? j2 : j1;

        private static (uint, Coordenada) GestionarInput(Jugador j)
        {
            var c = PedirCoordenada(j);
            uint nroSoldado;
            do
            {
                Console.Write("Con cual atacas? ");
                nroSoldado = Convert.ToUInt32(Console.ReadLine());
            } while (turnoDe.Soldados.Any(s => s.numero == nroSoldado));
            return (nroSoldado, c);
        }

        // TODO: chequear el input usando regex.
        private static Coordenada PedirCoordenada(Jugador j)
        {
            bool flag;
            Coordenada coordenada;
            do
            {
                flag = false;
                Console.Write("Coordenadas en formato X Y: ");
                string[] temp = Console.ReadLine()!.Split(' ');
                int[] temp2 = Array.ConvertAll(temp, int.Parse);
                coordenada = new(temp2[0], temp2[1]);
                if (!coordenada.EsValida())
                {
                    Console.WriteLine("El formato ingresado no corresponde a una coordenada. Por favor ingresa otra.");
                    flag = true;
                }
                else if (j.Soldados.Any(s => s.Posicion == coordenada))
                {
                    Console.WriteLine("En la coordenada seleccionada hay un soldado tuyo. Por favor ingresa otra");
                    flag = true;
                }
            } while (flag);
            return coordenada;
        }
    }
}
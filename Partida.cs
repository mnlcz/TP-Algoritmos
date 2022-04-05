using System.Diagnostics;

namespace TP1_Algo2_Ro
{
    public static class Partida
    {
        public static Jugador? ganador = null;
        
        public static readonly Jugador j1 = new(x: 0, y1: 0, y2: 1, y3: 2);

        public static readonly Jugador j2 = new(x: 9, y1: 7, y2: 8, y3: 9);

        public static readonly Tablero tablero = new Tablero();
        public static Jugador turnoDe = j1;

        public static void Jugar()
        {
            ActualizarContenido();
            tablero.Mostrar();
            while(ganador == null)
            {
                if(turnoDe == j1)
                {
                    EmpezarTurno(1);
                    TerminarTurno();
                }
                else
                {
                    EmpezarTurno(2);
                    TerminarTurno();
                }
                ActualizarContenido();
                tablero.Mostrar();
                // TODO: Chequear si gano alguien
                // TODO: En caso de que haya ganador salir del while
            }
            Console.WriteLine("El ganador es: ...");
        }

        private static void GestionarAtaque(Soldado atacante, Jugador jugador, Coordenada coordenada)
        {
            var soldadoEnemigo = jugador.EncontrarSoldado(coordenada);
            soldadoEnemigo!.eliminado = true;
            jugador.EliminarSoldado(coordenada);
            tablero.QuitarElementoDe(coordenada);
            tablero.coordenadasInactivas.Append(coordenada);
        }

        private static void EmpezarTurno(int j)
        {
            Console.WriteLine($"TURNO DEL JUGADOR {j}");
            uint temp;
            Console.Write($"El jugador {j} tiene disponibles los soldados ");
            Console.WriteLine(string.Join(", ", turnoDe.soldados));
            do
            {    
                Console.Write("Con cual atacas? ");             // FIXME: al pickear con cual ataca estaria bueno q se vean las coordenadas de cada soldado
                temp = Convert.ToUInt32(Console.ReadLine());
            } while(turnoDe.soldados.Any(s => s.numero == temp));
            var atacante = turnoDe.soldados.First(s => s.numero == temp);
            Atacar(atacante);
            // TODO: Soldado.Moverse()
        }

        public static void Atacar(Soldado atacante)
        {
            var coordenada = PedirCoordenada();
            var victima = tablero.HayAlgoEn(coordenada);
            switch(victima)
            {
                case ObjetoEnCoordenada.NADA:
                    atacante.Moverse(coordenada);
                    break;
                case ObjetoEnCoordenada.INACTIVA: 
                    Atacar(atacante);                                   // FIXME? Cuidado aca
                    break;
                case ObjetoEnCoordenada.J1:                             // Si es el turno del jugador dueño del soldado en la coordenada destino...
                    if(turnoDe == j1)
                        Atacar(atacante);                               // Otra vez...
                    else 
                        GestionarAtaque(atacante, j1, coordenada);      // En caso de que el soldado en la coordenada no sea del jugador q esta jugando... 
                    break;
                case ObjetoEnCoordenada.J2:
                    if(turnoDe == j2)
                            Atacar(atacante);
                    else
                        GestionarAtaque(atacante, j2, coordenada);
                    break;
                default:
                    Debug.Print("DEFAULT CASE");
                    break;
            }
        }
        public static void TerminarTurno()
        {
            turnoDe = (turnoDe == j1) ? j2 : j1;
        }

        public static void ActualizarContenido()
        {
            // Soldados
            for(int i = 0; i < 3; i++)
            {
                var c1 = j1.soldados.ElementAt(i).posicion;
                var c2 = j2.soldados.ElementAt(i).posicion;
                tablero.tablero[c1.X, c1.Y] = '1';
                tablero.tablero[c2.X, c2.Y] = '2';
            }

            // Coordenadas inactivas
            if(tablero.coordenadasInactivas.Length != 0)
            {
                foreach(var c in tablero.coordenadasInactivas)
                {
                    tablero.tablero[c.X, c.Y] = 'X';
                }
            }
        }

        private static Coordenada PedirCoordenada()
        {
            Coordenada coordenada;
            do
            {
                Console.Write("Coordenadas en formato X Y: ");
                string[] temp = Console.ReadLine()!.Split(' ');
                int[] temp2 = Array.ConvertAll(temp, int.Parse);
                coordenada = new(temp2[0], temp2[1]);
            } while(!coordenada.EsValida());
            return coordenada;
        }
    }
}
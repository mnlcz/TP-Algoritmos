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
            TextoInicial();
            (uint nSoldado, Coordenada coordenada) = GestionarInput(turnoDe);
            Soldado s = (from soldado
                        in turnoDe.Soldados
                         where soldado.numero == nSoldado
                         select soldado).First();
            if (tablero.QueHayEn(coordenada) == ObjetoEnCoordenada.J1 || tablero.QueHayEn(coordenada) == ObjetoEnCoordenada.J2)
            {
                Jugador? victima = turnoDe.Numero == 1 ? j2 : j1;
                Atacar(s, victima, coordenada);
            }
            bool quiereMoverse = QuiereMoverse();
            if (quiereMoverse)
            {
                bool invalido = true;
                Direccion d = Direccion.INVALIDA;
                while (invalido)
                {
                    d = PedirDireccion();
                    if (d.MovimientoValido(s.Posicion))
                        invalido = false;
                }
                turnoDe.MoverSoldado(nSoldado, d);
                GestionarEliminacion();
                tablero.ActualizarContenido(j1, j2);
            }
        }

        private static void TextoInicial()
        {
            Console.WriteLine($"TURNO DEL JUGADOR {turnoDe.Numero}");
            Console.WriteLine($"El jugador {turnoDe.Numero} tiene disponibles los soldados ");
            turnoDe.MostrarSoldados();
            Console.WriteLine("===========================================");
            Console.WriteLine($"El rival tiene soldados en las posiciones ");
            if (turnoDe == j1)
                j2.MostrarSoldados();
            else
                j1.MostrarSoldados();
            Console.WriteLine();
        }

        // Pre: la coordenada tiene un objeto atacable: j1 ataca a j2 || j2 ataca a j1
        public static void Atacar(Soldado soldadoAtacante, Jugador victima, Coordenada coordenada)
        {
            var rand = new Random();
            int porcentajeExito = ObtenerPorcentajeExito(soldadoAtacante.Posicion, coordenada);
            var result = rand.Next(1, 101);
            if(result <= porcentajeExito)
            {
                var soldadoEnemigo = victima.EncontrarSoldado(coordenada);
                soldadoEnemigo!.Eliminado = true;
                victima.ActualizarSoldados();
                tablero.QuitarElementoDe(coordenada);
                tablero.CoordenadasInactivas.Add(coordenada);
            }
            else
                Console.WriteLine("El ataque falló...");
        }

        private static int ObtenerPorcentajeExito(Coordenada coordenadaAtacante, Coordenada coordenadaVictima)
        {
            var distancia = coordenadaAtacante.Distancia(coordenadaVictima);
            return distancia switch 
            {
                9 => 10,
                8 => 20,
                7 => 30,
                6 => 40,
                5 => 50,
                4 => 60,
                3 => 70,
                2 => 80,
                1 => 90,
                _ => 0
            };
        }

        public static void TerminarTurno()
        {
            turnoDe = (turnoDe == j1) ? j2 : j1;
            Console.Clear();
            //GenerarArchivos();
        }

        // TODO: implementar
        private static void GenerarArchivos()
        {
            throw new NotImplementedException();
        }

        private static (uint, Coordenada) GestionarInput(Jugador j)
        {
            var c = PedirCoordenada(j);
            uint nroSoldado;
            do
            {
                Console.Write("Con cual atacas? ");
                nroSoldado = Convert.ToUInt32(Console.ReadLine());
            } while (!turnoDe.Soldados.Any(s => s.numero == nroSoldado));
            return (nroSoldado, c);
        }

        private static Coordenada PedirCoordenada(Jugador j)
        {
            Console.WriteLine("===============> ATACANDO <===============");
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

        private static Direccion PedirDireccion()
        {
            Console.Clear();
            bool invalida = true;
            Direccion direccion = Direccion.INVALIDA;
            while (invalida)
            {
                Console.WriteLine("A donde queres mover el soldado? Posibles direcciones: ");
                DireccionExtensions.MostrarOpciones();
                tablero.Mostrar();
                string? input = Console.ReadLine();
                if (input != null)
                {
                    direccion = DireccionExtensions.Mapear(input);
                    if(direccion != Direccion.INVALIDA)
                        invalida = false;
                }
                if (invalida)
                    Console.WriteLine("Direccion invalida, ingresa otra");
            }
            return direccion;
        }

        private static bool QuiereMoverse()
        {
            char? rta;
            while(true)
            {
                Console.Write("Queres moverte? S/N: ");
                rta = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if(rta == 'S' || rta == 'N') break;
                else
                    Console.WriteLine("Respuesta invalida");
            }
            return rta == 'S';
        }

        private static void GestionarEliminacion()
        {
            var query1 = from soldado 
                     in j1.Soldados 
                     where j2.Soldados.Any(s => s.Posicion == soldado.Posicion) 
                     select soldado;
            if (!query1.Any()) return;
            var query2 = from soldado
                         in j2.Soldados
                         where j1.Soldados.Any(s => s.Posicion == soldado.Posicion)
                         select soldado;
            query1.First().Eliminado = true;
            query2.First().Eliminado = true;
        }
    }
}
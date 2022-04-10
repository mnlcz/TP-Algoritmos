namespace TP1_Algo2_Ro
{
    public class Tablero
    {
        public char[,] TableroDeJuego { get; set; }
        public List<Coordenada> CoordenadasInactivas { get; set; }

        public Tablero()
        {
            TableroDeJuego = new char[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    TableroDeJuego[i, j] = ' ';
            CoordenadasInactivas = new List<Coordenada>();
        }

        public void Mostrar()
        {
            for (int i = 0; i < TableroDeJuego.GetLength(0); i++)
            {
                for (int j = 0; j < TableroDeJuego.GetLength(1); j++)
                    Console.Write("[{0}] ", TableroDeJuego[i, j]);
                Console.WriteLine();
            }
        }

        public ObjetoEnCoordenada QueHayEn(Coordenada c)
        {
            return TableroDeJuego[c.X, c.Y] switch
            {
                'X' => ObjetoEnCoordenada.INACTIVA,
                '1' => ObjetoEnCoordenada.J1,
                '2' => ObjetoEnCoordenada.J2,
                _ => ObjetoEnCoordenada.NADA,
            };
        }

        public void QuitarElementoDe(Coordenada c) => TableroDeJuego[c.X, c.Y] = 'X';

        public void ActualizarContenido(Jugador j1, Jugador j2)
        {
            // Soldados
            for (int i = 0; i < 3; i++)
            {
                var c1 = j1.Soldados.ElementAt(i).Posicion;
                var c2 = j2.Soldados.ElementAt(i).Posicion;
                TableroDeJuego[c1.X, c1.Y] = '1';
                TableroDeJuego[c2.X, c2.Y] = '2';
            }

            // Coordenadas inactivas
            if (CoordenadasInactivas.Count != 0)
            {
                foreach (var c in CoordenadasInactivas)
                {
                    TableroDeJuego[c.X, c.Y] = 'X';
                }
            }
        }
    }
}
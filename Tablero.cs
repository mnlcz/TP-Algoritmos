namespace TP1_Algo2_Ro
{
    public class Tablero
    {
        public char[,] tablero { get; set; }

        public Coordenada[] coordenadasInactivas { get; set; }

        public Tablero()
        {
            tablero = new char[10, 10];
            for(int i = 0; i < 10; i++)
                for(int j = 0; j < 10; j++)
                    tablero[i, j] = ' ';
            coordenadasInactivas = new Coordenada[] {};
        }

        public void Mostrar()
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                    Console.Write("[{0}] ", tablero[i, j]);
                Console.WriteLine();
            }
        }

        public ObjetoEnCoordenada HayAlgoEn(Coordenada c)
        {
            switch(tablero[c.X, c.Y])
            {
                case 'X':
                    return ObjetoEnCoordenada.INACTIVA;
                case '1':
                    return ObjetoEnCoordenada.J1;
                case '2':
                    return ObjetoEnCoordenada.J2;
                default:
                    return ObjetoEnCoordenada.NADA;
            }
        }

        public void QuitarElementoDe(Coordenada c) => tablero[c.X, c.Y] = 'X';
    }
}
namespace TP1_Algo2_Ro
{
    public class Jugador
    {
        public readonly uint Numero;
        public IEnumerable<Soldado> Soldados { get; set; }

        public Jugador(int y1, int y2, int y3, int x, uint nro)   // De esta manera quedan alineados los soldados de cada jugador
        {
            Numero = nro;
            Soldados = new[]
            {
                new Soldado(new Coordenada(x, y1), 1),
                new Soldado(new Coordenada(x, y2), 2),
                new Soldado(new Coordenada(x, y3), 3)
            };
        }

        public Jugador(Soldado[] s, uint nro)
        {
            Soldados = s;
            Numero = nro;
        }

        public Soldado? EncontrarSoldado(Coordenada c)
        {
            foreach (var s in Soldados)
            {
                if (s.Posicion.Equals(c))
                    return s;
            }
            return null;
        }

        public void ActualizarSoldados() => Soldados = from soldado in Soldados where !soldado.Eliminado select soldado;

        public void MostrarSoldados()
        {
            foreach(var s in Soldados)
                Console.WriteLine($"Soldado nro {s.numero} en la posicion {s.Posicion}");
        }

        // Pre: ambos parametros ya validos
        public void MoverSoldado(uint nroSoldado, Coordenada coordenada)
        {
            Soldado s = (from soldado in Soldados where soldado.numero == nroSoldado select soldado).First();
            s.Moverse(coordenada);
        }
    }
}
namespace TP1_Algo2_Ro
{
    public class Jugador
    {
        public IEnumerable<Soldado> Soldados { get; set; }

        public Jugador(int y1, int y2, int y3, int x)   // De esta manera quedan alineados los soldados de cada jugador
        {
            Soldados = new[]
            {
                new Soldado(new Coordenada(x, y1), 1),
                new Soldado(new Coordenada(x, y2), 2),
                new Soldado(new Coordenada(x, y3), 3)
            };
        }

        public Jugador(Soldado[] s) => Soldados = s;

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
    }
}
namespace TP1_Algo2_Ro
{
    public class Jugador
    {
        public IEnumerable<Soldado> soldados { get; set; }

        public Jugador(int y1, int y2, int y3, int x)   // De esta manera quedan alineados los soldados de cada jugador
        {
            soldados = new[] 
            { 
                new Soldado(new Coordenada(x, y1), 1),
                new Soldado(new Coordenada(x, y2), 2), 
                new Soldado(new Coordenada(x, y3), 3) 
            };
        }

        public Soldado? EncontrarSoldado(Coordenada c)
        {
            foreach (var s in soldados)
            {
                if(s.posicion.Equals(c)) 
                    return s;
            }
            return null;
        }

        public void EliminarSoldado(Coordenada c)
        {
            soldados = from soldado in soldados where !soldado.eliminado select soldado;
        }
    }
}
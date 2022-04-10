namespace TP1_Algo2_Ro
{
    public class Soldado
    {
        public readonly uint numero;
        public Coordenada Posicion { get; set; }
        public bool Eliminado { get; set; }

        public Soldado(Coordenada coordenada, uint nro)
        {
            numero = nro;
            Posicion = coordenada;
            Eliminado = false;
        }

        public void Moverse(Coordenada c) => Posicion = c;
    }
}
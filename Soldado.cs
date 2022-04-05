namespace TP1_Algo2_Ro
{
    public class Soldado
    {
        public readonly uint numero;
        public Coordenada posicion { get; set; }
        public bool eliminado { get; set; }

        public Soldado(Coordenada coordenada, uint nro)
        {
            numero = nro;
            posicion = coordenada;
            eliminado = false;
        }

        public void Moverse(Coordenada c) => posicion = c;
    }
}
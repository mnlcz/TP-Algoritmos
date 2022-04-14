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

        // Pre: direccion valida
        public void Moverse(Direccion d)
        {
            switch(d)
            {
                case Direccion.DERECHA: 
                    Posicion = new(Posicion.X, Posicion.Y + 1);
                    break;
                case Direccion.IZQUIERDA:
                    Posicion = new(Posicion.X, Posicion.Y - 1);
                    break;
                case Direccion.ABAJO:
                    Posicion = new(Posicion.X + 1, Posicion.Y);
                    break;
                case Direccion.ARRIBA:
                    Posicion = new(Posicion.X - 1, Posicion.Y);
                    break;
                case Direccion.ABAJO_DERECHA:
                    Posicion = new(Posicion.X + 1, Posicion.Y + 1);
                    break;
                case Direccion.ARRIBA_DERECHA: 
                    Posicion = new(Posicion.X - 1, Posicion.Y + 1);
                    break;
                case Direccion.ABAJO_IZQUIERDA:
                    Posicion = new(Posicion.X + 1, Posicion.Y - 1);
                    break;
                case Direccion.ARRIBA_IZQUIERDA:
                    Posicion = new(Posicion.X - 1, Posicion.Y - 1);
                    break;
            }
        }
    }
}
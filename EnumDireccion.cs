namespace TP1_Algo2_Ro
{
    public enum Direccion
    {
        INVALIDA,
        ARRIBA,
        ABAJO,
        IZQUIERDA,
        DERECHA,
        ARRIBA_DERECHA,
        ARRIBA_IZQUIERDA,
        ABAJO_DERECHA,
        ABAJO_IZQUIERDA
    }

    public static class DireccionExtensions
    {
        public static Direccion Mapear(string input)
        {
            input = input.Trim().ToUpper();
            Direccion d = input switch
            {
                "W" => Direccion.ARRIBA,
                "S" => Direccion.ABAJO,
                "A" => Direccion.IZQUIERDA,
                "D" => Direccion.DERECHA,
                "E" => Direccion.ARRIBA_DERECHA,
                "Q" => Direccion.ARRIBA_IZQUIERDA,
                "C" => Direccion.ABAJO_DERECHA,
                "Z" => Direccion.ABAJO_IZQUIERDA,
                _ => Direccion.INVALIDA
            };
            return d;
        }

        public static void MostrarOpciones()
        {
            var keys = new[] { 'W', 'S', 'A', 'D', 'E', 'Q', 'C', 'Z' };
            var query = from d
                       in Enum.GetValues(typeof(Direccion)).Cast<Direccion>()
                        where d != Direccion.INVALIDA
                        select d;
            for(int i = 0; i < keys.Length; i++)
                Console.WriteLine($"{query.ElementAt(i)} ==> {keys[i]}");
        }

        public static bool MovimientoValido(this Direccion d, Coordenada c)
        {
            switch(d)
            {
                case Direccion.DERECHA:
                    c = new Coordenada(c.X, c.Y + 1);
                    if (c.Y > 9) return false;
                    break;
                case Direccion.IZQUIERDA:
                    c = new Coordenada(c.X, c.Y - 1);
                    if (c.Y < 0) return false;
                    break;
                case Direccion.ABAJO:
                    c = new Coordenada(c.X + 1, c.Y);
                    if(c.X > 9) return false;
                    break;
                case Direccion.ARRIBA:
                    c = new Coordenada(c.X - 1, c.Y);
                    if(c.X < 0) return false;
                    break;
                case Direccion.ABAJO_DERECHA:
                    c = new Coordenada(c.X + 1, c.Y + 1);
                    if (c.Y > 9 || c.X > 9) return false;
                    break;
                case Direccion.ARRIBA_DERECHA:
                    c = new Coordenada(c.X - 1, c.Y + 1);
                    if(c.X < 0 || c.Y > 9) return false;
                    break;
                case Direccion.ABAJO_IZQUIERDA:
                    c = new Coordenada(c.X + 1, c.Y - 1);
                    if (c.Y < 0 || c.X > 9) return false;
                    break;
                case Direccion.ARRIBA_IZQUIERDA:
                    c = new Coordenada(c.X - 1, c.Y - 1);
                    if (c.Y < 0 || c.X < 0) return false;
                    break;
                default: return false;
            }
            return true;
        }
    }
}

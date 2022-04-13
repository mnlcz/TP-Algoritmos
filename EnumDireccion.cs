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
                "Z" => Direccion.ABAJO_DERECHA,
                "C" => Direccion.ABAJO_IZQUIERDA,
                _ => Direccion.INVALIDA
            };
            return d;
        }

        public static void MostrarOpciones()
        {
            var keys = new[] { 'W', 'S', 'A', 'D', 'E', 'Q', 'Z', 'C' };
            var query = from d
                       in Enum.GetValues(typeof(Direccion)).Cast<Direccion>()
                        where d != Direccion.INVALIDA
                        select d;
            for(int i = 0; i < keys.Length; i++)
                Console.WriteLine($"{query.ElementAt(i)} ==> {keys[i]}");
        }
    }
}

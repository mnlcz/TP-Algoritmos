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
                "ARRIBA" => Direccion.ARRIBA,
                "ABAJO" => Direccion.ABAJO,
                "IZQUIERDA" => Direccion.IZQUIERDA,
                "DERECHA" => Direccion.DERECHA,
                "ARRIBA_DERECHA" => Direccion.ARRIBA_DERECHA,
                "ARRIBA_IZQUIERDA" => Direccion.ARRIBA_IZQUIERDA,
                "ABAJO_DERECHA" => Direccion.ABAJO_DERECHA,
                "ABAJO_IZQUIERDA" => Direccion.ABAJO_IZQUIERDA,
                _ => throw new ArgumentException("Input invalido")
            };
            return d;
        }

        public static void MostrarOpciones()
        {
            var query = from d
                       in Enum.GetValues(typeof(Direccion)).Cast<Direccion>()
                        where d != Direccion.INVALIDA
                        select d;
            foreach (var d in query)
                Console.Write($"{d} ");
        }
    }
}

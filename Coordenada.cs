namespace TP1_Algo2_Ro
{
    public record struct Coordenada
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordenada(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool EsValida() => (X < 10 && Y < 10) && (X >= 0 && Y >= 0);

        public override string ToString() => $"X: {X}\tY:{Y}";

        public int Distancia(Coordenada otraCoordenada) => Math.Abs(otraCoordenada.X - X) + Math.Abs(otraCoordenada.Y - Y);
    }
}
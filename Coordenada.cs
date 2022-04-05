using System.Diagnostics.CodeAnalysis;

namespace TP1_Algo2_Ro
{
    public struct Coordenada
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordenada(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            return X == ((Coordenada) obj).X && Y == ((Coordenada) obj).Y;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool EsValida() => (X <= 10 && Y <= 10) && (X >= 0 && Y >= 0);
    }
}
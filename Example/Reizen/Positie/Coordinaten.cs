using System;

namespace Example.Reizen.Positie
{
    public class Coordinaten
    {
        public Coordinaten(long x, long y)
        {
            X = x;
            Y = y;
        }

        public long X { get; }

        public long Y { get; }

        public override bool Equals(object obj)
        {
            var objectToCompare = obj as Coordinaten;
            if (objectToCompare == null)
            {
                return false;
            }

            return this.X == objectToCompare.X && this.Y == objectToCompare.Y;
        }

        public double CalculateDistance(Coordinaten from)
        {
            var x1 = X;
            var x2 = from.X;
            var y1 = Y;
            var y2 = from.Y;

            var xKwadraat = Math.Pow((x1 - x2), 2);
            var yKwadraat = Math.Pow((y1 - y2), 2);

            return Math.Sqrt(xKwadraat + yKwadraat);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class IsIncreasedEventArgs : EventArgs
    {
        private int coefficient;

        public int Coefficient
        {
            get { return coefficient; }
            set { coefficient = value; }
        }

        public IsIncreasedEventArgs(int coefficient)
        {
            Coefficient = coefficient;
        }

    }

    public class Transformer
    {
        public event EventHandler<IsIncreasedEventArgs> IsIncreasedEvent;


        public void Increase()
        {
            IsIncreasedEvent(this, new IsIncreasedEventArgs(Randomizer.Next(2, 6)));
        }
    }

    public abstract class Figure
    {
        public double Side { get; protected set; }

        public Figure(double side)
        {
            Side = side;
        }

        public abstract void IsIncreasedEventHendler(object sender, IsIncreasedEventArgs e);
    }

    public class Triangle : Figure
    {
        public override void IsIncreasedEventHendler(object sender, IsIncreasedEventArgs e)
        {
            Side *= e.Coefficient;

        }

        public Triangle(double side) : base(side)
        {

        }

        public override string ToString()
        {
            return String.Format($"Triangle with side {Side}");
        }
    }

    public class Square : Figure
    {
        public override void IsIncreasedEventHendler(object sender, IsIncreasedEventArgs e)
        {
            Side *= (2.0 * e.Coefficient) / 3.0;

        }

        public Square(double side) : base(side)
        {

        }

        public override string ToString()
        {
            return String.Format($"Square with side {Side:f3}");
        }
    }

    public static class Randomizer
    {
        private static Random rnd = new Random();

        public static int Next(int x, int y)
        {
            return rnd.Next(x, y);
        }
    }
}

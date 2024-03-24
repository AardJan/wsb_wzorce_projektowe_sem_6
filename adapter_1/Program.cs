using System;

namespace AdapterSquare
{
    public interface ITarget
    {
        string GetArea();
    }

    class Square
    {
        public int  ()
        {
            return 3;
        }
    }

    class Adapter : ITarget
    {
        private readonly Square _adaptee;

        public Adapter(Square adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetArea()
        {
            int side = this._adaptee.GetSideLength();
            return $"Area is {side * side}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Square adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine(target.GetArea());
        }
    }
}
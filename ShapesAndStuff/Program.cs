using System;
using System.Collections.Generic;

namespace ShapesAndStuff
{
    class Program
    {
        static void Main(string[] args)
        {



            var shapes = new List<Shape>
            {
                new Square(),
                new Rectangle(),
                new Square(),
                new Ellipse(),
                new Circle()
            };


            var utils = new ShapeUtils();
            foreach (var shape in shapes)
            {
                utils.ScaleShapesIfTheyCan(shape, 1.20F);
            }
        }
    }

    public class ShapeUtils
    {

        public object ObjectFactory(string description)
        {
            switch(description)
            {
                case "square":
                    return new Square();
                case "circle":
                    return new Circle();
                case var x when (x?.Trim().Length ?? 0) == 0:
                    return new Ellipse();
                default:
                    return "No idea. You are on your own";
            }
        }


        public void DoSomethingWithSquared(Square sq)
        {
            switch (sq)
            {
                case Square s when s.Height > 20:
                    Console.WriteLine("That square is tall!");
                    break;
                case Square s when s.Height < 5 && s.Width < 5:
                    Console.WriteLine("That is a teeny square!");
                    break;
                case null:
                    Console.WriteLine("Don't Give That!");
                    break;
                default:
                    return;
            }
        }

        public void ScaleShapesIfTheyCan(Shape s, float p)
        {
            switch (s)
            {
                case ICanScaleHorizontally sh:
                    sh.ScalePercentage(p);
                    return;
                case ICanScaleVertically sh:
                    sh.ScalePercentage(p);
                    return;
                case ICanScale sh:
                    sh.ScalePercentage(p);
                    break;
                default:
                    return;
            }
        }

        public void DoSomething(Shape s)
        {
            Console.WriteLine(s.Description);
            if (s is ICanScaleHorizontally)
            {
                ICanScaleHorizontally ptr = (ICanScaleHorizontally)s;
                ptr.ScalePercentage(1.1F);

                //((ICanScaleHorizontally)s).ScalePercentage(1.1F);
            }

            var sh = s as ICanScaleHorizontally;
            if (sh != null)
            {
                // sh is a hugger/
            }


        }
    }
}

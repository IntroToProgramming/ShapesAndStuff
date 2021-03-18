using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesAndStuff
{
    public interface ICanScaleHorizontally
    {
        public void ScalePercentage(float percentage);
    }
    public interface ICanScaleVertically
    {
        public void ScalePercentage(float percentage);
    }
    public interface ICanScale
    {
        public void ScalePercentage(float percentage);
    }
    public abstract class Shape
    {
        public string Description { get; protected set; } = "No Description set";

    }

    public class Square : Shape, ICanScale
    {
        public Square()
        {
            Description = "I am a square!";
        }
        public float Width { get; set; }
        public float Height { get; set; }

        public void ScalePercentage(float percentage)
        {
            Console.WriteLine("Scaling the square in ALL directions");
        }
    }
    public class Rectangle : Shape, ICanScale, ICanScaleHorizontally, ICanScaleVertically
    {
        public Rectangle()
        {
            Description = "I'm a rectangle!";
        }

        void ICanScale.ScalePercentage(float percentage)
        {
            Console.WriteLine("Scaling the Rectagle In All Directions");
        }

        void ICanScaleHorizontally.ScalePercentage(float percentage)
        {
            Console.WriteLine("Scaling the Rectagle Horizontally");
        }

        void ICanScaleVertically.ScalePercentage(float percentage)
        {
            Console.WriteLine("Scaling the Rectagle Vertically");
        }
    }
    public class Circle : Shape
    {
    }
    public class Ellipse : Shape
    {

    }
}

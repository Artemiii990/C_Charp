using System;
using System.Security.Cryptography.X509Certificates;

namespace abstract_file

{
    public class Square
    {
        public static void Main(string[] args)
        {
            Figure rectangle = new rectangle();
            rectangle.count_squares();
            Figure circle = new circle();
            circle.count_squares();
            Figure triangle = new triangle();
            triangle.count_squares();
            Figure trapezium = new trapezium();
            trapezium.count_squares();
        }
    }

    abstract class Figure
    {
        public abstract void count_squares();
    }


    class rectangle:Figure
    {
        public override void count_squares()
        {
            Console.WriteLine("square of rectangle = a*b");
        }
        
    }
    
    class circle:Figure
    {
        public override void count_squares()
        {
            Console.WriteLine("square of circle = Пr2");
        }
        
    }
    
    class triangle:Figure
    {
        public override void count_squares()
        {
            Console.WriteLine("square of triangle = (a · h)/2");
        }
        
    }
    
    class trapezium:Figure
    {
        public override void count_squares()
        {
            Console.WriteLine("square of trapezium = 1/2(a + b)h");
        }
        
    }
}
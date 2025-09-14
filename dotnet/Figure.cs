using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace Figures
{
    interface IPrint
    {
        public void Print();
    };

    abstract class Figure
    {
        public abstract double Area();
    };

    class Rectangle : Figure, IPrint
    {
        private double width = 0;
        public double Width
        {
            get { return this.width; }
            set { width = value; }
        }
        private double height = 0;
        public double Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public Rectangle(int w = 0, int h = 0)
        {
            this.width = w;
            this.height = h;
        }
        public override double Area()
        {
            return this.width * this.height;
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"w = {this.width}; h = {this.height}; area: {Math.Round(this.Area(), 2)}";
        }
        void IPrint.Print()
        {
            Console.WriteLine($"Прямоугльник: {this.ToString()}");
        }
    }

    class Square : Rectangle, IPrint
    {
        private double sideSize = 0;
        public double Side
        {
            get { return this.sideSize; }
            set { this.sideSize = value; }
        }
        public Square(int a = 0)
        {
            this.sideSize = a;
        }

        public override double Area()
        {
            return this.sideSize * this.sideSize;
        }

        public override string ToString()
        {
            return $"side = {this.sideSize}; area: {Math.Round(this.Area(), 2)}";
        }

        void IPrint.Print()
        {
            Console.WriteLine($"Квадрат: {this.ToString()}");
        }
    }

    class Circle : Figure, IPrint
    {
        private double radius = 0;
        public double Radius
        {
            get { return this.radius; }
            set { this.radius = value; }
        }

        public Circle(double r = 0)
        {
            this.radius = r;
        }

        public override double Area()
        {
            return Math.PI * this.radius * this.radius;
        }

        public override string ToString()
        {
            return $"r = {this.radius}; area: {Math.Round(this.Area(), 2)}";
        }
        void IPrint.Print()
        {
            Console.WriteLine($"Круг: {this.ToString()}");
        }
    }
} // Figures

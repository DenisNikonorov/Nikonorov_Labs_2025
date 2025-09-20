using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Figures
{
    class Program
    {
        static void Main(string[] argv)
        {
            // проверка работы конструкторов
            Rectangle rect1 = new Rectangle(10, 10);
            Square square1 = new Square(5);
            Circle circle1 = new Circle(2);

            // проверка метода ToString() для каждой ранее созданной фигуры
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("проверка метода ToString для каждой ранее созданной фигуры");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"rect1: {rect1}\nsquare1: {square1.ToString()}\ncircle1: {circle1.ToString()}");

            // проверка интерфейса IPrint на примере круга
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nПроверка интерфейса IPrint на примере круга");
            Console.ForegroundColor = ConsoleColor.White;
            IPrint circle2 = new Circle(4);
            circle2.Print();
        }
    }
} // Figures

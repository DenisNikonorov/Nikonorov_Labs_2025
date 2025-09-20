using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Figures
{
    class Program
    {
        static void Main(string[] argv)
        {
            //------- Создание объектов геометрических фигур
            Circle circle1 = new Circle(5);
            Circle circle2 = new Circle(155);
            Circle circle3 = new Circle(25);

            Rectangle rect = new Rectangle(10, 20);

            ArrayList al = new ArrayList();

            al.Add(circle1);
            al.Add(circle2);
            al.Add(circle3);
            al.Add(rect);

            al.Sort();

            // Console.WriteLine(circle1.Type); //===== Circle
            // Console.WriteLine(al[0].Type);   //===== Object doen not contain def of Type

            // foreach (var x in al) Console.WriteLine(x.type);
            // Console.WriteLine("\n");

            // al.Sort();

            // foreach (var x in al) Console.WriteLine(x);

            // Console.WriteLine(circle1.CompareTo(rect));
        }
    }
} // Figures

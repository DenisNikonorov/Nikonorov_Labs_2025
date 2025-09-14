using System;
using System.Collections.Generic;

namespace BiquadrateRoots
{
    class BiquadrateRoots
    {
        public double GetCoef(string[] args, int ind, string prompt)
        {
            try
            {
                double coef = Convert.ToDouble(args[ind]);
                return coef;
            }
            catch
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(prompt);
                    var input = Console.ReadLine();
                    double coef;
                    bool isNumber = double.TryParse(input, out coef);
                    if (isNumber)
                    {
                        return coef;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы ввели некорректное значение, попробуйте еще раз!");
                    }
                }
            }
        }

        public void CalculateRoots(double a, double b, double c, out List<double> roots, out int count)
        {
            count = 0;
            roots = new List<double>();

            double D = b * b - 4 * a * c;
            double t1 = (-b + Math.Sqrt(D)) / (2 * a);
            double t2 = (-b - Math.Sqrt(D)) / (2 * a);

            List<double> squareRoots = [];
            squareRoots.Add(t1);
            squareRoots.Add(t2);

            for (int i = 0; i < squareRoots.Count; ++i)
            {
                if (squareRoots[i] == 0)
                {
                    count++;
                    roots.Add(0);
                }
                else if (squareRoots[i] > 0)
                {
                    count += 2;
                    double root1 = Math.Sqrt(squareRoots[i]);
                    double root2 = -Math.Sqrt(squareRoots[i]);
                    roots.Add(root1);
                    roots.Add(root2);
                }
            }
        }

        public void PrintRoots(double a, double b, double c)
        {
            List<double> roots;
            int count;
            this.CalculateRoots(a, b, c, out roots, out count);

            if (count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет действительных корней!");
            }
            else if (count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Корни уравнения успешно найдены:");
                for (int i = 0; i < roots.Count; ++i)
                {
                    Console.WriteLine($"x{i + 1} = {roots[i]}");
                }
            }
        }
    }


} // BiquadrateRoots

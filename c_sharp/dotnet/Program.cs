using System;
using System.Collections.Generic;

namespace BiquadrateRoots
{
    class Program
    {
        static int Main(string[] args)
        {
            BiquadrateRoots result = new BiquadrateRoots();

            double a = result.GetCoef(args, 0, "Введите A: ");
            double b = result.GetCoef(args, 1, "Введите B: ");
            double c = result.GetCoef(args, 2, "Введите C: ");

            result.PrintRoots(a, b, c);

            return 0;
        }
    }
}

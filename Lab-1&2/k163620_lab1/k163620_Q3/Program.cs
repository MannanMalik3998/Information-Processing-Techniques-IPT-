using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k163620_Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            calculator calc = new calculator();
            float[] a = { 1, 2, 3 };
            Console.WriteLine(calc.Add(1, 2, a));
            Console.WriteLine(calc.Add(1, 2));
            Console.WriteLine(calc.Sub(2, 1));
            Console.WriteLine(calc.Mul(2, 2));
            Console.ReadKey();
        }
    }
}

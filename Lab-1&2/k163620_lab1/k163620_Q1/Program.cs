using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k163620_Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter A string:  ");
            String str = Console.ReadLine();
            //String str = "MANANMaLiK";
            Console.WriteLine(str);

            if (str.Length == 0) Console.WriteLine("String Empty");

            //main logic
            if (str.Length >= 4)
            {
                string firstFour = str.Substring(0, 4);
                firstFour = firstFour.ToLower();
                //Console.WriteLine(str);
                //Console.WriteLine(firstFour);

                string Rem = str.Substring(4, (str.Length - firstFour.Length));
                Rem = Rem.ToUpper();

                Console.WriteLine(firstFour + Rem);
                Console.ReadKey();
            }

            else { Console.WriteLine("String less than 4 characters long: {0}", str); Console.ReadKey(); }
        }
    }
}

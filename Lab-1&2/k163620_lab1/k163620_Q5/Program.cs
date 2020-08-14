using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k163620_Q5
{
    class Program
    {
        public static bool CompareObjects(object name, object name2) {
            return name.Equals(name2);
        }
        static void Main(string[] args)
        {
            string string1 = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });
            string string2 = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });

            Console.WriteLine(string1);
            Console.WriteLine(string2);

            Console.WriteLine(CompareObjects(string1, string2));

            Console.ReadKey();
        }
    }
}

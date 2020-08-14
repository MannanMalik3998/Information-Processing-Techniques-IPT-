using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace k163620_Q1
{
    class Program
    {
        public static int[] intArray = new int[1000000];

        
        public static void Find(object obj)
        {
         //   Console.WriteLine("Here");
            newClass o = (newClass)obj;
            int search = 3;
            for (int i = o.start; i < o.stop; i++)
            {
                if (intArray[i] == search) Console.Write(i + " ");
            }
        }

  

        static void Main(string[] args)
        {
            Random random = new Random();
            Stopwatch time;


            #region 1) generating random values
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = random.Next(0, 50);
            }
            #endregion

            #region 2)Comparison of Search


            //Without Threading
            time = Stopwatch.StartNew();
            //Find(intArray,0, intArray.Length-1);
            Find(new newClass(0, intArray.Length - 1));
            time.Stop();

            double t1 = time.Elapsed.TotalMilliseconds;
            //Console.WriteLine("\n************************************************************************************\nTime taken to search for all occurrences without threading: {0}ms", time.Elapsed.TotalMilliseconds);
            Console.WriteLine("\n\n\n\n\n\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n\n\n\n\n");

            
            time = Stopwatch.StartNew();

            ParameterizedThreadStart param1 = new ParameterizedThreadStart(Find);
            Thread th1 = new Thread(param1);
            Thread th2 = new Thread(param1);
            Thread th3 = new Thread(param1);
            Thread th4 = new Thread(param1);
            Thread th5 = new Thread(param1);
            th1.Start(new newClass(0, 200000 - 1));
            th2.Start(new newClass(200000, 400000 - 1));
            th3.Start(new newClass(400000, 600000-1));
            th4.Start(new newClass(600000, 800000 - 1));
            th5.Start(new newClass(800000, 1000000 - 1));
            th1.Join();
            th2.Join();
            th3.Join();
            th4.Join();
            th5.Join();

            time.Stop();


            Console.WriteLine("\n\n\n************************************************************************************************\n\n\n\n\n\nTime taken to search for all occurrences\nA)With threading: {0}ms\n2)Without threading {1}ms", time.Elapsed.TotalMilliseconds,t1);
            Console.WriteLine("\n\n______________________________________________________________________________________________");

            #endregion

            Console.ReadKey();

        }

        class newClass {
            public int start;
            public int stop;
            public newClass(int strt,int stp) {
                start = strt;
                stop = stp;
            }
        }
    }
}

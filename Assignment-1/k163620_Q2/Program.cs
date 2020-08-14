using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace k163620_Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            try{

                string file = File.ReadAllText(@"GS.txt");//read file
                String[] f = file.Split(',');//split on commas

                byte[] grids = new byte[24];//byte array

                int act = 0, inact=0;//active and non active grid station count
                
                //finding out the active grid stations and storing in array
                for (int i = 0; i <= 24; i++) {
                    //Console.WriteLine(f[i]);
                    if (f[i].Contains("Active")) {
                        act++;
                        //Console.WriteLine(i);//i is representing grid number
                        grids[i] = 1;
                    }
                }

                //grids[] contains the grid stations status
                for (int i = 0; i <= 24; i++){
                    if (grids[i] == 1) {
                        Console.WriteLine("Grid: "+i+" is active");
                    }
                }
                /*
                inact = 24 - act;
                Console.WriteLine("Total active grid stations:"+act);
                Console.WriteLine("Total inactive grid stations:"+ inact);
                */
                Console.ReadKey();

            }
            catch{
                //Console.WriteLine("FileNotFound");
                Console.ReadKey();

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k163620_Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assumption of a square matrix
            Console.Write("Enter size of matrix:    ");

            int sizeMatrix = Convert.ToInt32(Console.ReadLine());
            //int sizeMatrix = 2;
            Console.WriteLine(sizeMatrix);

            Random random = new Random();

            //initialize
            int[,] matrix = new int[sizeMatrix, sizeMatrix];


            //Populate Matrix
            for (int i = 0; i < sizeMatrix; i++)
            {
                for (int j = 0; j < sizeMatrix; j++)
                {
                    matrix[i, j] = random.Next(1, 15);
                }
            }

            //Display Matrix
            for (int i = 0; i < sizeMatrix; i++)
            {
                for (int j = 0; j < sizeMatrix; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int sum = 0;
            for (int i = 0; i < sizeMatrix; i++)
            {
                for (int j = 0; j < sizeMatrix; j++)
                {
                    if (i == j)
                    {
                        sum += matrix[i, j];
                    }


                    //Console.Write(matrix[i, j] + "\t");
                }

            }
            Console.WriteLine("Sum of diagonal: {0}", sum);
            Console.ReadKey();


        }
    }
}

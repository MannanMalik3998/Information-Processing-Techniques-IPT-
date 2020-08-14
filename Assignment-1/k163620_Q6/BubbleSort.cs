using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k163620_Q6
{
    class BubbleSort
    {
        public unsafe void Sort(int[] arr)
        {
            fixed (int* ptr = arr)
            {
                int size = arr.Length;

                for (int i = 0; i < size - 1; i++)
                {
                    for (int j = 0; j < size - i - 1; j++)
                    {
                        if (*(ptr + j) > *(ptr + j + 1))
                        {
                            int temp = *(ptr + j);
                            *(ptr + j) = *(ptr + j + 1);
                            *(ptr + j + 1) = temp;
                        }
                    }
                }

            }
        }
    }
}

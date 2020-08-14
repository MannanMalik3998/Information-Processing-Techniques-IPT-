using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace k163620_Q3
{
    class Program
    {
        
        public static int BinarySearchIterative(ArrayList arr, int val){
            int min = 0, max = arr.Count - 1, mid=0;
           // Console.WriteLine("arr.count"+ max);
            
            while (min <= max){
                mid = (min + max) / 2;
                //Console.WriteLine("arr[mid]"+ arr[mid]);

                if (val == Convert.ToInt32(arr[mid])){
                    return mid;
                }
                else if (val < Convert.ToInt32(arr[mid]))
                {
                    max = mid - 1;
                }
                else{
                    min = mid + 1;
                }
            }
            return 0;
        }
        
        public static int BinarySearchIterative(List<int> arr, int val)
        {
            int min = 0, max = arr.Count - 1, mid = 0;
           // Console.WriteLine("arrList.count"+ max);

            while (min <= max)
            {
                mid = (min + max) / 2;
                //Console.WriteLine("arrList[mid]" + arr[mid]);
                //Console.WriteLine("arrList[mid] conve"+Convert.ToInt32(arr[mid]));

                if (val == Convert.ToInt32(arr[mid]))
                {
                    return mid;
                }
                else if (val < Convert.ToInt32(arr[mid]))
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return 0;
        }
        
        static void Main(string[] args)
        {
            //initializations
            Random random = new Random();
            Stopwatch time;

            int[] intArray = new int[2000000] ;
            ArrayList arrList = new ArrayList();
            List<int> intList = new List<int>();
            int a = 0, sum = 0;
            int []values = new int[5];


            #region 1) generating random values
            for (int i=0;i<2000000;i++) {
                //Console.WriteLine(random.Next(0, 1000));
                a = random.Next(0, 1000);
                intArray[i] = a;
                arrList.Add(a);
                intList.Add(a);
                if (i < 5) { values[i] = a; } else { continue; }
            }
            #endregion

            #region 2)Comparison of Sum
            time = Stopwatch.StartNew();     
            foreach (int i in intArray){
                sum += i;
            }
            time.Stop();
            Console.WriteLine("Time taken by integer Array: {0}ms and Sum:{1}", time.Elapsed.TotalMilliseconds,sum);
            //Console.WriteLine(sum);
            sum = 0;
            time = Stopwatch.StartNew();
            foreach (int i in arrList){
                sum += i;
            }
            Console.WriteLine("Time taken by ArrayList: {0}ms and Sum:{1}", time.Elapsed.TotalMilliseconds, sum);
            //Console.WriteLine(sum);
            sum = 0;
            foreach (int i in intList){
                sum += i;
            }
            time = Stopwatch.StartNew();
            Console.WriteLine("Time taken by List<int>: {0}ms and Sum:{1}", time.Elapsed.TotalMilliseconds, sum);
            //Console.WriteLine(sum);

            #endregion

            #region 3)Binary Search on ArrayList and List<int>

            //binary search requires sorted input
            arrList.Sort();
            intList.Sort();

            Console.WriteLine("Index of 5 values in ArrayList:");
            time = Stopwatch.StartNew();
            foreach (int i in values)
            {
                Console.WriteLine((BinarySearchIterative(arrList, i)));
            }
            time.Stop();
            Console.WriteLine("Time taken by ArrayList during binary search: {0}ms", time.Elapsed.TotalMilliseconds);

            time = Stopwatch.StartNew();
            Console.WriteLine("Index of 5 values in List<int>:");
            foreach (int i in values)
            {
                Console.WriteLine((BinarySearchIterative(intList, i)));
            }
            time.Stop();
            Console.WriteLine("Time taken by List<int> during binary search: {0}ms", time.Elapsed.TotalMilliseconds);


            #endregion

            Console.ReadKey();

        }
    }
}

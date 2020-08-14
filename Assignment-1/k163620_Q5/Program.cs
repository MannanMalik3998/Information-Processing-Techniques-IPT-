using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k163620_Q5
{
    sealed class DynamicList<T> : IList<T>
    {

        private int count = 0;
        private T[] var = new T[20];

        public int Count
        {
            get { return count; }
        }


        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (var[i].Equals(item)) { return i; }//index
            }
            return -1;//not found
        }

        public void Insert(int index, T item)
        {
            if (index == var.Length - 1 && count == var.Length - 1) { Add(item); return; }//last element
            if (count != var.Length - 1 && index == var.Length - 1) { Console.WriteLine("Invalid"); return; }
            if (index == var.Length || index > var.Length)
            {
                Console.WriteLine("Index Out Of Bound");
                return;
            }
            if (index < var.Length - 1)
            {
                if (count == var.Length)
                {//If List full
                    //Console.WriteLine("Here");
                    T[] temp1 = new T[var.Length];
                    for (int i = 0; i < count; i++)
                    {
                        temp1[i] = var[i];
                    }
                    var = new T[var.Length * 2];
                    for (int i = 0; i < index; i++)
                    {
                        var[i] = temp1[i];
                        //Console.WriteLine(var[i]);
                    }
                    var[index] = item;
                    count++;
                    for (int i = index + 1; i < count; i++)
                    {
                        var[i] = temp1[i - 1];
                        //Console.WriteLine(var[i]);
                    }
                    return;
                }
                //Console.WriteLine("Here");

                T[] temp = new T[var.Length];
                for (int i = 0; i < count; i++)
                {
                    temp[i] = var[i];
                }
                for (int i = 0; i < index; i++)
                {
                    var[i] = temp[i];
                    //Console.WriteLine(var[i]);
                }
                var[index] = item;
                count++;
                for (int i = index + 1; i < count; i++)
                {
                    var[i] = temp[i - 1];
                    //Console.WriteLine(var[i]);
                }
                return;
            }


        }

        public void Add(T item)
        {
            if (count == var.Length)
            {
                //length reached
                append(var);
                var[count++] = item;
            }
            else var[count++] = item;
        }

        public void append(T[] item)
        {
            T[] temp = new T[var.Length];
            for (int i = 0; i < count; i++)
            {
                temp[i] = var[i];
            }
            var = new T[var.Length * 2];
            for (int i = 0; i < count; i++)
            {
                var[i] = temp[i];
                //Console.WriteLine(var[i]);
            }
        }
        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (var[i].Equals(item)) { return true; }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            int ind = IndexOf(item);
            if (ind == -1) { return false; }//item not found
            RemoveAt(ind);
            return true;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < count - 1; i++)
            {
                var[i] = var[i + 1];
            }
            //var[count - 1] ;
            count--;
        }

        public void Clear()
        {
            //values will be overwritten
            count = 0;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void DisplayAll()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(var[i]);
            }
        }

        public int at(int index)
        {
            return Convert.ToInt32(var[index]);
        }

        public bool find(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (var[i].Equals(item)) { return true; }
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            DynamicList<int> IList = new DynamicList<int>();
            //initializations
            Random random = new Random();
            Stopwatch time;

            int[] intArray = new int[2000000];
            ArrayList arrList = new ArrayList();
            List<int> intList = new List<int>();
            int a = 0, sum = 0;
            int[] values = new int[5];

            #region 1) generating random values
            for (int i = 0; i < 2000000; i++)
            {
                //Console.WriteLine(random.Next(0, 1000));
                a = random.Next(0, 1000);
                intArray[i] = a;
                arrList.Add(a);
                intList.Add(a);
                IList.Add(a);
                //if (i < 5) { values[i] = a; } else { continue; }
            }
            #endregion

            #region 2)Comparison of Sum
            time = Stopwatch.StartNew();
            foreach (int i in intArray)
            {
                sum += i;
            }
            time.Stop();
            Console.WriteLine("Time taken by integer Array: {0}ms and Sum:{1}", time.Elapsed.TotalMilliseconds, sum);
            //Console.WriteLine(sum);
            sum = 0;
            time = Stopwatch.StartNew();
            foreach (int i in arrList)
            {
                sum += i;
            }
            Console.WriteLine("Time taken by ArrayList: {0}ms and Sum:{1}", time.Elapsed.TotalMilliseconds, sum);
            //Console.WriteLine(sum);
            sum = 0;
            foreach(int i in intList)
            {
                sum += i;
            }
            time = Stopwatch.StartNew();
            Console.WriteLine("Time taken by List<int>: {0}ms and Sum:{1}", time.Elapsed.TotalMilliseconds, sum);
            //Console.WriteLine(sum);
            sum = 0;
            time = Stopwatch.StartNew();
            for (int i = 0; i < 2000000; i++)
            {
                sum += IList.at(i);
            }
            time.Stop();
            Console.WriteLine("Time taken by Dynamic List: {0}ms and Sum:{1}", time.Elapsed.TotalMilliseconds, sum);

            #endregion

            #region 3)Binary Search on ArrayList and List<int>

            Console.WriteLine("Random 5 values: ");
            int num = 0;
            while (true){
                if (num == 5) { break; }
                //Console.WriteLine(random.Next(0, 1000));
                a = random.Next(0, 1000);
                if (arrList.Contains(a)) {
                    values[num++] = a;
                    Console.WriteLine(a);
                }
                else { continue; }
            }
            //binary search requires sorted input
            //arrList.Sort();
            //intList.Sort();


            Console.WriteLine("Index of 5 values in ArrayList:");
            time = Stopwatch.StartNew();
            foreach (int i in values)
            {
                Console.WriteLine((arrList.IndexOf(i)));
            }
            time.Stop();
            Console.WriteLine("Time taken by ArrayList to find 5 values: {0}ms", time.Elapsed.TotalMilliseconds);

            time = Stopwatch.StartNew();
            Console.WriteLine("Index of 5 values in List<int>:");
            foreach (int i in values)
            {
                Console.WriteLine((intList.IndexOf(i)));
            }
            time.Stop();
            Console.WriteLine("Time taken by List<int> to find 5 values: {0}ms", time.Elapsed.TotalMilliseconds);

            //Console.WriteLine("Index of 5 values in DynamicList:");
            time = Stopwatch.StartNew();
            Console.WriteLine("Index of 5 values in DynamicList:");
            foreach (int i in values)
            {
                Console.WriteLine((IList.IndexOf(i)));
            }
            time.Stop();
            Console.WriteLine("Time taken by DynamicList to find 5 values: {0}ms", time.Elapsed.TotalMilliseconds);
            #endregion

            Console.ReadKey();

        }
    }
}

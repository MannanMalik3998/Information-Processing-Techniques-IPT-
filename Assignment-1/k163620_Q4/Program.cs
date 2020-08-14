using System;
using System.Collections;
using System.Collections.Generic;

namespace k163620_Q4
{
    sealed class DynamicList<T>:IList<T>{

        private int count=0;
        private T[] var = new T[20];

        public int Count {
            get { return count; }        
        }

        
        public bool IsReadOnly {
            get {
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
            if (index == var.Length - 1 && count==var.Length-1) { Add(item); return; }//last element
            if (count != var.Length - 1 && index == var.Length - 1 ) { Console.WriteLine("Invalid");return; }
            if (index == var.Length || index > var.Length){
                Console.WriteLine("Index Out Of Bound");
                return;
            }
            if (index < var.Length-1) {
                if (count == var.Length) {//If List full
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
                    for (int i = index+1; i < count; i++)
                    {
                        var[i] = temp1[i-1];
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
            if (count == var.Length) {
                //length reached
                append(var);
                var[count++] = item;
            }
            else var[count++] = item;
        }

        public void append(T[] item) {
            T[] temp = new T[var.Length];
            for (int i = 0; i < count; i++){
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
            for (int i = index; i < count-1; i++)
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
            for (int i = 0; i < count; i++){
                Console.WriteLine(var[i]);
            }
        }

        public bool find(T item) {
            for (int i = 0; i < count; i++){
                if (var[i].Equals(item)) { return true; }
            }
            return false;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            DynamicList<int> array = new DynamicList<int>();
            array.Add(1);
            array.Add(3);
            array.Add(4);
            Console.WriteLine("Before Insert(1,2) operation");
            array.DisplayAll();
            array.Insert(1, 2);
            Console.WriteLine("After Insert(1,2) operation");

            array.DisplayAll();

            array.Remove(3);
            Console.WriteLine("Remove operation");
            array.DisplayAll();


            Console.WriteLine("Find operation:  "+array.find(6));

            DynamicList<String> sarray = new DynamicList<String>();
            sarray.Add("D1");
            sarray.Add("D2");
            sarray.Add("D3");
            sarray.DisplayAll();
            Console.WriteLine("IndexOf method on D4: "+sarray.IndexOf("D4"));
            Console.WriteLine("IndexOf method on D2: "+sarray.IndexOf("D2"));
            Console.WriteLine("Contains method on D2: "+sarray.Contains("D2"));
            Console.WriteLine("Find method on D2: "+sarray.find("D2"));


            Console.ReadKey();
        }
    }
}

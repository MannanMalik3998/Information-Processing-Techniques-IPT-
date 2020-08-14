using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k163620_Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student();
            st1._gpa = 2;st1._name = "Dummy1";st1._dob = "10.01.1998"; st1._sem = 3;

            Student st2 = new Student();
            st2._gpa = 3.02; st2._name = "Dummy2"; st2._dob = "11.10.1997"; st2._sem = 2;

            Student st3 = new Student();
            st3._gpa = 2.51; st3._name = "Dummy3"; st3._dob = "1.11.1998"; st3._sem = 5;

            Student st4 = new Student();
            st4._gpa = 3.22; st4._name = "Dummy4"; st4._dob = "10.01.2000"; st4._sem = 7;

            

            List < Student > students = new List<Student>();

            students.Add(st1);
            students.Add(st2);
            students.Add(st3);
            students.Add(st4);

            Console.WriteLine("BeforeSort:");
            foreach (var i in students)
            {
                Console.WriteLine(i);
            }


            students.Sort();
            Console.WriteLine("AfterSort:");
            foreach (var i in students)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();

        }
    }
}

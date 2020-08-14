using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k163620_Q4
{
    class Student : IComparable<Student>
    {
        String name;
        double gpa;
        String dob;
        int sem;
        public int _sem
        {
            get
            {
                return this.sem;
            }
            set
            {
                this.sem = value;
            }
        }
        public string _name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public double _gpa
        {
            get
            {
                return this.gpa;
            }
            set
            {
                this.gpa = value;
            }
        }
        public string _dob
        {
            get
            {
                return this.dob;
            }
            set
            {
                this.dob = value;
            }
        }

        public int CompareTo(Student other)
        {
            return other.gpa.CompareTo(this.gpa);
        }

        public override string ToString()
        {
            return this.name + ": " + this.gpa.ToString();
        }
    }
}

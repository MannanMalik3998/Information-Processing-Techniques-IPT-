using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k163620_Q3
{
    class calculator
    {
        public float Add(float n1, float n2) { return n1 + n2; }
        public float Sub(float n1, float n2) { return n1 - n2; }
        public float Mul(float n1, float n2) { return n1 * n2; }
        public float Div(float n1, float n2) { return n1 / n2; }
        public float Add(float n1, float n2, float[] n3)
        {
            float sum = n1 + n2;
            foreach (float i in n3)
            {
                sum += i;
            }
            return sum;
        }
    }
}

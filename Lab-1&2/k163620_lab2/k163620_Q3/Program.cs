using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace k163620_Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            try {

                var myAssembly = Assembly.LoadFrom("E:\\Sem7\\IPT\\Lab\\k163620_lab2\\k163620_Q3\\EntityFramework.dll");
                var myAssemblyTypes = myAssembly.GetTypes();
                
                var firstType = myAssemblyTypes[0];
                var firstTypeMethods = firstType.GetMethods();
                var firstTypeFirstMethod = firstTypeMethods[0];
                
                int count = 0;
                foreach (var i in myAssemblyTypes)
                {
                    var m = i.GetMethods();
                    count += m.Length;
                    //Console.WriteLine(i.Name);
                    foreach (var fun in m)
                    {
                        Console.WriteLine(fun.Name);
                    }
                }

                Console.WriteLine("Total Methods:{0}",count);
                Console.ReadKey();
                

            }
            catch (Exception e) {
                Console.WriteLine(e);

                Console.WriteLine(e.Message);

                Console.ReadKey();
            }


        }
    }
}


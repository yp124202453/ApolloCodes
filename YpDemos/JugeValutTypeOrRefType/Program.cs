using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JugeValutTypeOrRefType
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t1 = typeof(int);
            if (t1.IsValueType)
            {
                Console.WriteLine("{0} is ValueType", t1.FullName);
            }
            else
            {
                Console.WriteLine("{0} is refference type", t1.FullName);
            }

            Type t2 = typeof(ValueType);
            if (t2.IsValueType)
            {
                Console.WriteLine("{0} is ValueType", t2.FullName);
            }
            else
            {
                Console.WriteLine("{0} is refference type", t2.FullName);
            }

            Console.WriteLine("press any key to exit......");
            Console.ReadKey();
        }
    }
}

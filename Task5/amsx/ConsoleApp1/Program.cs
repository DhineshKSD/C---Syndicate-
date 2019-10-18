using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           localhost.WebService1 obj = new localhost.WebService1();
            int value1 = Convert.ToInt32(Console.ReadLine());

            int value2 = Convert.ToInt32(Console.ReadLine());

            string result = obj.Addition(value1, value2);

            Console.WriteLine(result);

            Console.ReadKey();

        }
    }
}

using Chapter06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter6
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            //6-1-1
            Console.WriteLine($"最大値{numbers.Max()}");

            //6-1-2
            int pos = numbers.Length - 2;
            
            foreach (var number in numbers.Skip(pos))
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            //6-1-3
            var strNums = numbers.Select(n => n.ToString());
            foreach(var str in strNums)
            {
                Console.WriteLine(str + " ");
            }

            //6-1-4
            foreach(var number in numbers.OrderBy(n => n).Take(3))
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            //6-1-5
            Console.WriteLine(numbers.Distinct().Count(n => n > 10));


        }
    }
}

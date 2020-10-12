using Section01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeDict = new Dictionary<int, Employee>
            {
                {100,new Employee(100,"清水遼久") },
                {112,new Employee(112,"芹沢洋和") },
                {125,new Employee(125,"岩瀬奈央子") },
            };

            var employees = employeeDict.Where(emp => emp.Value.Id % 2 == 0);
            foreach(var item in employees)
            {
                Console.WriteLine($"{item.Value.Name}");
            }
        }
    }
}

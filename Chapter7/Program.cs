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
            var flowerDict = new Dictionary<string, int>()
            {
                ["sunflower"] = 400,
                ["pansy"] = 300,
                ["tulip"] = 350,
                ["rose"] = 500,
                ["dahlia"] = 450,
            };

            flowerDict["violet"] = 600;
            //flowerDict.Add("violet", 600);

            foreach(var item in flowerDict)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            //4-2-1
            var ymCollection = new YearMonth[]
            {
                new YearMonth (2000,1),
                new YearMonth (2001,2),
                new YearMonth (2002,3),
                new YearMonth (2003,4),
                new YearMonth (2004,5),
            };

            //4-2-2
            foreach(var ym in ymCollection)
            {
                Console.WriteLine(ym);
            }
        }

        //4-2-3
        static YearMonth FindFirst21C(YearMonth[] yms)
        {
            foreach(var ym in yms)
            {
                if (ym.Is21Century)
                    return ym;
            }
            return null;
        }

        //4-2-4
        private static void Exercise2_4(YearMonth[] ymCollection)
        {
            if(FindFirst21C(ymCollection) == null)
            {
                Console.WriteLine("21世紀のデータはありません");
            }
            else
            {
                Console.WriteLine(FindFirst21C(ymCollection));
            }
        }

        //4-2-5
        private static void Exercise2_5(YearMonth[] ymCollection)
        {
            var array = ymCollection.Select(ym => ym.AddOneMonth()).ToArray();
            foreach(var ym in array)
            {
                Console.WriteLine(ym);
            }
        }
    }
}

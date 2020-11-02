using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Chapter5
{
    class Program
    {
        static void Main(string[] args)
        {
            //5-1
            Console.Write("文字列1:");
            string s1 = Console.ReadLine();
            Console.Write("文字列2:");
            string s2 = Console.ReadLine();
            if (string.Compare(s1, s2, true) == 0)
            {
                Console.WriteLine("等しい");
            }
            else
            {
                Console.WriteLine("等しくない");
            }

            //5-2
            Console.Write("数値文字列:");
            var line = Console.ReadLine();
            int num;
            if(int.TryParse(line,out num))
            {
                Console.WriteLine($"{num:#,#}");
            }
            else
            {
                Console.WriteLine("数値文字列ではありません");
            }

            //5-3-1
            string text = "Jackdaws love my big sphinx of quartz";
            var count1 = text.Count(s => s == ' ');
            //Console.WriteLine($"空白数:{0}",count );

            //5-3-2
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);

            //5-3-3
            var count2 = text.Split(' ').Count();
            Console.WriteLine($"単語数{0}", count2);

            //5-3-4
            text.Split(' ').Where(s => s.Length <= 4).ToList().ForEach(Console.WriteLine);

            //5-3-5
            var array = text.Split(' ').ToArray();
            if(array.Length > 0)
            {
                var sb = new StringBuilder(array[0]);
                foreach(var word in array.Skip(1))
                {
                    sb.Append(' ');
                    sb.Append(word);
                }
                Console.WriteLine(sb);
            }

            //5-4
            var words = line.Split(';');
            foreach(var item in words)
            {
                var word = item.Split('=');
                Console.WriteLine("{0}:{1}", ToJapanese(array[0]), array[1]);
            }
        }
        static string ToJapanese(string key)
        {
            switch (key)
            {
                case "Novelist":
                    return "作家";
                case "BestWork":
                    return "代表作";
                case "Born":
                    return "誕生年";
                default:
                    return "    ";
            }
        }
    }
}

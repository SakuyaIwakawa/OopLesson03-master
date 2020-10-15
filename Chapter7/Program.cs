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
            Console.WriteLine("*****辞書登録プログラム*****");

            var dict = new Dictionary<string, List<string>>();
            //{
            // {"PC", new List<string>{"パーソナル　コンピュータ","プログラム　カウンタ",} },
            // {"CD", new List<string>{"コンパクト　ディスク","キャッシュ　ディスペンサー"} }
            //};

            for (int i = 0; i < 100; i++)
            {
            Console.WriteLine("1.登録 2.内容を表示 3.終了");
            int n = int.Parse(Console.ReadLine());
                if (n == 1)
                {
                    Console.Write("KEYを入力:");
                    string key = Console.ReadLine();
                    Console.Write("VALUEを入力:");
                    string value = Console.ReadLine();
                    Console.WriteLine("登録しました");

                    if (dict.ContainsKey(key))
                    {
                        dict[key].Add(value);
                    }
                    else
                    {
                        dict[key] = new List<string> { value };

                        foreach(var item in dict)
                        {
                            foreach(var term in dict)
                            {
                                Console.WriteLine("{0}:{1}", item.Key, term);
                            }
                        }
                    }
                }
                i = 500;
            }
        }
    }
}

using Chapter06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 9, 7, -5, 4, 2, 5, 4, 2, -4, 8, -1, 6, 4 };
            Console.WriteLine($"平均値：{numbers.Average()}");
            Console.WriteLine($"合計値{numbers.Sum()}");
            Console.WriteLine($"最小値{numbers.Where(n => n > 0).Min()}");
            Console.WriteLine($"最大値{numbers.Max()}");

            bool exists = numbers.Any(n => n % 7 == 0);



            var books = Books.GetBooks();
            Console.WriteLine($"本の平均価格：{books.Average(x => x.Price)}");
            Console.WriteLine($"本の合計価格：{books.Sum(x => x.Price)}");
            Console.WriteLine($"本のページが最大：{books.Max(x => x.Pages)}");
            Console.WriteLine($"高価な本：{books.Max(x => x.Price)}");
            Console.WriteLine($"タイトルに「物語」が入っている作品：{books.Where(x => x.Title.Contains("物語"))}");

            Console.WriteLine("600ページを超える作品は");
            Console.WriteLine(books.Any(x => x.Pages >= 600) ? "ある" : "ない");

            Console.WriteLine("すべて200ページ以上の作品であるか");
            Console.WriteLine(books.All(x => x.Pages >= 200) ? "ある" : "ない");

            var book = books.FirstOrDefault(x => x.Pages > 400);
            int i;
            for(i = 0; i < books.Count; i++)
            {
                if (books[i].Title.Contains(book.Title))
                {
                    break;
                }
            }
            Console.WriteLine($"400ページを超える本は{book}冊目です");

            var count = books.FindIndex(x => x.Pages > 400);
            Console.WriteLine($"400ページを超える本は{count + 1}冊目です");

        }
    }
}

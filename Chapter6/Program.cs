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
            var numbers = new List<int> { 19, 17, 15, 24, 12, 25, 14, 20, 12, 28, 19, 30, 24 };

            var strings = numbers.Select(n => n.ToString("0000")).ToArray();

            foreach(var str in strings)
            {
                Console.Write(str + " ");
            }

            var sortedNumbers = numbers.OrderBy(n => n);
            foreach(var nums in sortedNumbers)
            {
                Console.WriteLine(nums + " ");
            }

            var words = new List<string>
            {
                "Microsoft","Apple","Google","Oracle","Facebook"
            };

            var lower = words.Select(name => name.ToLower()).ToArray();

            var books = Books.GetBooks();

            var titles = books.Select(name => name.Title);
            foreach(var title in titles)
            {
                Console.Write(title + " ");
            }

            var sortedBooks = books.OrderBy(book => book.Pages).Take(3);
            foreach (var book in sortedBooks)
            {
                Console.WriteLine(book.Title + " " + book.Pages);
            }
        }
    }
}

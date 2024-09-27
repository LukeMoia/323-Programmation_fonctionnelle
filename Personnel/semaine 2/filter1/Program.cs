using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filter1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "wwwwwwww","eeee","aaaaaa" };

            var result = words.Where(word => !word.Contains("x")).Where(word => word.Length > 4).Where(word => (words.Sum(w => w.Length) / words.Length) == word.Length).ToList();

            result.ForEach(r => Console.WriteLine(r));

            /*foreach (var word in result)
            {
                Console.WriteLine(word);
            }*/
            Console.ReadLine();
        }
    }
}

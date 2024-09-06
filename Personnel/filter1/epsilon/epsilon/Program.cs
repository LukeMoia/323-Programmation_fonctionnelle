using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epsilon
{
    internal class Program
    {
        static Dictionary<char, double> alphabet = new Dictionary<char, double>() {
            { 'a', 8.15 }, {'b', 0.97 }, { 'c', 3.15 }, {'d', 3.73 }, { 'e', 17.39 }, {'f', 1.12 }, { 'g', 0.97 }, {'h', 0.85 },
            { 'i', 7.31 }, {'j', 0.45 }, { 'k', 0.02 }, {'l', 5.69 }, { 'm', 12.87 }, {'n', 7.12 }, { 'o', 5.28 }, {'p', 2.80 },
            { 'q', 1.21 }, {'r', 6.64 }, { 's', 8.14 }, {'t', 7.22 }, { 'u', 6.38 }, {'v', 1.64 }, { 'x', 0.03 }, {'y', 0.28 }, {'z', 0.15 }
        };
        static void Main(string[] args)
        {
            string[] words = { "bonjour", "aba" };

            // words.ToList().ForEach(w => w.ToHashSet().ToList().ForEach(c => result += ((alphabet[c] / 100) / w.Where(a => a == c).Sum(_ => 1))));

            /*words.ToList().ForEach(w => {
                double d = 0;
                w.ToHashSet().ToList().ForEach(c =>
                {
                    d += ((alphabet[c] / 100) / w.Where(a => a == c).Sum(_ => 1));
                });
                Console.WriteLine($"La réponse de {w} est {d}");
            });*/

            words.ToList().ForEach(w => Console.WriteLine($"La réponse de {w} est {w.ToHashSet().Select(c => ((alphabet[c] / 100) / w.Where(a => a == c).Sum(_ => 1))).Sum()}"));

            Console.ReadLine();

            /*Console.Write("Saisissez votre phrase : ");
            string saisi = Console.ReadLine();

            // epsilon 
            double result = 0;
            saisi.ToHashSet().ToList().ForEach(x => result += ((alphabet[x] / 100) / saisi.Where(a => a == x).Sum(_ => 1)));

            Console.WriteLine($"La réponse est {result}");
            Console.ReadLine();*/
        }

        /*static double epsilon(string word)
        {
            double letterpercent = 0;

            word.ToHashSet().ToList().ForEach(x => letterpercent += ((alphabet[x] / 100) / word.Where(a => a == x).Sum(_ => 1)));

            return letterpercent;
        }*/
    }
}

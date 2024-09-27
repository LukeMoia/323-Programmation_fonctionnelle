using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immutable1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player a = new Player( "Joe", 32);
            // 4 players
            var players = ImmutableList.Create(new Player("Joe", 32),
                new Player("Jack", 30),
                new Player("William", 37),
                new Player("Averell", 25));

            // Initialize search (Sauvé par readonly dans la classe)
            Player elder = GetPlayerOlder(players);

            Console.WriteLine($"Le plus agé est {elder.Name} qui a {elder.Age} ans");
            // Sinon
            // Console.WriteLine($"Le plus agé est {GetPlayerOlder(players).Name} qui a {GetPlayerOlder(players).Age} ans");

            Console.ReadKey();
        }

        static Player GetPlayerOlder(ImmutableList<Player> p)
        {
            Player elder = new Player("", 0);

            // search
            foreach (Player pla in p)
            {
                if (pla.Age > elder.Age) // memorize new elder
                {
                    elder = new Player(pla.Name, pla.Age);
                }
            }
            return elder;
        }
    }
    public class Player
    {
        // Me sauve la vie (readonly) Immutable
        private readonly string _name;
        private readonly int _age;

        public Player(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public string Name => _name;

        public int Age => _age;
    }
}

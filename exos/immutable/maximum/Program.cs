using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maximum
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            // 4 players

            //var immuPlayers = new List<Player>()
            //{
            // new Player("Joe", 32),
            // new Player("Jack", 30),
            // new Player("William", 37),
            // new Player("Averell", 25)
            //}.ToImmutableList();

            var players = ImmutableList.Create(
                new Player("Joe", 32),
                new Player("Jack", 30),
                new Player("William", 37),
                new Player("Averell", 25)
            );

            players = players.Add(new Player("bob", 5));
            Console.WriteLine(players.Count);

            Player x = FindOlder(players);
            Console.WriteLine(x.Name);



        // Initialize search
           

            //string elderName = elder.Name;
            //int elderAge = new int {  elder.Age };
       
            //Console.WriteLine($"Le plus agé est {elder.Name} qui a {elder.Age} ans");

            Console.ReadKey();
        }

        static Player FindOlder(IEnumerable<Player> players)
        {

            Player elder = players.First();
            //int biggestAge = elder.Age;

            // search
            for (int i = 0; i < players.Count(); i++)
            {
                Player p = players.ElementAt(i);
                if (p.Age > elder.Age) // memorize new elder
                {
                    elder = p;
                    elder = new Player(p.Name, p.Age);
                    //biggestAge = p.Age; // for future loops
                }
            }
            return elder;
        }





        public class Player
        {
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
}


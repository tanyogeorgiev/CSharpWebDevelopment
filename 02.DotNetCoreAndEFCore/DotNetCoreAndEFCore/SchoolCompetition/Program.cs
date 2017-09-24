using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            var cat = new Dictionary<string, SortedSet<string>>();
            var results = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split();
                string player = tokens[0];
                string category = tokens[1];
                int result = int.Parse(tokens[2]);

                if (!cat.ContainsKey(player))
                {
                    cat.Add(player, new SortedSet<string>());

                }

                cat[player].Add(category);
                if (!results.ContainsKey(player))
                {
                    results.Add(player, result);
                }
                else
                {
                    results[player] += result;
                }

                input = Console.ReadLine();

            }

            var ordered = results.OrderByDescending(p => p.Value).ThenBy(b => b.Key);

            foreach (var player in ordered)
            {
                string listCat = string.Join(", ", cat[player.Key]);
                Console.WriteLine($"{player.Key}: {player.Value} [{listCat}]");

            }

        }
    }

}
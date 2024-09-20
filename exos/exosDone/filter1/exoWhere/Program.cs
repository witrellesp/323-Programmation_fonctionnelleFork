using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exoWhere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "aba", "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune" };
            string[] wordFilter = words.Where(w => !w.Contains('x')).ToArray();
            //foreach (string word in wordFilter) { Console.WriteLine(word); }
            string[] wordFilter4 = words.Where(w => w.Length >= 4).ToArray();
            //foreach (string word in wordFilter4) { Console.WriteLine(word); }
            string[] wordFilterAverage = words.Where(word => word.Count() == Math.Round(words.Average(w => w.Length))).ToArray();
            //foreach (string word in wordFilterAverage) { Console.WriteLine(word); }



            var letterPercent = new Dictionary<char, double>
           {
                { 'A', 8.15 },
                { 'B', 0.97 },
                { 'C', 3.15 },
                { 'D', 3.73 },
                { 'E', 7.39 },
                { 'F', 1.12 },
                { 'G', 0.97 },
                { 'H', 0.85 },
                { 'I', 7.31 },
                { 'J', 0.45 },
                { 'K', 0.02 },
                { 'L', 5.69 },
                { 'M', 2.87 },
                { 'N', 7.12 },
                { 'O', 5.28 },
                { 'P', 2.80 },
                { 'Q', 1.21 },
                { 'R', 6.64 },
                { 'S', 8.14 },
                { 'T', 7.22 },
                { 'U', 6.38 },
                { 'V', 1.64 },
                { 'W', 0.03 },
                { 'X', 0.41 },
                { 'Y', 0.28 },
                { 'Z', 0.15 }
           };

            double processLetter(char letter, int count)
            {
                

                if (letterPercent.ContainsKey(letter))
                {
                    return letterPercent[letter]/10/count;
                }
                return 0.0;
            }


            Func<string, double> EpsilonProce = word =>
            {
                word = word.ToUpper();
                double epsilon = 0.0;
                var letterCount = new Dictionary<char, int>();


                //for (int i = 0; i < word.Length; i++)
                //{
                //    if (letterPercent.ContainsKey(word[i]))
                //    {
                //        //epsilon =letterPercent[word[i]] + epsilon;
                //        epsilon = processLetter(word[i], i) + epsilon;
                //    }
                //}
                for (int i = 0; i < word.Length; i++)
                {
                    char letter = word[i];
                    if (letterCount.ContainsKey(letter))
                    {
                        letterCount[letter]++;
                    }
                    else
                    {
                        letterCount[letter] = 1;
                    }
                }

                foreach (var kvp in letterCount)
                {
                    char letter = kvp.Key;
                    int count = kvp.Value;
                    epsilon += processLetter(letter, count);
                }

                return epsilon;
            };




            words.Where(word => EpsilonProce(word) > 0.5 && EpsilonProce(word) < 0.95)
                .ToList()
                .ForEach(word => Console.WriteLine(word));




   

            Console.WriteLine();
            Console.ReadLine();

        }

    }

}

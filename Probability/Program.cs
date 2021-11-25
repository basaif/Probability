using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probability
{
    class Program
    {
        static void Main(string[] args)
        {
            int wins = 0, losses = 0, total = 10000000;

            int rando = WeightedRandomNumber(new List<int>{ 50, 10, 20 });

            Console.WriteLine(rando);

            Random random = new Random();
            for(int i = 0; i < total; i++)
            {
                int sum = 0;
                for(int j = 0; j < 3; j++)
                {
                    sum += random.Next(1, 5);

                }
                if (sum >= 10)
                {
                    wins += 1;
                }
                else
                {
                    losses += 1;
                }
            }

            double probabilityOfWinning = wins / (double)total;

            Console.WriteLine($"Wins: {wins}");
            Console.WriteLine($"Losses: {losses}");
            Console.WriteLine($"Probability of winning: {probabilityOfWinning}");

            Console.ReadLine();
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static int WeightedRandomNumber(List<int> Weights)
        {
            int output = 0;

            int totalFrequencies = AddIntsInList(Weights);

            int random = RandomNumber(0, totalFrequencies);
            List<(int, int)> ranges = GetRangesOfNumbers(Weights);

            int position = 0;
            foreach (var range in ranges)
            {
                if (random <= range.Item1 && random >= range.Item2)
                {
                    output = position;
                    break;
                }

                position++;
            }

            return output;
        }

        private static int AddIntsInList(List<int> list)
        {
            int output = 0;

            foreach (var num in list)
            {
                output += num;
            }

            return output;
        }

        public static List<(int, int)> GetRangesOfNumbers(List<int> numbers)
        {
            List<(int, int)> ranges = new List<(int, int)>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == 0)
                {
                    ranges.Add((0, numbers[i] - 1));
                }
                else
                {
                    ranges.Add((ranges[i - 1].Item2 + 1, ranges[i - 1].Item2 + numbers[i]));
                }
            }

            return ranges;
        }
    }
}

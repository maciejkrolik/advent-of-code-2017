using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    class Day2
    {
        public static void PartOne()
        {
            using (var streamReader = File.OpenText("../../Days/Day2/input.txt"))
            {
                string[] lines = streamReader.ReadToEnd().Split("\r\n".ToArray(), StringSplitOptions.RemoveEmptyEntries);

                int sum = 0;

                foreach (var line in lines)
                {
                    string[] tokens = line.Split();
                    int[] numbers = Array.ConvertAll(tokens, int.Parse);

                    int maxValue = numbers[0], minValue = numbers[0];

                    foreach (int number in numbers)
                    {
                        if (number > maxValue)
                            maxValue = number;
                        if (number < minValue)
                            minValue = number;
                    }
                    sum += maxValue - minValue;
                }
                Console.WriteLine(sum);
            }
        }

        public static void PartTwo()
        {
            using (var streamReader = File.OpenText("../../Days/Day2/input.txt"))
            {
                string[] lines = streamReader.ReadToEnd().Split("\r\n".ToArray(), StringSplitOptions.RemoveEmptyEntries);

                int sum = 0;

                foreach (var line in lines)
                {
                    string[] tokens = line.Split();
                    int[] numbers = Array.ConvertAll(tokens, int.Parse);

                    int quotient = 0;

                    foreach (int number in numbers)
                    {
                        foreach (int otherNumber in numbers)
                        {
                            if (otherNumber != number)
                            {
                                if (number % otherNumber == 0)
                                {
                                    quotient = number / otherNumber;
                                }
                            }
                        }
                    }
                    sum += quotient;
                }
                Console.WriteLine(sum);
            }
        }
    }
}

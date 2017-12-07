using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    class Day3
    {
        const int input = 289326;

        public static void PartOne()
        {
            int firstSteps = 0;
            int secondSteps = 0;

            int nearestOddNumber = (int)Math.Ceiling(Math.Sqrt(input));
            while (nearestOddNumber % 2 == 0)
                nearestOddNumber++;

            firstSteps = CalculateFirstSteps(firstSteps, nearestOddNumber);
            secondSteps = CalculateSecondSteps(nearestOddNumber, firstSteps);

            Console.WriteLine(firstSteps + secondSteps);
        }

        private static int CalculateFirstSteps(int firstSteps, int nearestOddNumber)
        {
            int counter = 0;
            for (int i = 0; i <= nearestOddNumber; i++)
            {
                if (i % 2 != 0)
                {
                    counter++;
                    if (i == nearestOddNumber)
                    {
                        firstSteps = counter - 1;
                        break;
                    }
                }
            }

            return firstSteps;
        }

        private static int CalculateSecondSteps(int nearestOddNumber, int firstSteps)
        {
            if (nearestOddNumber != 1)
            {
                int squaredNearestOddNumberMinusTwo = (int)Math.Pow(nearestOddNumber - 2, 2);

                List<int> listOfMiddleElements = new List<int>();
                listOfMiddleElements.Add(squaredNearestOddNumberMinusTwo + firstSteps);
                listOfMiddleElements.Add(listOfMiddleElements[0] + nearestOddNumber - 1);
                listOfMiddleElements.Add(listOfMiddleElements[1] + nearestOddNumber - 1);
                listOfMiddleElements.Add(listOfMiddleElements[2] + nearestOddNumber - 1);

                int minDifference = nearestOddNumber;
                foreach (int middleElement in listOfMiddleElements)
                {
                    if (Math.Abs(input - middleElement) < minDifference)
                        minDifference = Math.Abs(input - middleElement);
                }

                return minDifference;
            }
            else
            {
                return 0;
            }
        }
    }
}

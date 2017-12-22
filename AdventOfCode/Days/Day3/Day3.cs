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

        //  PART TWO

        static int sqrt = (int)Math.Sqrt(input);
        static int mid_x = sqrt / 2;
        static int mid_y = mid_x;

        static int[,] tab = new int[sqrt, sqrt];   // Creating a two dimensional array

        public static void PartTwo()
        {
            tab[mid_x, mid_y] = 1;    // Assigning first element
            int wsk_x = mid_x;
            int wsk_y = mid_y;

            int lastNumber = 0;
            int numberOfElements = 1;
            int series = 1;
            int oddNumber = 3;

            Console.WriteLine(tab[wsk_x, wsk_y]);

            while (lastNumber < input)
            {
                int squaredOddNumber = oddNumber * oddNumber;
                while (numberOfElements != squaredOddNumber)
                {
                    // First turn into right and for loop through right elements except upper right
                    wsk_x++;
                    SumElementsAroundPoint(wsk_x, wsk_y);
                    Console.WriteLine(tab[wsk_x, wsk_y]);
                    numberOfElements++;
                    for (int i = 0; i < oddNumber - 3; i++)
                    {
                        wsk_y++;
                        SumElementsAroundPoint(wsk_x, wsk_y);
                        Console.WriteLine(tab[wsk_x, wsk_y]);
                        numberOfElements++;
                    }

                    // Second turn up and for loop through up elements
                    wsk_y++;
                    for (int i = (mid_x + series); i >= (mid_x - series); i--)
                    {
                        wsk_x = i;
                        SumElementsAroundPoint(wsk_x, wsk_y);
                        Console.WriteLine(tab[wsk_x, wsk_y]);
                        numberOfElements++;
                    }

                    // Third turn down in a loop
                    for (int i = 0; i < oddNumber - 2; i++)
                    {
                        wsk_y--;
                        SumElementsAroundPoint(wsk_x, wsk_y);
                        Console.WriteLine(tab[wsk_x, wsk_y]);
                        numberOfElements++;
                    }

                    // Fourth turn right in a loop
                    wsk_y--;
                    for (int i = (mid_x - series); i <= (mid_x + series); i++)
                    {
                        wsk_x = i;
                        SumElementsAroundPoint(wsk_x, wsk_y);
                        Console.WriteLine(tab[wsk_x, wsk_y]);
                        numberOfElements++;
                    }
                }

                lastNumber = tab[wsk_x, wsk_y];
                oddNumber += 2;
                series++;
            }
        }

        private static void SumElementsAroundPoint(int x, int y)
        {
            Dictionary<string, int> dict = GetCoordinates(x, y);
            tab[x, y] = tab[dict["rr_x"], dict["rr_y"]] + tab[dict["ll_x"], dict["ll_y"]] + tab[dict["uu_x"], dict["uu_y"]] + tab[dict["dd_x"], dict["dd_y"]] +
                                tab[dict["ur_x"], dict["ur_y"]] + tab[dict["ul_x"], dict["ul_y"]] + tab[dict["dl_x"], dict["dl_y"]] + tab[dict["dr_x"], dict["dr_y"]];
        }

        private static Dictionary<string, int> GetCoordinates(int mid_x, int mid_y)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            /* l - left
             * r - right
             * u - up
             * d - down
             */

            dict.Add("rr_x", mid_x + 1);
            dict.Add("rr_y", mid_y);

            dict.Add("ll_x", mid_x - 1);
            dict.Add("ll_y", mid_y);

            dict.Add("uu_x", mid_x);
            dict.Add("uu_y", mid_y + 1);

            dict.Add("dd_x", mid_x);
            dict.Add("dd_y", mid_y - 1);

            dict.Add("ur_x", mid_x + 1);
            dict.Add("ur_y", mid_y + 1);

            dict.Add("ul_x", mid_x - 1);
            dict.Add("ul_y", mid_y + 1);

            dict.Add("dl_x", mid_x - 1);
            dict.Add("dl_y", mid_y - 1);

            dict.Add("dr_x", mid_x + 1);
            dict.Add("dr_y", mid_y - 1);

            return dict;
        }
    }
}

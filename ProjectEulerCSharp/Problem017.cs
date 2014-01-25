using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(17, Title = "How many letters would be needed to write all the numbers in words from 1 to 1000?")]
    public class Problem17
    {
        public long Solve()
        {
            // Create a lookup table for each word that could be used
            long answer = 0;
            Dictionary<int, string> numberTable = new Dictionary<int, string>();
            numberTable.Add(0, "");
            numberTable.Add(1, "one");
            numberTable.Add(2, "two");
            numberTable.Add(3, "three");
            numberTable.Add(4, "four");
            numberTable.Add(5, "five");
            numberTable.Add(6, "six");
            numberTable.Add(7, "seven");
            numberTable.Add(8, "eight");
            numberTable.Add(9, "nine");
            numberTable.Add(10, "ten");
            numberTable.Add(11, "eleven");
            numberTable.Add(12, "twelve");
            numberTable.Add(13, "thirteen");
            numberTable.Add(14, "fourteen");
            numberTable.Add(15, "fifteen");
            numberTable.Add(16, "sixteen");
            numberTable.Add(17, "seventeen");
            numberTable.Add(18, "eighteen");
            numberTable.Add(19, "nineteen");
            numberTable.Add(20, "twenty");
            numberTable.Add(30, "thirty");
            numberTable.Add(40, "forty");
            numberTable.Add(50, "fifty");
            numberTable.Add(60, "sixty");
            numberTable.Add(70, "seventy");
            numberTable.Add(80, "eighty");
            numberTable.Add(90, "ninety");
            numberTable.Add(100, "hundred");

            // Iterate through each number building the string representation and then taking
            // the number of digits, summing the result
            for (int i = 1; i <= 1000; i++)
            {
                string number = String.Empty;

                if (i <= 20)
                {
                    number = numberTable[i];
                }
                else if (i < 100)
                {
                    number = numberTable[i - (i % 10)] + numberTable[i % 10];
                }
                else if (i < 1000)
                {
                    if (i % 100 == 0)
                    {
                        number = numberTable[i / 100] + "hundred";
                    }
                    else if ((i % 100) < 20)
                    {
                        number = numberTable[i / 100] + "hundred" + "and" + numberTable[i % 100];
                    }
                    else
                    {
                        number = numberTable[i / 100] + "hundred" + "and" +
                            numberTable[(i % 100) - ((i % 100) % 10)] + numberTable[(i % 100) % 10];
                    }
                }
                else //one thousand
                {
                    number = "one" + "thousand";
                }

                answer += number.Trim().Length;
            }

            return answer;
        }
    }
}
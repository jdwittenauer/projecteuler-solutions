using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(23, Title = "Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.")]
    public class Problem23
    {
        public long Solve()
        {
            // Create a list of all numbers in range that are abundant numbers
            const int max = 28123;
            List<int> abundantNumberList = new List<int>();
            for (int i = 1; i <= max; i++)
            {
                if (Numeric.IsAbundant(i))
                {
                    abundantNumberList.Add(i);
                }
            }
            
            // Create a boolean array and mark each number that can be represented as true
            bool[] canBeRepresented = new bool[max + 1];
            for (int i = 0; i < abundantNumberList.Count(); i++)
            {
                for (int j = 0; j < abundantNumberList.Count(); j++)
                {
                    if (abundantNumberList[i] + abundantNumberList[j] <= max)
                    {
                        canBeRepresented[abundantNumberList[i] + abundantNumberList[j]] = true;
                    }
                }
            }

            // If the number being tested cannot be represented, add it to the total
            int sum = 0;
            for (int i = 1; i <= max; i++)
            {
                if (!canBeRepresented[i])
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
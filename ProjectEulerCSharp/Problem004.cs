using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(4, Title="Find the largest palindrome made from the product of two 3-digit numbers.")]
    public class Problem004
    {
        public long Solve()
        {
            // Loop through each number 1 to 999 to create every possible product of 3-digit numbers
            // and test each one, taking the largest palindrome
            long answer = 0;
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 100; j < 1000; j++)
                {
                    long n = i * j;
                    if (n.IsPalindromic() && n > answer)
                    {
                        answer = n;
                    }
                }
            }
            return answer;
        }
    }
}

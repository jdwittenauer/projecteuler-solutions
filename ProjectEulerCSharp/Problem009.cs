using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(9, Title = "Find the only Pythagorean triplet, {a, b, c}, for which a + b + c = 1000.")]
    public class Problem009
    {
        public long Solve()
        {
            // Loop through all integers 1 to 500 creating every possible triplet and testing for the
            // sum of the numbers to equal 1000, returning the result if true
            for (int a = 1; a < 500; a++)
            {
                for (int b = 1; b < 500; b++)
                {
                    if ((a * a) + (b * b) == (1000 - a - b) * (1000 - a - b))
                    {
                        return a * b * (1000 - a - b);
                    }
                }
            }
            return 0;
        }
    }
}

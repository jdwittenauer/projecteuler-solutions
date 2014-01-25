using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(12, Title = "What is the value of the first triangle number to have over five hundred divisors?")]
    public class Problem012
    {
        public long Solve()
        {
            // Use a triangle number generator, testing each number for its total number of
            // factors until we find one with over 500
            return Numeric.TriangleNumbers().Where(x => x.NumberOfFactors() > 500).First();
        }
    }
}

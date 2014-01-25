using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(2, Title = "Find the sum of all the even-valued terms in the Fibonacci sequence which do not exceed four million.")]
    public class Problem002
    {
        public long Solve()
        {
            // Use a fibonacci number generator to take new terms up to 4 million, then filter based
            // on remainder and sum the result
            return Numeric.FibonacciTerms(1, 2).TakeWhile(x => x <= 4000000).Where(y => y % 2 == 0).Sum();
        }
    }
}

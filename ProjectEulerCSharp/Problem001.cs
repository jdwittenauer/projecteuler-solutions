using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(1, Title = "Add all the natural numbers below one thousand that are multiples of 3 or 5.")]
    public class Problem001
    {
        public long Solve()
        {
            // For each number up to 999, filter based on remainders and sum the result
            return Enumerable.Range(1, 999).Where(x => x % 3 == 0 || x % 5 == 0).Sum();
        }
    }
}

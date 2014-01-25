using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(5, Title = "What is the smallest number divisible by each of the numbers 1 to 20?")]
    public class Problem005
    {
        public long Solve()
        {
            // Apply a fold over each number 1 to 20, taking the least common multiple of each number
            // and the result from the previous calculation
            return Enumerable.Range(1, 20).Aggregate((product, factor) => product.LeastCommonMultiple(factor));
        }
    }
}

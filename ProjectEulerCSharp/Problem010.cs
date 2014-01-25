using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(10, Title = "Calculate the sum of all the primes below two million.")]
    public class Problem010
    {
        public long Solve()
        {
            // Use a prime number generator to take all primes below 2 million and sum the result
            return Numeric.PrimeNumbers().TakeWhile(x => x < 2000000).Sum();
        }
    }
}

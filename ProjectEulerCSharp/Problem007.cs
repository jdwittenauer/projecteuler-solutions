using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(7, Title = "Find the 10001st prime.")]
    public class Problem007
    {
        public long Solve()
        {
            // Use a prime number generator to pull primes until the 10001st prime is reached
            return Numeric.PrimeNumbers().Skip(10000).First();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(3, Title = "Find the largest prime factor of a composite number.")]
    public class Problem003
    {
        public long Solve()
        {
            // First we factor the given number into it's prime factors, creating a list
            // of objects (of type PrimeFactor) to iterate through
            long number = 600851475143, max = 0;
            IList<PrimeFactor> primeFactors = number.PrimeFactors();

            // Now iterate through the prime factors and take the largest
            foreach (PrimeFactor item in primeFactors)
            {
                if (item.Value > max)
                {
                    max = item.Value;
                }
            }

            return max;
        }
    }
}

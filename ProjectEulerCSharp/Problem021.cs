using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(21, Title = "Evaluate the sum of all amicable pairs under 10000.")]
    public class Problem21
    {
        public long Solve()
        {
            // Apply a filter to all number 1 to 9999 testing for amicibility and
            // sum the resulting numbers
            return Enumerable.Range(1, 9999).Where(x => Numeric.IsAmicable(x)).Sum();
        }
    }
}
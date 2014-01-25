using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(16, Title = "What is the sum of the digits of the number 2^1000?")]
    public class Problem016
    {
        public long Solve()
        {
            // Calculate the number, convert to array of digits and sum the result
            return new {Power = 1, Digits = (IEnumerable<int>) new int[] {2}}
                .Unfold((previous) => new {Power = previous.Power + 1, Digits = Numeric.SumNumbers
                    (previous.Digits, previous.Digits)})
                .SkipWhile(item => item.Power < 1000).First().Digits.Sum();
        }
    }
}

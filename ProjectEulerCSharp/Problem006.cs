using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(6, Title = "What is the difference between the sum of the squares and the square of the sums?")]
    public class Problem006
    {
        public long Solve()
        {
            // Calculate the sum of the suares and compare to the square of the sums
            int sumOfNumbers = Enumerable.Range(1, 100).Sum();
            int squareOfSum = sumOfNumbers * sumOfNumbers;
            int sumOfSquares = Enumerable.Range(1, 100).Select(x => x * x).Sum();
            return squareOfSum - sumOfNumbers;
        }
    }
}

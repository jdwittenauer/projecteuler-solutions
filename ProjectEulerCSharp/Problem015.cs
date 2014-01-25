using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(15, Title = "Starting in the top left corner in a 20 by 20 grid, how many routes are there to the bottom right corner?")]
    public class Problem015
    {
        public long Solve()
        {
            // The problem boils down to a Pascal's Triangle problem - use a function that constructs
            // the triangle by computing the number of possible paths as it goes and returns the result
            return Numeric.GetPascalsTriangleEntry(2*20, 20);
        }
    }
}

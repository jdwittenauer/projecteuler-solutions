using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(18, Title = "Find the maximum sum travelling from the top of the triangle to the base.")]
    public class Problem18
    {
        public long Solve()
        {
            // Build the triangle as an array of arrays of numbers
            long max = 0;
            long[][] pyramid = new long[15][];
            pyramid[0] = new long[] { 75 };
            pyramid[1] = new long[] { 95, 64 };
            pyramid[2] = new long[] { 17, 47, 82 };
            pyramid[3] = new long[] { 18, 35, 87, 10 };
            pyramid[4] = new long[] { 20, 04, 82, 47, 65 };
            pyramid[5] = new long[] { 19, 01, 23, 75, 03, 34 };
            pyramid[6] = new long[] { 88, 02, 77, 73, 07, 63, 67 };
            pyramid[7] = new long[] { 99, 65, 04, 28, 06, 16, 70, 92 };
            pyramid[8] = new long[] { 41, 41, 26, 56, 83, 40, 80, 70, 33 };
            pyramid[9] = new long[] { 41, 48, 72, 33, 47, 32, 37, 16, 94, 29 };
            pyramid[10] = new long[] { 53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14 };
            pyramid[11] = new long[] { 70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57 };
            pyramid[12] = new long[] { 91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48 };
            pyramid[13] = new long[] { 63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31 };
            pyramid[14] = new long[] { 04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23 };

            // Travel to each node in the pyramid
            for (int i = 1; i < pyramid.Length; i++)
            {
                for (int j = 0; j < pyramid[i].Length; j++)
                {
                    // Accumulate the maximum total
                    if (j == 0)
                    {
                        pyramid[i][j] += pyramid[i - 1][j];
                    }
                    else if (j == pyramid[i].Length - 1)
                    {
                        pyramid[i][j] += pyramid[i - 1][pyramid[i - 1].Length - 1];
                    }
                    else
                    {
                        pyramid[i][j] += Math.Max(pyramid[i - 1][j], pyramid[i - 1][j - 1]);
                    }
                    // Find the maximum from the last row
                    if (i == (pyramid.Length - 1))
                    {
                        if (pyramid[i][j] > max)
                        {
                            max = pyramid[i][j];
                        }
                    }
                }
            }

            return max;
        }
    }
}
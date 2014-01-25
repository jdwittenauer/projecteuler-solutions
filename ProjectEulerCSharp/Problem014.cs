using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ProjectEulerCSharp
{
    [EulerProblem(14, Title = "Find the longest sequence using a starting number under one million.")]
    public class Problem014
    {
        public long Solve()
        {
            int maxNumber = 0, maxSequenceLength = 0, i = 0;

            // Loop through the numbers we need to try
            for (i = 500001; i <= 1000000; i+=2)
            {
                long number = i;
                int sequenceLength = 1;

                // Keep applying the rules until the number reaches 1 (end of sequence)
                while (number != 1)
                {
                    sequenceLength++;

                    // If the current sequence length exceeds the highest found so far, then
                    // the current number being checked is the new max
                    if (sequenceLength > maxSequenceLength)
                    {
                        maxSequenceLength = sequenceLength;
                        maxNumber = i;
                    }

                    if ((number % 2) == 0)
                    {
                        number = number / 2;
                    }
                    else
                    {
                        number = 3 * number + 1;
                    }
                }
            }

            return maxNumber;
        }
    }
}
